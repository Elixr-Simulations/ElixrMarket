using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ElixrMarket.Web.Pages
{
    [Authorize(Roles = Constants.Roles.Customer)]
    public class CheckoutModel : PageModel
    {
        private readonly ElixrDataContext _context;

        public CheckoutModel(ElixrDataContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostPurchase(string checkoutItems)
        {
            foreach (char idChar in checkoutItems)
            {
                int productId = Convert.ToInt32(idChar.ToString());
                Guid userId = HttpContext.GetCurrentUserId();
                var existingProduct = await _context.UserProducts.FirstOrDefaultAsync(up => up.UserId == userId && up.ProductId == productId);

                if (existingProduct == null)
                {
                    var purchasedProduct = new UserProduct
                    {
                        ProductId = productId,
                        UserId = HttpContext.GetCurrentUserId(),
                        Relationship = UserProductRelationship.Ownership,
                    };

                    _context.Add(purchasedProduct);
                }
            }

            await _context.SaveChangesAsync();

            return new RedirectToPageResult("Store", new { redirectFromCheckout = true });
        }
    }
}
