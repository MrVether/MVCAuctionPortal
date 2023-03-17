using AuctionPortal.Data.Seeders;
using AuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using MVCAuctionPortal.Models;
using ServicesAndInterfacesLibary.Models;

namespace MVCAuctionPortal.Models
{
    public class AuctionDbContext : DbContext
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
        public DbSet<Role> Role { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Warranty> Warranty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressSeeder());
            modelBuilder.ApplyConfiguration(new AuctionSeeder());
            modelBuilder.ApplyConfiguration(new CategorySeeder());
            modelBuilder.ApplyConfiguration(new CompanySeeder());
            modelBuilder.ApplyConfiguration(new CouponSeeder());
            modelBuilder.ApplyConfiguration(new ItemSeeder());
            modelBuilder.ApplyConfiguration(new ReviewSeeder());
            modelBuilder.ApplyConfiguration(new RoleSeeder());
            modelBuilder.ApplyConfiguration(new SubCategorySeeder());
            modelBuilder.ApplyConfiguration(new UserSeeder());
            modelBuilder.ApplyConfiguration(new WarrantySeeder());
            modelBuilder.ApplyConfiguration(new BasketSeeder());
        }
    }

}
