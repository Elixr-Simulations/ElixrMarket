using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
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
        public IActionResult OnGet()
        {
            if (HttpContext.User.IsInRole(Constants.Roles.Admin))
            {
                return new RedirectToPageResult("/admin");
            }
            if (HttpContext.User.IsInRole(Constants.Roles.Editor))
            {
                return new RedirectToPageResult("/editorhome");
            }
            if (HttpContext.User.IsInRole(Constants.Roles.ContentReviewer) || HttpContext.User.IsInRole(Constants.Roles.TechnicalReviewer))
            {
                return new RedirectToPageResult("/reviewerhome");
            }

            return new RedirectToPageResult("/store");
        }
    }
}
