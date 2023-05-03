using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionPortal.Data.Seeders
{
    public class CompanySeeder : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    CompanyID = 1,
                    Name = "Example Company 1",
                    Nip = "123-456-78-90",
                    Regon = "123456789",
                    CountryEstablishment = "Poland",
                    DateOfEstablishment = new DateTime(2000, 1, 1),
                    Description = "This is the first example company.",
                },
                new Company
                {
                    CompanyID = 2,
                    Name = "Example Company 2",
                    Nip = "098-765-43-21",
                    Regon = "122143289",
                    CountryEstablishment = "USA",
                    DateOfEstablishment = new DateTime(1990, 5, 10),
                    Description = "This is the second example company.",
                }
            );
        }
    }
}