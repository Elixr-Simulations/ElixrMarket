using System;

namespace ElixrMarket.Web.Models
{
    public enum UserProductRelationship
    {
        Ownership,
        ContentReviewership,
        Editorship,
        TechnicalReviewership,
        Inactive
    }

    /// <summary>
    /// A class defining a product on the elixr marketplace.
    /// </summary>
    public class UserProduct
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public ElixrUser User { get; set; }   
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public UserProductRelationship Relationship { get; set; }
        public bool Active { get; set; }
    }
}