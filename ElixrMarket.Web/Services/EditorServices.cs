using ElixrMarket.Web.Data;
using ElixrMarket.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElixrMarket.Web.Services
{
    public interface IProductRelationshipService
    {
        Task CreateUserProduct(int productId, Guid userId, UserProductRelationship relationshipType);
        Task RemoveReviewer(int userProductId);
    }

    public class EFCoreProdRelService : IProductRelationshipService
    {
        private readonly ElixrDataContext _context;
        private readonly ILogger<EFCoreProdRelService> _logger;

        public EFCoreProdRelService(ElixrDataContext context, ILogger<EFCoreProdRelService> logger)
        {
            _context = context;
            _logger = logger;
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

        public async Task RemoveReviewer(int userProductId)
        {
            // get reviewership
            var reviewership = await _context.UserProducts.Include(p => p.Product).FirstOrDefaultAsync(r => r.Id == userProductId);
            reviewership.Product.Status = ProductStatus.PendingTechnicalAssignment;

            // get associated editorship
            var editorship = await _context.UserProducts.FirstOrDefaultAsync(r => r.ProductId == reviewership.ProductId && r.Relationship == UserProductRelationship.Editorship);

            _context.Remove(editorship);
            _context.Remove(reviewership);

            await _context.SaveChangesAsync();
        }
    }
}
