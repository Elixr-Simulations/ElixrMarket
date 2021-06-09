using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElixrMarket.Web.Pages
{
    public class EditorHomeModel : PageModel
    {
        [BindProperty]
        public List<Product> NewlySubmittedProducts { get; set; } = new List<Product>();
        [BindProperty]
        public IList<ElixrUser> Reviewers { get; set; } = new List<ElixrUser>();
        [BindProperty]
        public string ReviewerId { get; set; }
        public Dictionary<UserProduct, string> ProductsUnderReview { get; set; } = new Dictionary<UserProduct, string>();
        private readonly IEditorService _editorService;
        private readonly ElixrDataContext _context;
        private readonly UserManager<ElixrUser> _userManager;

        private readonly ILogger<EditorHomeModel> _logger;

        public EditorHomeModel(
            IEditorService editorService,
            ElixrDataContext context,
            UserManager<ElixrUser> userManager,
            ILogger<EditorHomeModel> logger)
        {
            _editorService = editorService;
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            NewlySubmittedProducts = await _context.Products.Where(p => p.Status == ProductStatus.PendingAssignment).ToListAsync();
            var reviewerships = await _context.UserProducts
                .Include(r => r.User)
                .Include(r => r.Product).Where(p => p.Relationship == UserProductRelationship.Reviewership).ToListAsync();

            foreach (var reviewership in reviewerships)
            {
                var editorship = await _context.UserProducts.Include(e => e.User).FirstOrDefaultAsync(r => r.Product.Id == reviewership.Product.Id);
                ProductsUnderReview.Add(reviewership, editorship.User.UserName);
            }

            Reviewers = await _userManager.GetUsersInRoleAsync(Constants.Roles.Reviewer);
        }

        public async Task<IActionResult> OnPostAssignReviewer(int productId, string reviewerId)
        {
            string editorId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var selectedProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            await _editorService.AssignReviewer(selectedProduct, new Guid(reviewerId), new Guid(editorId));

            return new RedirectToPageResult("/EditorHome");
        }

        public async Task<IActionResult> OnPostRemoveReviewer(int userProductId)
        {
            string editorId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            // TODO: add this, remove test code
            //Guid reviewerGuid = new Guid(reviewerId);
            await _editorService.RemoveReviewer(userProductId);

            return new RedirectToPageResult("/EditorHome");
        }
    }
}
