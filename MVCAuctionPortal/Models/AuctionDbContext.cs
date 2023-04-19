using AuctionPortal.Data.Seeders;
using AuctionPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCAuctionPortal.Models
{
    public class AuctionDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Auction> Auction { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Warranty> Warranty { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<BasketAndAuction> BasketAndAuctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketAndAuction>(entity =>
            {
                entity.HasKey(ba => new { ba.AuctionId, ba.BasketId });
                entity.ToTable("BasketAndAuctions");

                entity.HasOne(ba => ba.Basket)
                    .WithMany(b => b.BasketAndAuctions)
                    .HasForeignKey(ba => ba.BasketId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(ba => ba.Auction)
                    .WithMany(a => a.BasketAndAuctions)
                    .HasForeignKey(ba => ba.AuctionId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(r => new { r.UserId, r.RoleId });
            modelBuilder.Entity<IdentityUserToken<int>>()
                .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(new IdentityRoleSeeder());
            modelBuilder.ApplyConfiguration(new UserSeeder());
            modelBuilder.ApplyConfiguration(new AddressSeeder());
            modelBuilder.ApplyConfiguration(new CompanySeeder());
            modelBuilder.ApplyConfiguration(new CategorySeeder());
            modelBuilder.ApplyConfiguration(new SubCategorySeeder());
            modelBuilder.ApplyConfiguration(new WarrantySeeder());
            modelBuilder.ApplyConfiguration(new ItemSeeder());
            modelBuilder.ApplyConfiguration(new AuctionSeeder());
            modelBuilder.ApplyConfiguration(new ReviewSeeder());
            modelBuilder.ApplyConfiguration(new BasketSeeder());
            modelBuilder.ApplyConfiguration(new CouponSeeder());
        }
    }
}
