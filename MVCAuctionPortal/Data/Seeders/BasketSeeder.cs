using AuctionPortal.Models;
using System.Collections.Generic;
using MVCAuctionPortal.Models;
using Microsoft.EntityFrameworkCore;

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
                    UserID = 1,
                    Auctions = new List<Auction>
                    {
                        new Auction
                        {
                            AuctionID = 1,
                            Title = "Item 1",
                            BuyItNow = false,
                            DateOfIssue = new System.DateTime(2022, 1, 1),
                            EndDate = new System.DateTime(2022, 1, 7),
                            Price = 20.0m,
                            Pieces = 1,
                            PurchaseCounter = 0,
                            SubCategoryID = 1,
                            ItemID = 1,
                            WarrantyID = 1,
                            ReviewID = 1,
                            ImageURL = "https://example.com/item1.jpg"
                        },
                        new Auction
                        {
                            AuctionID = 2,
                            Title = "Item 2",
                            BuyItNow = true,
                            DateOfIssue = new System.DateTime(2022, 1, 2),
                            EndDate = new System.DateTime(2022, 1, 8),
                            Price = 30.0m,
                            Pieces = 1,
                            PurchaseCounter = 0,
                            SubCategoryID = 2,
                            ItemID = 2,
                            WarrantyID = 2,
                            ReviewID = 2,
                            ImageURL = "https://example.com/item2.jpg"
                        }
                    }
                },
                new Basket
                {
                    BasketID = 2,
                    NumberOfItems = 1,
                    SummaryPrice = 15.0f,
                    UserID = 2,
                    Auctions = new List<Auction>
                    {
                        new Auction
                        {
                            AuctionID = 3,
                            Title = "Item 3",
                            BuyItNow = false,
                            DateOfIssue = new System.DateTime(2022, 1, 3),
                            EndDate = new System.DateTime(2022, 1, 9),
                            Price = 15.0m,
                            Pieces = 1,
                            PurchaseCounter = 0,
                            SubCategoryID = 3,
                            ItemID = 3,
                            WarrantyID = 3,
                            ReviewID = 3,
                            ImageURL = "https://example.com/item3.jpg"
                        }
                    }
                }
            };
            context.Basket.AddRange(baskets);
            context.SaveChanges();
        }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Basket> builder)
        {
            builder.HasData(
                new Basket { BasketID = 1, NumberOfItems = 2, SummaryPrice = 50.0f, UserID = 1 },
                new Basket { BasketID = 2, NumberOfItems = 1, SummaryPrice = 15.0f, UserID = 2 }
            );
        }
    }
}