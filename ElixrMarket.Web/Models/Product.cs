using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElixrMarket.Web.Models
{
    /// <summary>
    /// A class defining a product on the elixr marketplace.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Summary { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Review> Reviews { get; set; }   
        public double AverageReviewScore { get; set; }   
        public ICollection<UserProduct> Users { get; set; }   
    }
}