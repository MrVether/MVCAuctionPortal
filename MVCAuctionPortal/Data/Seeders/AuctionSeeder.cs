using System;
using System.Collections.Generic;
using System.Linq;
using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCAuctionPortal.Models;
using ServicesAndInterfacesLibary.Models;

namespace AuctionPortal.Data.Seeders
{
    public class AuctionSeeder : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.HasData(
                new Auction
                {
                    AuctionID = 1,
                    Title = "Sample auction",
                    BuyItNow = false,
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 100,
                    Pieces = 5,
                    PurchaseCounter = 0,
                    CategoryID = 1,
                    ItemID = 1,
                    WarrantyID = 1,
                    ReviewID = 1,
                    UserID = 1,
                    ImageURL = "https://example.com/item2.jpg"
                }
            );
        }
    }
}