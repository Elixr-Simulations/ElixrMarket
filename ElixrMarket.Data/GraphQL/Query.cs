using System.Linq;
using ElixrMarket.Data.EFCore;
using ElixrMarket.Data.Models;
using HotChocolate;

namespace ElixrMarket.Data.GraphQL
{
    public class Query
    {
        public IQueryable<Product> GetProducts([Service]ElixrDataContext context) {
            return context.Products;
        }
        
        public IQueryable<UserProfile> GetUsers([Service]ElixrDataContext context) {
            return context.Users;
        }
    }
}