using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CouponSeeder : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        // Seed some coupons
        builder.HasData(
            new Coupon
            {
                CouponID = 1,
                Name = "WELCOME10",
                Description = "10% discount on your first purchase",
                ExpireDate = DateTime.Now.AddMonths(1),
                DiscountPercentage = 10,
                NumberOfUses = 0,
                UserId = 1 
            },
            new Coupon
            {
                CouponID = 2,
                Name = "SPRING15",
                Description = "15% discount on your next purchase",
                ExpireDate = DateTime.Now.AddMonths(2),
                DiscountPercentage = 15,
                NumberOfUses = 0,
                UserId = 1 
            }
        );
    }
}
