﻿using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionPortal.Data.Seeders
{
    public class ReviewSeeder : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review { ReviewID = 1, AuctionID = 1, UserID = 1, Title = "Great seller", Description = "I had a very positive experience with this seller. The item arrived quickly and was exactly as described.", IsPositive = true },
                new Review { ReviewID = 2, AuctionID = 2, UserID = 1, Title = "Excellent product", Description = "I purchased this product and it exceeded my expectations. The quality was great and it worked perfectly.", IsPositive = true },
                new Review { ReviewID = 3, AuctionID = 3, UserID = 1, Title = "Fast shipping", Description = "The item was shipped quickly and arrived in perfect condition. I would definitely buy from this seller again.", IsPositive = true }
            );
        }
    }
}