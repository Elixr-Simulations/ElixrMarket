using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ElixrMarket.Web.Models
{
    /// <summary>
    /// A class defining a product on the elixr marketplace.
    /// </summary>
    public class Genre
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}