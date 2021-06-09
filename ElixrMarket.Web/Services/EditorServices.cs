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
    public interface IEditorService
    {
        Task AssignReviewer(Product productId, Guid reviewerId, Guid editorId);
        Task RemoveReviewer(int userProductId);
    }

    public class EFCoreEditorService : IEditorService
    {
        private readonly ElixrDataContext _context;
        private readonly ILogger<EFCoreEditorService> _logger;

        public EFCoreEditorService(ElixrDataContext context, ILogger<EFCoreEditorService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AssignReviewer(Product product, Guid reviewerId, Guid editorId)
        {
            product.Status = ProductStatus.UnderReview;

            var reviewership = new UserProduct
            {
                UserId = reviewerId,
                ProductId = product.Id,
                Relationship = UserProductRelationship.Reviewership
            };

            var editorship = new UserProduct
            {
                UserId = editorId,
                ProductId = product.Id,
                Relationship = UserProductRelationship.Editorship
            };

            _context.Add(reviewership);
            _context.Add(editorship);

            await _context.SaveChangesAsync();
        }
        
        public async Task RemoveReviewer(int userProductId)
        {
            // get reviewership
            var reviewership = await _context.UserProducts.Include(p => p.Product).FirstOrDefaultAsync(r => r.Id == userProductId);
            reviewership.Product.Status = ProductStatus.PendingAssignment;

            // get associated editorship
            var editorship = await _context.UserProducts.FirstOrDefaultAsync(r => r.ProductId == reviewership.ProductId && r.Relationship == UserProductRelationship.Editorship);

            _context.Remove(editorship);
            _context.Remove(reviewership);

            await _context.SaveChangesAsync();
        }
    }
}
