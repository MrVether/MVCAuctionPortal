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
                    UserID = 1,
                    Name = "John",
                    Surname = "Doe",
                    Email = "johndoe@example.com",
                    Password = "password",
                    RegistationDate = DateTime.Now.AddDays(-7),
                    RoleID = 1,
                    CouponID = 1,
                    AddressID = 1,
                    CompanyID = null
                },
                new User
                {
                    UserID = 2,
                    Name = "Jane",
                    Surname = "Doe",
                    Email = "janedoe@example.com",
                    Password = "password",
                    RegistationDate = DateTime.Now.AddDays(-3),
                    RoleID = 2,
                    CouponID = null,
                    AddressID = 2,
                    CompanyID = 1
                }
            );
        }
    }
}
