using ElixrMarket.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElixrMarket.Web.Data
{
    /// <summary>
    /// The EFCore DbContext for all the non-auth related data related to the Elixr marketplace.
    /// </summary>
    public class ElixrDataContext : IdentityDbContext<ElixrUser, IdentityRole<Guid>, Guid>
    {
        public ElixrDataContext(DbContextOptions options) : base(options) { }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.Products)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Requirements)
                .WithOne(r => r.Product)
                .HasForeignKey<Requirements>(r => r.ProductId);
        }
    }
}
