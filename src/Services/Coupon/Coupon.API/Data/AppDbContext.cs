using Microsoft.EntityFrameworkCore;
using Coupon.API.Models;
using Coupon.API.Models.Dto;

namespace Coupon.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CouponEntity> Coupons { get; set; }
    }
}
