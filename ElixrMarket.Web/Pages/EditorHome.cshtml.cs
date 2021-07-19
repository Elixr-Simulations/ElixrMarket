using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ElixrMarket.Web.Data;
using static ElixrMarket.Web.Data.Extensions;
using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElixrMarket.Web.Pages
{
    [Authorize(Roles = Constants.Roles.Editor)]
    public class EditorHomeModel : PageModel
    {
        public IList<ElixrUser> TechnicalReviewers { get; set; } = new List<ElixrUser>();
        public IList<ElixrUser> ContentReviewers { get; set; } = new List<ElixrUser>();
        public string ReviewerId { get; set; }
        public List<Product> NewlySubmittedProducts { get; set; } = new List<Product>();
        public Dictionary<Product, Tuple<string, List<ElixrUser>>> ProductsUnderTechnicalReview { get; set; } = new Dictionary<Product, Tuple<string, List<ElixrUser>>>();
        public List<Product> ProductsAwaitingContentReview { get; set; } = new List<Product>();
        public Dictionary<Product, Tuple<string, List<ElixrUser>>> ProductsUnderContentReview { get; set; } = new Dictionary<Product, Tuple<string, List<ElixrUser>>>();
        public List<Product> ProductsAwaitingFinalEval { get; set; } = new List<Product>();
        private readonly IProductRelationshipService _prodRelService;
        private readonly ElixrDataContext _context;
        private readonly UserManager<ElixrUser> _userManager;
        private readonly ILogger<EditorHomeModel> _logger;

        public EditorHomeModel(
            IProductRelationshipService editorService,
            ElixrDataContext context,
            UserManager<ElixrUser> userManager,
            ILogger<EditorHomeModel> logger)
        {
            _prodRelService = editorService;
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            await GetProductsAwaitingReview();
            await GetProductsUnderReview(UserProductRelationship.TechnicalReviewership, ProductsUnderTechnicalReview);
            await GetProductsUnderReview(UserProductRelationship.ContentReviewership, ProductsUnderContentReview);
            await GetProductsAwaitingFinalEval();
            await GetReviewers();
        }
        
        public async Task OnPostPassAsync(int id) {
            (await _context.Products.FirstOrDefaultAsync(p => p.Id == id)).Status = ProductStatus.Bronze;
            await _context.SaveChangesAsync();
        }

        public async Task OnPostFailAsync(int id) {
            
        }

        // called when editor makes assigns reviewers to products. param is a string of the format <productid:reviewerid,reviewerid...;otherproduct>
        public async Task<IActionResult> OnPost([FromForm]string technicalReviewerData, [FromForm]string contentReviewerData)
        {
            string editorId = HttpContext.GetCurrentUserId().ToString();

            if (!string.IsNullOrEmpty(technicalReviewerData))
            {
                await CreateRelationshipsFromDataStringAsync(technicalReviewerData, UserProductRelationship.TechnicalReviewership);   
            }
            if (!string.IsNullOrEmpty(contentReviewerData))
            {
                await CreateRelationshipsFromDataStringAsync(contentReviewerData, UserProductRelationship.ContentReviewership);
            }

            return new RedirectToPageResult("/EditorHome");
        }

        private async Task GetProductsAwaitingFinalEval()
        {
            ProductsAwaitingFinalEval = await _context.Products.Where(p => p.Status == ProductStatus.PendingFinalEval).ToListAsync();
        }

        private async Task CreateRelationshipsFromDataStringAsync(string reviewerDataString, UserProductRelationship relationshipType) {
            string editorId = HttpContext.GetCurrentUserId().ToString();

            var reviewerDict = ParseReviewerDataStringAsync(reviewerDataString);
            foreach (var product in reviewerDict)
            {
                await _prodRelService.CreateUserProduct(product.Key, new Guid(editorId), UserProductRelationship.Editorship);

                foreach (var reviewerId in product.Value)
                {
                    await _prodRelService.CreateUserProduct(product.Key, reviewerId, relationshipType);   
                }
            }
        }

        private Dictionary<int, List<Guid>> ParseReviewerDataStringAsync(string updatedReviewerData) {
            Dictionary<int, List<Guid>> productReviewerDict = new Dictionary<int, List<Guid>>();
            var productsChanged = updatedReviewerData.Split(';');

            foreach (var productString in productsChanged)
            {
                // first element will be product id, second will be a csl of reviewer ids
                string[] separatedProductString = productString.Split(':');

                // get product from database
                int productId = Convert.ToInt32(separatedProductString[0]);

                // get review ids from datastring
                var currentProductReviewers = separatedProductString[1].Split(',').Select(r => new Guid(r)).ToList();

                productReviewerDict.Add(productId, currentProductReviewers);
            }

            return productReviewerDict;
        }

        private async Task GetProductsAwaitingReview() {
            var productsAwaitingReview = await _context.Products.Where(p => p.Status == ProductStatus.PendingTechnicalAssignment || p.Status == ProductStatus.PendingContentAssignment).ToListAsync();
            NewlySubmittedProducts = productsAwaitingReview.Where(p => p.Status == ProductStatus.PendingTechnicalAssignment).ToList();
            ProductsAwaitingContentReview = productsAwaitingReview.Where(p => p.Status == ProductStatus.PendingContentAssignment).ToList();
        }

        private async Task GetProductsUnderReview(UserProductRelationship reviewType, Dictionary<Product, Tuple<string, List<ElixrUser>>> modelToFill) {
            var reviewerships = await _context.UserProducts
                .Include(r => r.User)
                .Include(r => r.Product).Where(p => p.Relationship == reviewType && p.Active).ToListAsync();

            var groupedReviewerships = from r in reviewerships
                                       group r by r.Product;

            
            var editorId = HttpContext.GetCurrentUserId();

            foreach (var productReviewers in groupedReviewerships)
            {
                // get product's editorship
                var editorship = await _context.UserProducts.Include(e => e.User).FirstOrDefaultAsync(r => r.Product.Id == productReviewers.Key.Id && r.Relationship == UserProductRelationship.Editorship);
                var reviewerList = productReviewers.Where(pr => pr.Relationship == reviewType).Select(o => o.User).ToList(); 

                var reviewerListWithEditorName = new Tuple<string, List<ElixrUser>>(editorship.User.UserName, reviewerList);

                modelToFill.Add(productReviewers.Key, reviewerListWithEditorName);
            }
        }

        private async Task GetReviewers()
        {
            TechnicalReviewers = await _userManager.GetUsersInRoleAsync(Constants.Roles.TechnicalReviewer);
            ContentReviewers = await _userManager.GetUsersInRoleAsync(Constants.Roles.ContentReviewer);
        }
    }
}
