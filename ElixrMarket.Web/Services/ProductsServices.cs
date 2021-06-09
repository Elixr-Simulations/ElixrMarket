using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElixrMarket.Web.Services
{
    public interface IProductsService
    {
        Task<Product> GetProductById(int id);
        Task<List<UserProduct>> GetUserProducts(Guid userId);
        Task<List<Product>> GetProductsById(string ids);
        Task<List<Product>> GetAllProducts();
    }

    public class EFCoreProductsService : IProductsService
    {
        private readonly ElixrDataContext _context;
        private readonly ILogger<EFCoreProductsService> _logger;

        public EFCoreProductsService(ElixrDataContext context, ILogger<EFCoreProductsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        // takes a comma-delimited string of ids, returns a matching array of products
        public async Task<List<Product>> GetProductsById(string ids)
        {
            string[] idArray = ids.Trim(',').Split(',');
            List<int> intIds = new List<int>();
            foreach (var id in idArray)
            {
                if (int.TryParse(id, out int intId))
                {
                    intIds.Add(intId);
                }
                else
                {
                    throw new ArrayTypeMismatchException();
                }
            }

            return await _context.Products.Where(p => intIds.Any(i => i == p.Id)).ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<UserProduct>> GetUserProducts(Guid userId)
        {
            return await _context.UserProducts.Include(up => up.Product).Where(up => up.UserId == userId).ToListAsync();
        }
    }

    public class MockProductsService : IProductsService
    {
        private readonly ElixrDataContext _context;
        private readonly ILogger<MockProductsService> _logger;

        

        public MockProductsService(ILogger<MockProductsService> logger)
        {
            _logger = logger;
        }

        public async Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
            //return products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Product>> GetProductsById(string ids)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserProduct>> GetUserProducts(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
