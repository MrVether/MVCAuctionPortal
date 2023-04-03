using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;
using System.Collections.Generic;

namespace AuctionPortal.Data.Seeders
{
    public class BasketSeeder : IEntityTypeConfiguration<Basket>
    {
        public void Seed(AuctionDbContext context)
        {
            var baskets = new List<Basket>
            {
                new Basket
                {
                    BasketID = 1,
                    NumberOfItems = 2,
                    SummaryPrice = 50.0f,
                    UserID = 1
                },
                new Basket
                {
                    BasketID = 2,
                    NumberOfItems = 1,
                    SummaryPrice = 15.0f,
                    UserID = 2
                }
            };

            var basketAuctions = new List<BasketAndAuction>
            {
                new BasketAndAuction { BasketId = 1, AuctionId = 1 },
                new BasketAndAuction { BasketId = 1, AuctionId = 2 },
                new BasketAndAuction { BasketId = 2, AuctionId = 3 }
            };

            context.Basket.AddRange(baskets);
         //   context.BasketAndAuction.AddRange(basketAuctions);
            context.SaveChanges();
        }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Basket> builder)
        {
            builder.HasData(
                new Basket
                {
                    BasketID = 1,
                    NumberOfItems = 2,
                    SummaryPrice = 50.0f,
                    UserID = 1
                },
                new Basket { BasketID = 2, NumberOfItems = 1, SummaryPrice = 15.0f, UserID = 2 }
            );
        }
    }
}