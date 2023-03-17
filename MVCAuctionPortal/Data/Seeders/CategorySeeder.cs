using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicesAndInterfacesLibary.Models;

namespace AuctionPortal.Data.Seeders
{
    public class CategorySeeder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryID = 1, Name = "Electronics" },
                new Category { CategoryID = 2, Name = "Home and Garden" },
                new Category { CategoryID = 3, Name = "Fashion" },
                new Category { CategoryID = 4, Name = "Toys and Games" }
            );
        }
    }
}
