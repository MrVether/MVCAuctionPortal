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
                    Title = "Dell XPS 13",
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 1000,
                    Pieces = 5,
                    SubCategoryID = 1,
                    ItemID = 1,
                    WarrantyID = 1,
                    UserID = 2,
                    ImageURL = "https://cdn.x-kom.pl/i/setup/images/prod/big/product-new-big,,2022/5/pr_2022_5_17_12_20_15_932_03.jpg"
                },
                new Auction
                {
                    AuctionID = 2,
                    Title = "Samsung Galaxy S22",
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 700,
                    Pieces = 3,
                    SubCategoryID = 2,
                    ItemID = 2,
                    WarrantyID = 2,
                    UserID = 2,
                    ImageURL = "https://www.proshop.pl/Images/915x900/3031704_4e1eacc41047.jpg"
                },
                new Auction
                {
                    AuctionID = 3,
                    Title = "Modern Sofa",
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 1200,
                    Pieces = 1,
                    SubCategoryID = 3,
                    ItemID = 3,
                    WarrantyID = 3,
                    UserID = 2,
                    ImageURL = "https://umebluje.pl/41747-large_default/sofa-modern-25-grafitowa.jpg"
                },
                new Auction
                {
                    AuctionID = 4,
                    Title = "Kitchen Mixer",
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 150,
                    Pieces = 2,
                    SubCategoryID = 4,
                    ItemID = 4,
                    WarrantyID = 3,
                    UserID = 2,
                    ImageURL = "https://m.media-amazon.com/images/I/61anBuiHUhL.jpg"
                },
                new Auction
                {
                    AuctionID = 5,
                    Title = "Elegant Dress",
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 80,
                    Pieces = 4,
                    SubCategoryID = 5,
                    ItemID = 5,
                    WarrantyID = 3,
                    UserID = 2,
                    ImageURL = "https://n.nordstrommedia.com/id/sr3/ec6af5bc-c712-478b-b2d8-3723257766be.jpeg?h=365&w=240&dpr=2"
                }, new Auction
                {
                    AuctionID = 6,
                    Title = "Stylish Watch",
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 250,
                    Pieces = 3,
                    SubCategoryID = 6,
                    ItemID = 6,
                    WarrantyID = 2,
                    UserID = 2,
                    ImageURL = "https://m.media-amazon.com/images/I/61+hXDh7oIL._AC_UY1000_.jpg"
                },
                new Auction
                {
                    AuctionID = 7,
                    Title = "LEGO Star Wars Set",
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 100,
                    Pieces = 10,
                    SubCategoryID = 7,
                    ItemID = 7,
                    WarrantyID = 1,
                    UserID = 2,
                    ImageURL = "https://www.lego.com/cdn/cs/set/assets/blt847a7b38581ded36/75315.png"
                },
                new Auction
                {
                    AuctionID = 8,
                    Title = "Road Bike",
                    DateOfIssue = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Price = 850,
                    Pieces = 2,
                    SubCategoryID = 8,
                    ItemID = 8,
                    WarrantyID = 2,
                    UserID = 2,
                    ImageURL = "https://ibkbike.vtexassets.com/arquivos/ids/593348-1200-auto?v=638060623332200000&width=1200&height=auto&aspect=true"
                }
            );
        }
    }
}
