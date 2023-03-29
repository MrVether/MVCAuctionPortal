using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionPortal.Data.Seeders
{
    public class ItemSeeder : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(
                new Item { ItemID = 1, Name = "Smartphone", Description = "Brand new smartphone with great features", Manufacturer = "Samsung", Condition = "New", Model = "Galaxy S21", Other = "Comes with original packaging and accessories" },
                new Item { ItemID = 2, Name = "Laptop", Description = "Powerful laptop with high-end specs", Manufacturer = "Dell", Condition = "Used", Model = "XPS 13", Other = "Includes charger and carrying case" },
                new Item { ItemID = 3, Name = "Headphones", Description = "Wireless noise-cancelling headphones", Manufacturer = "Sony", Condition = "Like new", Model = "WH-1000XM4", Other = "Comes with charging cable and carrying case" }
            );
        }
    }
}
