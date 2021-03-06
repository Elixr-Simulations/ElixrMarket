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

namespace ElixrMarket.Web.Pages
{
    public class DetailsModel : PageModel
    {
        // DI
        private readonly IWebHostEnvironment _env;
        private readonly ElixrDataContext _context;
        
        [BindProperty]
        public string Thumb { get; set; }
        [BindProperty]
        public Product Product { get; set; }

        public DetailsModel(ElixrDataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task OnGetAsync(int id)
        {
            Product = await _context.Products
                .Include(p => p.Developer)
                .Include(p => p.Requirements).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
