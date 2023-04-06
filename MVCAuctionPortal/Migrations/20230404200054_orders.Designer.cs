﻿// <auto-generated />
using System;
using MVCAuctionPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    [Migration("20230404200054_orders")]
    partial class orders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuctionPortal.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            AddressID = 1,
                            HouseNumber = "10",
                            LocalNumber = "1",
                            Street = "Main Street",
                            ZipCode = "12345"
                        },
                        new
                        {
                            AddressID = 2,
                            HouseNumber = "5",
                            LocalNumber = "3",
                            Street = "Park Avenue",
                            ZipCode = "54321"
                        },
                        new
                        {
                            AddressID = 3,
                            HouseNumber = "27",
                            LocalNumber = "2",
                            Street = "Broadway",
                            ZipCode = "67890"
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.Auction", b =>
                {
                    b.Property<int>("AuctionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuctionID"));

                    b.Property<bool>("BuyItNow")
                        .HasColumnType("bit");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<int>("Pieces")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PurchaseCounter")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewID")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("WarrantyID")
                        .HasColumnType("int");

                    b.HasKey("AuctionID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ItemID");

                    b.HasIndex("ReviewID");

                    b.HasIndex("SubCategoryID");

                    b.HasIndex("UserID");

                    b.HasIndex("WarrantyID");

                    b.ToTable("Auction");

                    b.HasData(
                        new
                        {
                            AuctionID = 1,
                            BuyItNow = false,
                            DateOfIssue = new DateTime(2023, 4, 4, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4626),
                            EndDate = new DateTime(2023, 4, 11, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4658),
                            ImageURL = "https://m.media-amazon.com/images/I/71dpTXFz+dL._AC_UF1000,1000_QL80_.jpg",
                            ItemID = 1,
                            Pieces = 5,
                            Price = 100m,
                            PurchaseCounter = 0,
                            ReviewID = 1,
                            SubCategoryID = 1,
                            Title = "Iphone",
                            UserID = 2,
                            WarrantyID = 1
                        },
                        new
                        {
                            AuctionID = 2,
                            BuyItNow = true,
                            DateOfIssue = new DateTime(2023, 4, 4, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4666),
                            EndDate = new DateTime(2023, 4, 18, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4668),
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            ItemID = 2,
                            Pieces = 3,
                            Price = 200m,
                            PurchaseCounter = 0,
                            ReviewID = 2,
                            SubCategoryID = 2,
                            Title = "Shovel",
                            UserID = 2,
                            WarrantyID = 2
                        },
                        new
                        {
                            AuctionID = 3,
                            BuyItNow = false,
                            DateOfIssue = new DateTime(2023, 4, 4, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4672),
                            EndDate = new DateTime(2023, 4, 25, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4673),
                            ImageURL = "https://a.allegroimg.com/original/1e76f9/ba5267f249a8bb358f5d3cf50ec6",
                            ItemID = 3,
                            Pieces = 1,
                            Price = 300m,
                            PurchaseCounter = 0,
                            ReviewID = 3,
                            SubCategoryID = 3,
                            Title = "Boots",
                            UserID = 2,
                            WarrantyID = 3
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyID"));

                    b.Property<int>("CompanyAddressID")
                        .HasColumnType("int");

                    b.Property<string>("CountryEstablishment")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DateOfEstablishment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Regon")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CompanyID");

                    b.HasIndex("CompanyAddressID");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            CompanyID = 1,
                            CompanyAddressID = 1,
                            CountryEstablishment = "Poland",
                            DateOfEstablishment = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This is the first example company.",
                            Name = "Example Company 1",
                            Nip = "123-456-78-90",
                            Regon = "123456789"
                        },
                        new
                        {
                            CompanyID = 2,
                            CompanyAddressID = 2,
                            CountryEstablishment = "USA",
                            DateOfEstablishment = new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "This is the second example company.",
                            Name = "Example Company 2",
                            Nip = "098-765-43-21",
                            Regon = "122143289"
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.Coupon", b =>
                {
                    b.Property<int>("CouponID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("NumberOfUses")
                        .HasColumnType("int");

                    b.HasKey("CouponID");

                    b.ToTable("Coupon");

                    b.HasData(
                        new
                        {
                            CouponID = 1,
                            Description = "10% off",
                            ExpireDate = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "SALE10",
                            NumberOfUses = 100
                        },
                        new
                        {
                            CouponID = 2,
                            Description = "20% off",
                            ExpireDate = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "SALE20",
                            NumberOfUses = 50
                        },
                        new
                        {
                            CouponID = 3,
                            Description = "30% off",
                            ExpireDate = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "SALE30",
                            NumberOfUses = 25
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Other")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ItemID");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            ItemID = 1,
                            Condition = "New",
                            Description = "Brand new smartphone with great features",
                            Manufacturer = "Samsung",
                            Model = "Galaxy S21",
                            Name = "Smartphone",
                            Other = "Comes with original packaging and accessories"
                        },
                        new
                        {
                            ItemID = 2,
                            Condition = "Used",
                            Description = "Powerful laptop with high-end specs",
                            Manufacturer = "Dell",
                            Model = "XPS 13",
                            Name = "Laptop",
                            Other = "Includes charger and carrying case"
                        },
                        new
                        {
                            ItemID = 3,
                            Condition = "Like new",
                            Description = "Wireless noise-cancelling headphones",
                            Manufacturer = "Sony",
                            Model = "WH-1000XM4",
                            Name = "Headphones",
                            Other = "Comes with charging cable and carrying case"
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AuctionPortal.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("AuctionId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("AuctionPortal.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewID");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            ReviewID = 1,
                            Description = "I had a very positive experience with this seller. The item arrived quickly and was exactly as described.",
                            Title = "Great seller"
                        },
                        new
                        {
                            ReviewID = 2,
                            Description = "I purchased this product and it exceeded my expectations. The quality was great and it worked perfectly.",
                            Title = "Excellent product"
                        },
                        new
                        {
                            ReviewID = 3,
                            Description = "The item was shipped quickly and arrived in perfect condition. I would definitely buy from this seller again.",
                            Title = "Fast shipping"
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryID"));

                    b.Property<int?>("CategoryID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("SubCategory");

                    b.HasData(
                        new
                        {
                            SubCategoryID = 1,
                            CategoryID = 1,
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            Name = "Laptops"
                        },
                        new
                        {
                            SubCategoryID = 2,
                            CategoryID = 1,
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            Name = "Smartphones"
                        },
                        new
                        {
                            SubCategoryID = 3,
                            CategoryID = 2,
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            Name = "Furniture"
                        },
                        new
                        {
                            SubCategoryID = 4,
                            CategoryID = 2,
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            Name = "Kitchen appliances"
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<int>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyID")
                        .HasColumnType("int");

                    b.Property<int?>("CouponID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Nip")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("AddressID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("CouponID");

                    b.HasIndex("RoleID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            AddressID = 1,
                            CouponID = 1,
                            Email = "johndoe@example.com",
                            Name = "John",
                            Password = "password",
                            RegistationDate = new DateTime(2023, 3, 28, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(7036),
                            RoleID = 1,
                            Surname = "Doe"
                        },
                        new
                        {
                            UserID = 2,
                            AddressID = 2,
                            CompanyID = 1,
                            Email = "janedoe@example.com",
                            Name = "Jane",
                            Password = "password",
                            RegistationDate = new DateTime(2023, 4, 1, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(7055),
                            RoleID = 2,
                            Surname = "Doe"
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.Warranty", b =>
                {
                    b.Property<int>("WarrantyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarrantyID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Durantion")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarrantyID");

                    b.ToTable("Warranty");

                    b.HasData(
                        new
                        {
                            WarrantyID = 1,
                            Description = "Basic warranty for 1 year.",
                            Durantion = 12,
                            Name = "Basic"
                        },
                        new
                        {
                            WarrantyID = 2,
                            Description = "Extended warranty for 2 years.",
                            Durantion = 24,
                            Name = "Extended"
                        },
                        new
                        {
                            WarrantyID = 3,
                            Description = "Premium warranty for 3 years.",
                            Durantion = 36,
                            Name = "Premium"
                        });
                });

            modelBuilder.Entity("MVCAuctionPortal.Models.Basket", b =>
                {
                    b.Property<int>("BasketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BasketID"));

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<float>("SummaryPrice")
                        .HasColumnType("real");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BasketID");

                    b.HasIndex("UserID");

                    b.ToTable("Basket");

                    b.HasData(
                        new
                        {
                            BasketID = 1,
                            NumberOfItems = 2,
                            SummaryPrice = 50f,
                            UserID = 1
                        },
                        new
                        {
                            BasketID = 2,
                            NumberOfItems = 1,
                            SummaryPrice = 15f,
                            UserID = 2
                        });
                });

            modelBuilder.Entity("MVCAuctionPortal.Models.BasketAndAuction", b =>
                {
                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Selected")
                        .HasColumnType("bit");

                    b.HasKey("AuctionId", "BasketId");

                    b.HasIndex("BasketId");

                    b.ToTable("BasketAndAuctions", (string)null);
                });

            modelBuilder.Entity("MVCAuctionPortal.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            Name = "Electronics"
                        },
                        new
                        {
                            CategoryID = 2,
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            Name = "Home and Garden"
                        },
                        new
                        {
                            CategoryID = 3,
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            Name = "Fashion"
                        },
                        new
                        {
                            CategoryID = 4,
                            ImageURL = "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg",
                            Name = "Toys and Games"
                        });
                });

            modelBuilder.Entity("AuctionPortal.Models.Auction", b =>
                {
                    b.HasOne("MVCAuctionPortal.Models.Category", null)
                        .WithMany("Auctions")
                        .HasForeignKey("CategoryID");

                    b.HasOne("AuctionPortal.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionPortal.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewID");

                    b.HasOne("AuctionPortal.Models.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionPortal.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionPortal.Models.Warranty", "Warranty")
                        .WithMany()
                        .HasForeignKey("WarrantyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Review");

                    b.Navigation("SubCategory");

                    b.Navigation("User");

                    b.Navigation("Warranty");
                });

            modelBuilder.Entity("AuctionPortal.Models.Company", b =>
                {
                    b.HasOne("AuctionPortal.Models.Address", "CompanyAddress")
                        .WithMany()
                        .HasForeignKey("CompanyAddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyAddress");
                });

            modelBuilder.Entity("AuctionPortal.Models.OrderItem", b =>
                {
                    b.HasOne("AuctionPortal.Models.Auction", "Auction")
                        .WithMany()
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionPortal.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("AuctionPortal.Models.SubCategory", b =>
                {
                    b.HasOne("MVCAuctionPortal.Models.Category", "Categories")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("AuctionPortal.Models.User", b =>
                {
                    b.HasOne("AuctionPortal.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionPortal.Models.Company", "Companies")
                        .WithMany()
                        .HasForeignKey("CompanyID");

                    b.HasOne("AuctionPortal.Models.Coupon", "Coupons")
                        .WithMany()
                        .HasForeignKey("CouponID");

                    b.HasOne("AuctionPortal.Models.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Companies");

                    b.Navigation("Coupons");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("MVCAuctionPortal.Models.Basket", b =>
                {
                    b.HasOne("AuctionPortal.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MVCAuctionPortal.Models.BasketAndAuction", b =>
                {
                    b.HasOne("AuctionPortal.Models.Auction", "Auction")
                        .WithMany("BasketAndAuctions")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MVCAuctionPortal.Models.Basket", "Basket")
                        .WithMany("BasketAndAuctions")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("Basket");
                });

            modelBuilder.Entity("AuctionPortal.Models.Auction", b =>
                {
                    b.Navigation("BasketAndAuctions");
                });

            modelBuilder.Entity("AuctionPortal.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MVCAuctionPortal.Models.Basket", b =>
                {
                    b.Navigation("BasketAndAuctions");
                });

            modelBuilder.Entity("MVCAuctionPortal.Models.Category", b =>
                {
                    b.Navigation("Auctions");

                    b.Navigation("SubCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
