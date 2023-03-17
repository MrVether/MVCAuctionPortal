using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionPortal.Data.Seeders
{
    public class AddressSeeder : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                new Address { AddressID = 1, Street = "Main Street", HouseNumber = "10", LocalNumber = "1", ZipCode = "12345" },
                new Address { AddressID = 2, Street = "Park Avenue", HouseNumber = "5", LocalNumber = "3", ZipCode = "54321" },
                new Address { AddressID = 3, Street = "Broadway", HouseNumber = "27", LocalNumber = "2", ZipCode = "67890" }
            );
        }

    }
}