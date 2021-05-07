using ElixrMarket.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ElixrMarket.Data.EFCore
{
    /// <summary>
    /// The EFCore DbContext for all the non-auth related data related to the Elixr marketplace.
    /// </summary>
    public class ElixrDataContext : DbContext
    {
        public ElixrDataContext(DbContextOptions options) : base(options) {}

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.Products)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
