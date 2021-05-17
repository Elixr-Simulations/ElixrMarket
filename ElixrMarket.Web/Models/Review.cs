using System.ComponentModel.DataAnnotations;

namespace ElixrMarket.Web.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ElixrUser User { get; set; }   
        public int ProductId { get; set; }
        public Product Product { get; set; }   
        [Range(0, 5)]
        public double Rating { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Details { get; set; }
    }
}