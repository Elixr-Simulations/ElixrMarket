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
        Task CreateUserProduct(int productId, Guid userId, UserProductRelationship relationshipType);
        //Task removeUserProduct(int userProductId);
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

        public async Task CreateUserProduct(int productId, Guid userId, UserProductRelationship relationshipType)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            switch (relationshipType)
            {
                case UserProductRelationship.TechnicalReviewership:
                    product.Status = ProductStatus.UnderTechnicalReview;
                    break;
                case UserProductRelationship.ContentReviewership:
                    product.Status = ProductStatus.UnderContentReview;
                    break;
                default:
                    break;
            }

            var relationship = new UserProduct
            {
                UserId = userId,
                ProductId = productId,
                Relationship = relationshipType,
                Active = true
            };

            _context.Add(relationship);

            await _context.SaveChangesAsync();
        }
    }
}
