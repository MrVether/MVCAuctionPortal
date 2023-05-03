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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
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
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    RegistationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        name: "FK_Users_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    AuctionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pieces = table.Column<int>(type: "int", nullable: false),
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
                name: "Coupon",
                columns: table => new
                {
                    CouponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfUses = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponID);
                    table.ForeignKey(
                        name: "FK_Coupon_Users_UserId",
                        column: x => x.UserId,
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
                table: "Category",
                columns: new[] { "CategoryID", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 1, "https://cdn.pixabay.com/photo/2016/03/27/19/43/smartphone-1283938_1280.jpg", "Electronics" },
                    { 2, "https://cdn.pixabay.com/photo/2016/11/29/03/53/architecture-1867187_1280.jpg", "Home and Garden" },
                    { 3, "https://cdn.pixabay.com/photo/2017/08/01/11/48/blue-2564660_1280.jpg", "Fashion" },
                    { 4, "https://www.waysideinsurance.com/wp-content/uploads/2019/12/184/shopping-tips-to-avoid-dangerous-toys.jpg", "Toys and Games" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyID", "CountryEstablishment", "DateOfEstablishment", "Description", "Name", "Nip", "Regon" },
                values: new object[,]
                {
                    { 1, "Poland", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the first example company.", "Example Company 1", "123-456-78-90", "123456789" },
                    { 2, "USA", new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the second example company.", "Example Company 2", "098-765-43-21", "122143289" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemID", "Condition", "Description", "Manufacturer", "Model", "Name", "Other" },
                values: new object[,]
                {
                    { 1, "Used", "Powerful Dell XPS 13 laptop with high-end specs", "Dell", "XPS 13", "Laptop", "Includes charger and carrying case" },
                    { 2, "New", "Brand new Samsung Galaxy S22 smartphone with great features", "Samsung", "Galaxy S22", "Smartphone", "Comes with original packaging and accessories" },
                    { 3, "Used", "Comfortable and stylish modern sofa", "IKEA", "KIVIK", "Sofa", "Some minor wear and tear" },
                    { 4, "New", "High-quality kitchen mixer for all your baking needs", "KitchenAid", "Stand Mixer", "Kitchen Mixer", "Comes with original packaging and accessories" },
                    { 5, "New", "Elegant and fashionable dress for special occasions", "Designer", "Evening Dress", "Elegant Dress", "Available in multiple sizes and colors" },
                    { 6, "New", "Elegant and fashionable Rolex Datejust 41 watch", "Rolex", "Datejust 41", "Stylish Watch", "Includes box and papers" },
                    { 7, "New", "Collectible LEGO Millennium Falcon set from the Star Wars series", "LEGO", "Millennium Falcon", "LEGO Star Wars Set", "Factory sealed" },
                    { 8, "Used", "Lightweight and fast Trek Domane SL 6 road bike", "Trek", "Domane SL 6", "Road Bike", "Recently serviced and in great condition" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "90c686bf-5c12-43d8-80d3-4b1da2ff7756", "Admin", "ADMIN" },
                    { 2, "036224a8-8acd-4250-937f-74569417d393", "User", "USER" },
                    { 3, "1b9e1a69-005b-4de1-9138-56059c84d138", "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "CompanyID", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistationDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, null, "70007488-670e-4628-8831-066a45e238f5", "johndoe@example.com", false, false, null, "John", null, null, null, null, false, new DateTime(2023, 4, 25, 13, 19, 34, 437, DateTimeKind.Local).AddTicks(8619), null, "Doe", false, null });

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
                table: "Basket",
                columns: new[] { "BasketID", "NumberOfItems", "SummaryPrice", "UserID" },
                values: new object[] { 1, 3, 50f, 1 });

            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "CouponID", "Description", "DiscountPercentage", "ExpireDate", "Name", "NumberOfUses", "UserId" },
                values: new object[,]
                {
                    { 1, "10% discount on your first purchase", 10, new DateTime(2023, 6, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(1036), "WELCOME10", 5, 1 },
                    { 2, "15% discount on your next purchase", 15, new DateTime(2023, 7, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(1043), "SPRING15", 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "SubCategoryID", "CategoryID", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 1, 1, "https://miro.medium.com/v2/resize:fit:928/1*SUK_D1dp3Acw1EjE1Cn6OA.png", "Laptops" },
                    { 2, 1, "https://cdn.pixabay.com/photo/2016/11/29/12/30/android-1869510_1280.jpg", "Smartphones" },
                    { 3, 2, "https://cdn.pixabay.com/photo/2016/11/18/17/20/living-room-1835923_1280.jpg", "Furniture" },
                    { 4, 2, "https://www.compliancegate.com/wp-content/uploads/2019/12/kitchen-appliances-safety-standards-eu.jpg", "Kitchen appliances" },
                    { 5, 3, "https://cdn.pixabay.com/photo/2017/08/01/08/29/people-2563491_1280.jpg", "Clothing" },
                    { 6, 3, "https://media.istockphoto.com/id/1181376840/photo/mock-up-blank-empty-digital-tablet-screen-on-beige-fashion-women-stylish-accessories-with-tag.jpg?s=612x612&w=0&k=20&c=AVOd71gDv5dRL9aic_9JmLyB0nvHkpSZ3uNkc9dl74o=", "Accessories" },
                    { 7, 4, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRuBnq8qmkvccgSwZhLaxEIn5KzJqWSfdm5ow&usqp=CAU", "Board games" },
                    { 8, 4, "https://cdn.vox-cdn.com/thumbor/VK3R_SzCKTnG4egaSIMpxewl7M4=/0x0:2040x1360/1400x1400/filters:focal(1020x680:1021x681)/cdn.vox-cdn.com/uploads/chorus_asset/file/22236383/acastro_210113_1777_gamingstock_0002.jpg", "Video games" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "CompanyID", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistationDate", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, 1, "1bb936c8-d2f0-4ac9-a232-77c1fd387e28", "janedoe@example.com", false, false, null, "Jane", null, null, null, null, false, new DateTime(2023, 4, 29, 13, 19, 34, 437, DateTimeKind.Local).AddTicks(8657), null, "Doe", false, null });

            migrationBuilder.InsertData(
                table: "Auction",
                columns: new[] { "AuctionID", "CategoryID", "DateOfIssue", "EndDate", "ImageURL", "ItemID", "Pieces", "Price", "SubCategoryID", "Title", "UserID", "WarrantyID" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 5, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(768), new DateTime(2023, 5, 9, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(780), "https://cdn.x-kom.pl/i/setup/images/prod/big/product-new-big,,2022/5/pr_2022_5_17_12_20_15_932_03.jpg", 1, 5, 1000m, 1, "Dell XPS 13", 2, 1 },
                    { 2, null, new DateTime(2023, 5, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(787), new DateTime(2023, 5, 9, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(789), "https://www.proshop.pl/Images/915x900/3031704_4e1eacc41047.jpg", 2, 3, 700m, 2, "Samsung Galaxy S22", 2, 2 },
                    { 3, null, new DateTime(2023, 5, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(791), new DateTime(2023, 5, 9, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(793), "https://umebluje.pl/41747-large_default/sofa-modern-25-grafitowa.jpg", 3, 1, 1200m, 3, "Modern Sofa", 2, 3 },
                    { 4, null, new DateTime(2023, 5, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(796), new DateTime(2023, 5, 9, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(797), "https://m.media-amazon.com/images/I/61anBuiHUhL.jpg", 4, 2, 150m, 4, "Kitchen Mixer", 2, 3 },
                    { 5, null, new DateTime(2023, 5, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(800), new DateTime(2023, 5, 9, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(801), "https://n.nordstrommedia.com/id/sr3/ec6af5bc-c712-478b-b2d8-3723257766be.jpeg?h=365&w=240&dpr=2", 5, 4, 80m, 5, "Elegant Dress", 2, 3 },
                    { 6, null, new DateTime(2023, 5, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(804), new DateTime(2023, 5, 9, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(805), "https://m.media-amazon.com/images/I/61+hXDh7oIL._AC_UY1000_.jpg", 6, 3, 250m, 6, "Stylish Watch", 2, 2 },
                    { 7, null, new DateTime(2023, 5, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(808), new DateTime(2023, 5, 9, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(809), "https://www.lego.com/cdn/cs/set/assets/blt847a7b38581ded36/75315.png", 7, 10, 100m, 7, "LEGO Star Wars Set", 2, 1 },
                    { 8, null, new DateTime(2023, 5, 2, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(812), new DateTime(2023, 5, 9, 13, 19, 34, 438, DateTimeKind.Local).AddTicks(813), "https://ibkbike.vtexassets.com/arquivos/ids/593348-1200-auto?v=638060623332200000&width=1200&height=auto&aspect=true", 8, 2, 850m, 8, "Road Bike", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "BasketID", "NumberOfItems", "SummaryPrice", "UserID" },
                values: new object[] { 2, 2, 15f, 2 });

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
                name: "IX_Coupon_UserId",
                table: "Coupon",
                column: "UserId");

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
                name: "IX_Users_CompanyID",
                table: "Users",
                column: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketAndAuctions");

            migrationBuilder.DropTable(
                name: "Coupon");

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
        }
    }
}
