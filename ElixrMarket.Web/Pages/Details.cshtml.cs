using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElixrMarket.Web.Pages
{
    public class DetailsModel : PageModel
    {
        // DI
        private readonly IProductsService _products;
        
        // Model Props
        [BindProperty]
        public Product Product{ get; set; }

        public DetailsModel(IProductsService products)
        {
            _products = products;
        }

        public async Task OnGetAsync(int id)
        {
            Product = await _products.GetProductById(id);
        }
    }
}
