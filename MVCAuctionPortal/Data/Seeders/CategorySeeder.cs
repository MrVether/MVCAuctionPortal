using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCAuctionPortal.Models;

namespace AuctionPortal.Data.Seeders
{
    public class CategorySeeder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryID = 1, Name = "Electronics", ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg" },
                new Category { CategoryID = 2, Name = "Home and Garden", ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg" },
                new Category { CategoryID = 3, Name = "Fashion", ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg" },
                new Category { CategoryID = 4, Name = "Toys and Games", ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg" }
            );
        }
    }
}
