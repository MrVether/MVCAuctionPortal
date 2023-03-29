using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    Title = "Iphone",
                    BuyItNow = false,
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 100,
                    Pieces = 5,
                    PurchaseCounter = 0,
                    SubCategoryID = 1,
                    ItemID = 1,
                    WarrantyID = 1,
                    ReviewID = 1,
                    UserID = 2,
                    ImageURL = "https://m.media-amazon.com/images/I/71dpTXFz+dL._AC_UF1000,1000_QL80_.jpg"
                },
                new Auction
                {
                    AuctionID = 2,
                    Title = "Shovel",
                    BuyItNow = true,
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14),
                    Price = 200,
                    Pieces = 3,
                    PurchaseCounter = 0,
                    SubCategoryID = 2,
                    ItemID = 2,
                    WarrantyID = 2,
                    ReviewID = 2,
                    UserID = 2,
                    ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg"
                },
                new Auction
                {
                    AuctionID = 3,
                    Title = "Boots",
                    BuyItNow = false,
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(21),
                    Price = 300,
                    Pieces = 1,
                    PurchaseCounter = 0,
                    SubCategoryID = 3,
                    ItemID = 3,
                    WarrantyID = 3,
                    ReviewID = 3,
                    UserID = 2,
                    ImageURL = "https://a.allegroimg.com/original/1e76f9/ba5267f249a8bb358f5d3cf50ec6"
                }
            );
        }
    }
}
