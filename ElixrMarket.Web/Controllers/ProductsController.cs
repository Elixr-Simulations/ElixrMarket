using ElixrMarket.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElixrMarket.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _products;

        public ProductsController(IProductsService products)
        {
            _products = products;
        }

        [HttpGet("by-ids/{ids}")]
        public async Task<IActionResult> GetProductsById(string ids = "")
        {
            try
            {
                return new ObjectResult(await _products.GetProductsById(ids));
            }
            catch (ArrayTypeMismatchException ex)
            {
                return new BadRequestResult();
                throw;
            }
        }
    }
}
