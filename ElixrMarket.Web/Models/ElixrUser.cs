using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ElixrMarket.Web.Models
{
    /// <summary>
    /// A class defining a product on the elixr marketplace.
    /// </summary>
    public class ElixrUser : IdentityUser<Guid>
    {
        public ICollection<UserProduct> Products { get; set; }   
        public ICollection<Review> Reviews { get; set; }   
    }
}