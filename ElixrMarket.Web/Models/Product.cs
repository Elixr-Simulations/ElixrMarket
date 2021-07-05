using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElixrMarket.Web.Models
{
    public enum ProductStatus
    {
        PendingConfirmation,
        PendingAssignment,
        UnderReview,
        Bronze,
        Silver,
        Gold
    }

    /// <summary>
    /// A class defining a product on the elixr marketplace.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ElixrUser Developer { get; set; }
        public int RequirementsId { get; set; }
        public Requirements Requirements { get; set; }
        [MaxLength(1000)]
        public string Summary { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Review> Reviews { get; set; }   
        public double AverageReviewScore { get; set; }   
        public ICollection<UserProduct> Users { get; set; }
        public ProductStatus Status { get; set; }
        public string Url { get; set; }
        public string ThumbnailPath {get; set;}
        public string CarouselPath {get; set;}
        public string BinaryPath {get; set;}
    }
}