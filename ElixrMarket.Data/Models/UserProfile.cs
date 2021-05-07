using System.Collections.Generic;

namespace ElixrMarket.Data.Models
{
    /// <summary>
    /// A class defining a product on the elixr marketplace.
    /// </summary>
    public class UserProfile
    {
        public int Id { get; set; }   
        public ICollection<UserProduct> Products { get; set; }   
        public ICollection<Review> Reviews { get; set; }   
        public bool IsDev { get; set; }
    }
}