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
                new Item { ItemID = 1, Name = "Laptop", Description = "Powerful Dell XPS 13 laptop with high-end specs", Manufacturer = "Dell", Condition = "Used", Model = "XPS 13", Other = "Includes charger and carrying case" },
                new Item { ItemID = 2, Name = "Smartphone", Description = "Brand new Samsung Galaxy S22 smartphone with great features", Manufacturer = "Samsung", Condition = "New", Model = "Galaxy S22", Other = "Comes with original packaging and accessories" },
                new Item { ItemID = 3, Name = "Sofa", Description = "Comfortable and stylish modern sofa", Manufacturer = "IKEA", Condition = "Used", Model = "KIVIK", Other = "Some minor wear and tear" },
                new Item { ItemID = 4, Name = "Kitchen Mixer", Description = "High-quality kitchen mixer for all your baking needs", Manufacturer = "KitchenAid", Condition = "New", Model = "Stand Mixer", Other = "Comes with original packaging and accessories" },
                new Item { ItemID = 5, Name = "Elegant Dress", Description = "Elegant and fashionable dress for special occasions", Manufacturer = "Designer", Condition = "New", Model = "Evening Dress", Other = "Available in multiple sizes and colors" },
                new Item { ItemID = 6, Name = "Stylish Watch", Description = "Elegant and fashionable Rolex Datejust 41 watch", Manufacturer = "Rolex", Condition = "New", Model = "Datejust 41", Other = "Includes box and papers" },
                new Item { ItemID = 7, Name = "LEGO Star Wars Set", Description = "Collectible LEGO Millennium Falcon set from the Star Wars series", Manufacturer = "LEGO", Condition = "New", Model = "Millennium Falcon", Other = "Factory sealed" },
                new Item { ItemID = 8, Name = "Road Bike", Description = "Lightweight and fast Trek Domane SL 6 road bike", Manufacturer = "Trek", Condition = "Used", Model = "Domane SL 6", Other = "Recently serviced and in great condition" }
            );
        }
    }
}
