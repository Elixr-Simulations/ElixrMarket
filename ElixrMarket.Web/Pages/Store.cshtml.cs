using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ElixrMarket.Web.Pages
{
    public class StoreModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; } = new List<Product>();
        [BindProperty]
        public bool RedirectFromCheckout { get; set; }
        private readonly IProductsService _products;
        private readonly ILogger<StoreModel> _logger;
        private readonly ElixrDataContext _context;
        private readonly IWebHostEnvironment _env;

        public StoreModel(IWebHostEnvironment env, IProductsService products, ILogger<StoreModel> logger, ElixrDataContext context)
        {
            _env = env;
            _products = products;
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync(bool redirectFromCheckout = false)
        {
            RedirectFromCheckout = redirectFromCheckout;
            Products = await _context.Products.Where(p => 
                p.Status == ProductStatus.Bronze ||
                p.Status == ProductStatus.Silver ||
                p.Status == ProductStatus.Gold).ToListAsync();
        }

        public async Task OnPostTestBuy(int productId)
        {
            var userId = HttpContext.GetCurrentUserId();
            var userProduct = new UserProduct { UserId = userId, ProductId = productId, Relationship = UserProductRelationship.Ownership };
            _context.Add(userProduct);
            await _context.SaveChangesAsync();

            OnGetAsync();
        }        
    }
}
