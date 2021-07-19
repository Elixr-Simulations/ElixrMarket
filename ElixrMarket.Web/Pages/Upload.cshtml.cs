using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;

namespace ElixrMarket.Web.Pages
{
    [Authorize(Roles = Constants.Roles.Developer)]
    public class UploadModel : PageModel
    {
        public SelectList GenreOptions { get; set; }
        private readonly IProductsService _products;
        private readonly ILogger<UploadModel> _logger;
        private readonly ElixrDataContext _context;
        private readonly UserManager<ElixrUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public UploadModel(
            IProductsService products, 
            ILogger<UploadModel> logger, 
            ElixrDataContext context, 
            UserManager<ElixrUser> userManager,
            IWebHostEnvironment env)
        {
            //var schemes = authSchemeProvider.
            _products = products;
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public async Task OnGetAsync(bool redirectFromCheckout = false)
        {
            GenreOptions = new SelectList(await _context.Genres.ToListAsync(), nameof(Genre.Id), nameof(Genre.Name));
        }

        public async Task<IActionResult> OnPostAsync(
            [FromForm]string name,
            [FromForm]string desc,
            [FromForm]decimal price,
            [FromForm]string genres,
            [FromForm]string storage,
            [FromForm]string OS,
            [FromForm]string minCPU,
            [FromForm]string minGPU,
            [FromForm]string minRAM,
            [FromForm]string maxCPU,
            [FromForm]string maxGPU,
            [FromForm]string maxRAM,
            [FromForm]string appLink,
            [FromForm]IFormFileCollection carouselMedia,
            [FromForm]IFormFile thumbPhoto) {
            try
            {
                var uploadedProduct = await SaveProductToDatabaseAsync(
                    name,
                    desc,
                    price,
                    genres,
                    storage,
                    OS,
                    minCPU,
                    minGPU,
                    minRAM,
                    maxCPU,
                    maxGPU,
                    maxRAM,
                    appLink,
                    thumbPhoto,
                    carouselMedia);              

                return new OkObjectResult(new { Id = uploadedProduct.Id, name = uploadedProduct.Name });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(500);
                throw ex;
            }
        }

        private async Task SaveProductMediaToDisc(Product product, IFormFile thumbPhoto, IFormFileCollection carouselMedia)
        {
            string mediaPath = CreateMediaDirectoriesAndReturnPath(product);
            string thumbPath = await SaveThumbnailToDiscAndReturnPath(mediaPath, thumbPhoto);
            string carouselPaths = await SaveCarouselMediaToDiscAsyncAndReturnPaths(mediaPath, carouselMedia);

            product.ThumbnailPath = thumbPath;
            product.CarouselPath = carouselPaths;
        }

        private async Task<string> SaveCarouselMediaToDiscAsyncAndReturnPaths(string mediaPath, IFormFileCollection carouselMedia)
        {
            var fileTypeProvier = new FileExtensionContentTypeProvider();

            string[] filePaths = new string[carouselMedia.Count];

            if (carouselMedia.Count > 0)
            {
                for (int i = 1; i <= carouselMedia.Count; i++) {
                    string fileType = carouselMedia[i - 1].ContentType;
                    if (fileType.Contains("image")) {
                        string extension = fileType.Replace("image/", "");
                        using (var fileStream = System.IO.File.Create(mediaPath + "/carousel/" + i + "." + extension))
                        {
                            await carouselMedia[i - 1].CopyToAsync(fileStream);
                            filePaths[i - 1] = fileStream.Name.Replace(Startup.Environment.WebRootPath + "/", "");
                        }
                    }
                }   
            }

            return string.Join(",", filePaths);
        }

        private async Task<string> SaveThumbnailToDiscAndReturnPath(string productMediaPath, IFormFile thumbPhoto)
        {
            string filePath = "";

            if (thumbPhoto != null)
            {
                string thumbFileType = thumbPhoto.ContentType;
                if (thumbFileType.Contains("image")) {
                    string extension = thumbFileType.Replace("image/", "");
                    using (var fileStream = System.IO.File.Create(productMediaPath + "/thumb/thumb" + "." + extension))
                    {
                        await thumbPhoto.CopyToAsync(fileStream);   
                        filePath = fileStream.Name.Replace(Startup.Environment.WebRootPath + "/", "");
                    }
                }   
            }

            return filePath;
        }

        private async Task<Product> SaveProductToDatabaseAsync(
            string desc,
            string name,
            decimal price,
            string genres,
            string storage,
            string OS,
            string minCPU,
            string minGPU,
            string minRAM,
            string maxCPU,
            string maxGPU,
            string maxRAM,
            string appLink,
            IFormFile thumbPhoto,
            IFormFileCollection carouselMedia) {
            var requirements = new Requirements {
                Storage = storage,
                OS = OS,
                MinProc = minCPU,
                MinGraph = minGPU,
                MinMem = minRAM, 
                RecProc = maxCPU,
                RecGraph = maxGPU,
                RecMem = maxRAM, 
            };

            var uploadedProduct = new Product {
                Name = name,
                Description = desc,
                Developer = await _userManager.GetUserAsync(HttpContext.User),
                ReleaseDate = DateTime.MinValue,
                Genres = genres,
                Price = price,
                Status = ProductStatus.PendingTechnicalAssignment,
                Requirements = requirements,
            };

            if (!string.IsNullOrWhiteSpace(appLink))
            {
                uploadedProduct.Url = appLink;
            }

            try
            {
                await SaveProductMediaToDisc(uploadedProduct, thumbPhoto, carouselMedia);
                _context.Add(uploadedProduct);
                await _context.SaveChangesAsync();     

                _context.Update(uploadedProduct);
                uploadedProduct.BinaryPath = $"product-files/{uploadedProduct.Id}/bin/{uploadedProduct.Name}_installer";

                await _context.SaveChangesAsync();     
                return uploadedProduct;
            }
            catch (System.Exception ex) {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private string CreateMediaDirectoriesAndReturnPath(Product product) {
            string productMediaPath = _env.WebRootPath + $"/product-files/{product.Id}/media";

            Directory.CreateDirectory(productMediaPath + "/carousel");
            Directory.CreateDirectory(productMediaPath + "/thumb");
            Directory.CreateDirectory(_env.WebRootPath + $"/product-files/{product.Id}/bin/");

            return productMediaPath;
        }
    }
}