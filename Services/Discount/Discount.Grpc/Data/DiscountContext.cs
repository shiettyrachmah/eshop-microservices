using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone X", Description = "Iphone Discount", Amount = 200000 },
                new Coupon { Id = 2, ProductName = "Samsung X", Description = "Samsung Discount", Amount = 100000 },
                new Coupon { Id = 3, ProductName = "Oppo X", Description = "Oppo Discount", Amount = 70000 },
                new Coupon { Id = 4, ProductName = "Xiomi X", Description = "Xiomi Discount", Amount = 60000 },
                new Coupon { Id = 5, ProductName = "Vivo X", Description = "Vivo Discount", Amount = 55000 }
                );
        }
    }
}
