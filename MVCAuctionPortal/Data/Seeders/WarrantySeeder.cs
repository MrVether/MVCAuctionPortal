using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionPortal.Data.Seeders
{
    public class WarrantySeeder : IEntityTypeConfiguration<Warranty>
    {
        public void Configure(EntityTypeBuilder<Warranty> builder)
        {
            builder.HasData(
                new Warranty { WarrantyID = 1, Name = "Basic", Durantion = 12, Description = "Basic warranty for 1 year." },
                new Warranty { WarrantyID = 2, Name = "Extended", Durantion = 24, Description = "Extended warranty for 2 years." },
                new Warranty { WarrantyID = 3, Name = "Premium", Durantion = 36, Description = "Premium warranty for 3 years." }
            );
        }
    }
}