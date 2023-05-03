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
                new Category { CategoryID = 1, Name = "Electronics", ImageURL = "https://cdn.pixabay.com/photo/2016/03/27/19/43/smartphone-1283938_1280.jpg" },
                new Category { CategoryID = 2, Name = "Home and Garden", ImageURL = "https://cdn.pixabay.com/photo/2016/11/29/03/53/architecture-1867187_1280.jpg" },
                new Category { CategoryID = 3, Name = "Fashion", ImageURL = "https://cdn.pixabay.com/photo/2017/08/01/11/48/blue-2564660_1280.jpg" },
                new Category { CategoryID = 4, Name = "Toys and Games", ImageURL = "https://www.waysideinsurance.com/wp-content/uploads/2019/12/184/shopping-tips-to-avoid-dangerous-toys.jpg" }
            );
        }
    }
}