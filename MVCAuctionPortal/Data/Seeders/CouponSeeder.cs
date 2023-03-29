using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionPortal.Data.Seeders
{
    public class CouponSeeder : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasData(
                new Coupon { CouponID = 1, Name = "SALE10", Description = "10% off", ExpireDate = new DateTime(2023, 12, 31), NumberOfUses = 100 },
                new Coupon { CouponID = 2, Name = "SALE20", Description = "20% off", ExpireDate = new DateTime(2023, 12, 31), NumberOfUses = 50 },
                new Coupon { CouponID = 3, Name = "SALE30", Description = "30% off", ExpireDate = new DateTime(2023, 12, 31), NumberOfUses = 25 }
            );
        }
    }
}