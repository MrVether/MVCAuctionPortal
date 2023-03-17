using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicesAndInterfacesLibary.Models;

namespace AuctionPortal.Data.Seeders
{
    public class SubCategorySeeder : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasData(
                new SubCategory { SubCategoryID = 1, Name = "Laptops", CategoryID = 1 },
                new SubCategory { SubCategoryID = 2, Name = "Smartphones", CategoryID = 1 },
                new SubCategory { SubCategoryID = 3, Name = "Furniture", CategoryID = 2 },
                new SubCategory { SubCategoryID = 4, Name = "Kitchen appliances", CategoryID = 2 }
            );

            builder.HasOne(s => s.Categories)
                   .WithMany(c => c.SubCategory)
                   .HasForeignKey(s => s.CategoryID);
        }
    }
}
