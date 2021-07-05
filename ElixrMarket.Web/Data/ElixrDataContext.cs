using ElixrMarket.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElixrMarket.Web.Data
{
    /// <summary>
    /// The EFCore DbContext for all the non-auth related data related to the Elixr marketplace.
    /// </summary>
    public class ElixrDataContext : IdentityDbContext<ElixrUser, IdentityRole<Guid>, Guid> {
        public ElixrDataContext(DbContextOptions options) : base(options) { }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<Genre> Genres { get; set; }

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

            modelBuilder.Entity<Genre>().HasData(new List<Genre> {
                new Genre {Id = 1, Name = "Medical"},
                new Genre {Id = 2, Name = "Education"},
                new Genre {Id = 3, Name = "Industry"}
            });
        }
    }

    public static class Extensions {
        public static async Task<Product> GetByIdAsync(this DbSet<Product> products, int id) {
            return await products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
