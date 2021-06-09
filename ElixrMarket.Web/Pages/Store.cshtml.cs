using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ElixrMarket.Web.Pages
{
    public class StoreModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }
        [BindProperty]
        public bool RedirectFromCheckout { get; set; }
        private readonly IProductsService _products;
        private readonly ILogger<StoreModel> _logger;
        private readonly ElixrDataContext _context;

        public StoreModel(IProductsService products, ILogger<StoreModel> logger, ElixrDataContext context)
        {
            _products = products;
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync(bool redirectFromCheckout = false)
        {
            RedirectFromCheckout = redirectFromCheckout;
            Products = await _products.GetAllProducts();
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
