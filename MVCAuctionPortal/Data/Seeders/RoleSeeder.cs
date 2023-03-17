using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AuctionPortal.Data.Seeders
{
    public class RoleSeeder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var roles = new List<Role>
            {
                new Role { RoleID = 1, Name = "Admin" },
                new Role { RoleID = 2, Name = "User" }
            };

            builder.HasData(roles);
        }
    }
}