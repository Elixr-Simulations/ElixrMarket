using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ElixrMarket.Web.Pages
{
    public class LibraryModel : PageModel
    {
        [BindProperty]
        public List<UserProduct> OwnedProducts { get; set; }
        private readonly IProductsService _products;
        private readonly ILogger<LibraryModel> _logger;

        public LibraryModel(IProductsService products, ILogger<LibraryModel> logger)
        {
            _products = products;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            OwnedProducts = await _products.GetUserProducts(new Guid(userId));
        }
    }
}
