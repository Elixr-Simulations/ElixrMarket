using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElixrMarket.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElixrMarket.Web.Pages
{
    public class CartModel : PageModel
    {
        [BindProperty]
        public List<Product> LineItems { get; set; }

        public void OnGet(string cart = "")
        {
        }
    }
}
