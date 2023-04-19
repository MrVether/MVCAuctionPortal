using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    CouponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfUses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Other = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Warranty",
                columns: table => new
                {
                    WarrantyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durantion = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranty", x => x.WarrantyID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Regon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CountryEstablishment = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Company_Address_CompanyAddressID",
                        column: x => x.CompanyAddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    SubCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.SubCategoryID);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nip = table.Column<int>(type: "int", nullable: true),
                    RegistationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CouponID = table.Column<int>(type: "int", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_Users_Coupon_CouponID",
                        column: x => x.CouponID,
                        principalTable: "Coupon",
                        principalColumn: "CouponID");
                });

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    AuctionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyItNow = table.Column<bool>(type: "bit", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pieces = table.Column<int>(type: "int", nullable: false),
                    PurchaseCounter = table.Column<int>(type: "int", nullable: false),
                    SubCategoryID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    WarrantyID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.AuctionID);
                    table.ForeignKey(
                        name: "FK_Auction_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_Auction_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_SubCategory_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategory",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_Warranty_WarrantyID",
                        column: x => x.WarrantyID,
                        principalTable: "Warranty",
                        principalColumn: "WarrantyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    BasketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    SummaryPrice = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.BasketID);
                    table.ForeignKey(
                        name: "FK_Basket_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Auction_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auction",
                        principalColumn: "AuctionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPositive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Auction_AuctionID",
                        column: x => x.AuctionID,
                        principalTable: "Auction",
                        principalColumn: "AuctionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasketAndAuctions",
                columns: table => new
                {
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    Selected = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketAndAuctions", x => new { x.AuctionId, x.BasketId });
                    table.ForeignKey(
                        name: "FK_BasketAndAuctions_Auction_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auction",
                        principalColumn: "AuctionID");
                    table.ForeignKey(
                        name: "FK_BasketAndAuctions_Basket_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Basket",
                        principalColumn: "BasketID");
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressID", "HouseNumber", "LocalNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "10", "1", "Main Street", "12345" },
                    { 2, "5", "3", "Park Avenue", "54321" },
                    { 3, "27", "2", "Broadway", "67890" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 1, "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", "Electronics" },
                    { 2, "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", "Home and Garden" },
                    { 3, "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", "Fashion" },
                    { 4, "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", "Toys and Games" }
                });

            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "CouponID", "Description", "ExpireDate", "Name", "NumberOfUses" },
                values: new object[,]
                {
                    { 1, "10% off", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SALE10", 100 },
                    { 2, "20% off", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SALE20", 50 },
                    { 3, "30% off", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SALE30", 25 }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemID", "Condition", "Description", "Manufacturer", "Model", "Name", "Other" },
                values: new object[,]
                {
                    { 1, "New", "Brand new smartphone with great features", "Samsung", "Galaxy S21", "Smartphone", "Comes with original packaging and accessories" },
                    { 2, "Used", "Powerful laptop with high-end specs", "Dell", "XPS 13", "Laptop", "Includes charger and carrying case" },
                    { 3, "Like new", "Wireless noise-cancelling headphones", "Sony", "WH-1000XM4", "Headphones", "Comes with charging cable and carrying case" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "7623fbdf-933d-4838-9b2a-2a1a75f510d9", "Admin", "ADMIN" },
                    { 2, "1cc37411-960c-4ab7-8883-4449a8568ec3", "User", "USER" },
                    { 3, "850ea983-8cb1-4b18-aef8-01fc1ec45328", "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "Warranty",
                columns: new[] { "WarrantyID", "Description", "Durantion", "Name" },
                values: new object[,]
                {
                    { 1, "Basic warranty for 1 year.", 12, "Basic" },
                    { 2, "Extended warranty for 2 years.", 24, "Extended" },
                    { 3, "Premium warranty for 3 years.", 36, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyID", "CompanyAddressID", "CountryEstablishment", "DateOfEstablishment", "Description", "Name", "Nip", "Regon" },
                values: new object[,]
                {
                    { 1, 1, "Poland", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the first example company.", "Example Company 1", "123-456-78-90", "123456789" },
                    { 2, 2, "USA", new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the second example company.", "Example Company 2", "098-765-43-21", "122143289" }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "SubCategoryID", "CategoryID", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 1, 1, "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", "Laptops" },
                    { 2, 1, "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", "Smartphones" },
                    { 3, 2, "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", "Furniture" },
                    { 4, 2, "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", "Kitchen appliances" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AddressID", "CompanyID", "ConcurrencyStamp", "CouponID", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "Nip", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistationDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, 1, null, "ef578bfc-42bd-43f4-840b-20c7e6a2159d", 1, "johndoe@example.com", false, false, null, "John", 0, null, null, null, null, false, new DateTime(2023, 4, 12, 22, 24, 7, 159, DateTimeKind.Local).AddTicks(3984), null, "Doe", false, null });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "BasketID", "NumberOfItems", "SummaryPrice", "UserID" },
                values: new object[] { 1, 2, 50f, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AddressID", "CompanyID", "ConcurrencyStamp", "CouponID", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "Nip", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistationDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, 2, 1, "dbe9b105-c584-4388-96a9-41610e7a252c", null, "janedoe@example.com", false, false, null, "Jane", 0, null, null, null, null, false, new DateTime(2023, 4, 16, 22, 24, 7, 159, DateTimeKind.Local).AddTicks(4028), null, "Doe", false, null });

            migrationBuilder.InsertData(
                table: "Auction",
                columns: new[] { "AuctionID", "BuyItNow", "CategoryID", "DateOfIssue", "EndDate", "ImageURL", "ItemID", "Pieces", "Price", "PurchaseCounter", "SubCategoryID", "Title", "UserID", "WarrantyID" },
                values: new object[,]
                {
                    { 1, false, null, new DateTime(2023, 4, 19, 22, 24, 7, 159, DateTimeKind.Local).AddTicks(7121), new DateTime(2023, 4, 26, 22, 24, 7, 159, DateTimeKind.Local).AddTicks(7159), "https://m.media-amazon.com/images/I/71dpTXFz+dL._AC_UF1000,1000_QL80_.jpg", 1, 5, 100m, 0, 1, "Iphone", 2, 1 },
                    { 2, true, null, new DateTime(2023, 4, 19, 22, 24, 7, 159, DateTimeKind.Local).AddTicks(7203), new DateTime(2023, 5, 3, 22, 24, 7, 159, DateTimeKind.Local).AddTicks(7205), "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", 2, 3, 200m, 0, 2, "Shovel", 2, 2 },
                    { 3, false, null, new DateTime(2023, 4, 19, 22, 24, 7, 159, DateTimeKind.Local).AddTicks(7216), new DateTime(2023, 5, 10, 22, 24, 7, 159, DateTimeKind.Local).AddTicks(7219), "https://a.allegroimg.com/original/1e76f9/ba5267f249a8bb358f5d3cf50ec6", 3, 1, 300m, 0, 3, "Boots", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "BasketID", "NumberOfItems", "SummaryPrice", "UserID" },
                values: new object[] { 2, 1, 15f, 2 });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewID", "AuctionID", "Description", "IsPositive", "Title", "UserID" },
                values: new object[,]
                {
                    { 1, 1, "I had a very positive experience with this seller. The item arrived quickly and was exactly as described.", true, "Great seller", 1 },
                    { 2, 2, "I purchased this product and it exceeded my expectations. The quality was great and it worked perfectly.", true, "Excellent product", 1 },
                    { 3, 3, "The item was shipped quickly and arrived in perfect condition. I would definitely buy from this seller again.", true, "Fast shipping", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auction_CategoryID",
                table: "Auction",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_ItemID",
                table: "Auction",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_SubCategoryID",
                table: "Auction",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_UserID",
                table: "Auction",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_WarrantyID",
                table: "Auction",
                column: "WarrantyID");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_UserID",
                table: "Basket",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketAndAuctions_BasketId",
                table: "BasketAndAuctions",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyAddressID",
                table: "Company",
                column: "CompanyAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AuctionId",
                table: "OrderItems",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_AuctionID",
                table: "Review",
                column: "AuctionID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserID",
                table: "Review",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryID",
                table: "SubCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressID",
                table: "Users",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyID",
                table: "Users",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CouponID",
                table: "Users",
                column: "CouponID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketAndAuctions");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Warranty");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
