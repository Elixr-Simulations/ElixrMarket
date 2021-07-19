using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElixrMarket.Web.Pages
{
    [Authorize(Roles = Constants.Roles.ContentReviewer + "," + Constants.Roles.TechnicalReviewer)]
    public class ReviewerHomeModel : PageModel
    {
        private readonly ElixrDataContext _context;
        private readonly ILogger<ReviewerHomeModel> _logger;

        [BindProperty]
        public List<UserProduct> AssignedProducts { get; set; } = new List<UserProduct>();

        public ReviewerHomeModel(ElixrDataContext context, ILogger<ReviewerHomeModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var currentUserId = HttpContext.GetCurrentUserId();

            // get products associated with the current reviewer, ensure the relationship is a reviewership 
            AssignedProducts = await _context.UserProducts
                .Include(up => up.Product)
                .Where(up => up.UserId == currentUserId && up.Active == true).ToListAsync();
        }

        public async Task OnPostPassAsync(int id)
        {
            var selectedRelationship = await _context.UserProducts
                .Include(up => up.Product)
                .FirstOrDefaultAsync(up => up.Id == id);

            selectedRelationship.Active = false;

            if (selectedRelationship.Product.Status == ProductStatus.UnderTechnicalReview) {
                selectedRelationship.Product.Status = ProductStatus.PendingContentAssignment;
            }
            else if (selectedRelationship.Product.Status == ProductStatus.UnderContentReview) {
                selectedRelationship.Product.Status = ProductStatus.PendingFinalEval;
            }

            await _context.SaveChangesAsync();

            await OnGetAsync();
        }

        public async Task OnPostFailAsync(int id)
        {
            var selectedRelationship = await _context.UserProducts
                .Include(up => up.Product)
                .FirstOrDefaultAsync(up => up.Id == id);

            selectedRelationship.Active = false;

            await OnGetAsync();
        }
    }
}
