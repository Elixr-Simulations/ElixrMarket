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
    [Authorize(Roles = Constants.Roles.Reviewer)]
    public class ReviewerHomeModel : PageModel
    {
        private readonly ElixrDataContext _context;
        private readonly ILogger<ReviewerHomeModel> _logger;

        [BindProperty]
        public List<Product> AssignedProducts { get; set; } = new List<Product>();

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
                .Where(up => up.UserId == currentUserId)
                .Select(up => up.Product).ToListAsync();
        }
    }
}
