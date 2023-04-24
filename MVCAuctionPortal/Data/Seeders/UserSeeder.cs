using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionPortal.Data.Seeders
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Seed some users
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Doe",
                    Email = "johndoe@example.com",
                    RegistationDate = DateTime.Now.AddDays(-7),
                    AddressID = 1,
                    CompanyID = null
                },
                new User
                {
                    Id = 2,
                    Name = "Jane",
                    Surname = "Doe",
                    Email = "janedoe@example.com",
                    RegistationDate = DateTime.Now.AddDays(-3),
                    AddressID = 2,
                    CompanyID = 1
                }
            );
        }
    }
}