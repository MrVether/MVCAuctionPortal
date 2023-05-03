using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionPortal.Data.Seeders
{
    public class SubCategorySeeder : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasData(
                new SubCategory { SubCategoryID = 1, Name = "Laptops", CategoryID = 1, ImageURL = "https://miro.medium.com/v2/resize:fit:928/1*SUK_D1dp3Acw1EjE1Cn6OA.png" },
                new SubCategory { SubCategoryID = 2, Name = "Smartphones", CategoryID = 1, ImageURL = "https://cdn.pixabay.com/photo/2016/11/29/12/30/android-1869510_1280.jpg" },
                new SubCategory { SubCategoryID = 3, Name = "Furniture", CategoryID = 2, ImageURL = "https://cdn.pixabay.com/photo/2016/11/18/17/20/living-room-1835923_1280.jpg" },
                new SubCategory { SubCategoryID = 4, Name = "Kitchen appliances", CategoryID = 2, ImageURL = "https://www.compliancegate.com/wp-content/uploads/2019/12/kitchen-appliances-safety-standards-eu.jpg" },
                new SubCategory { SubCategoryID = 5, Name = "Clothing", CategoryID = 3, ImageURL = "https://cdn.pixabay.com/photo/2017/08/01/08/29/people-2563491_1280.jpg" },
                new SubCategory { SubCategoryID = 6, Name = "Accessories", CategoryID = 3, ImageURL = "https://media.istockphoto.com/id/1181376840/photo/mock-up-blank-empty-digital-tablet-screen-on-beige-fashion-women-stylish-accessories-with-tag.jpg?s=612x612&w=0&k=20&c=AVOd71gDv5dRL9aic_9JmLyB0nvHkpSZ3uNkc9dl74o=" },
                new SubCategory { SubCategoryID = 7, Name = "Board games", CategoryID = 4, ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRuBnq8qmkvccgSwZhLaxEIn5KzJqWSfdm5ow&usqp=CAU" },
                new SubCategory { SubCategoryID = 8, Name = "Video games", CategoryID = 4, ImageURL = "https://cdn.vox-cdn.com/thumbor/VK3R_SzCKTnG4egaSIMpxewl7M4=/0x0:2040x1360/1400x1400/filters:focal(1020x680:1021x681)/cdn.vox-cdn.com/uploads/chorus_asset/file/22236383/acastro_210113_1777_gamingstock_0002.jpg" }
            );

            builder.HasOne(s => s.Categories)
                   .WithMany(c => c.SubCategory)
                   .HasForeignKey(s => s.CategoryID);
        }
    }
}
