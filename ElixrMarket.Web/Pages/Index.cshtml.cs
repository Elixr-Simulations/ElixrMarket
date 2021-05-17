using ElixrMarket.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElixrMarket.Web.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Product> Products { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Products = new List<Product>()
            {
                new Product { Id = 1, Name = "Test product 1", Price = 4.99m },
                new Product { Id = 2, Name = "Test product 2", Price = 4.99m },
                new Product { Id = 3, Name = "Test product 3", Price = 4.99m },
                new Product { Id = 4, Name = "Test product 4", Price = 4.99m }
            };
        }
    }
}
