using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon() { Id = 1, ProductName = "Iphone 16 Pro Max", Description = "Latest Iphone", Amount = 150},
                new Coupon() { Id = 2, ProductName = "Samsung Galaxy 23", Description = "Latest Samsung", Amount = 150 }
                );
        }
    }
}
