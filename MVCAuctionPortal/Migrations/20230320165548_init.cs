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
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
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
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nip = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CouponID = table.Column<int>(type: "int", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_User_Coupon_CouponID",
                        column: x => x.CouponID,
                        principalTable: "Coupon",
                        principalColumn: "CouponID");
                    table.ForeignKey(
                        name: "FK_User_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
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
                        name: "FK_Basket_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
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
                    ReviewID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasketID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.AuctionID);
                    table.ForeignKey(
                        name: "FK_Auction_Basket_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Basket",
                        principalColumn: "BasketID");
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
                        name: "FK_Auction_Review_ReviewID",
                        column: x => x.ReviewID,
                        principalTable: "Review",
                        principalColumn: "ReviewID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_SubCategory_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategory",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_Warranty_WarrantyID",
                        column: x => x.WarrantyID,
                        principalTable: "Warranty",
                        principalColumn: "WarrantyID",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Review",
                columns: new[] { "ReviewID", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "I had a very positive experience with this seller. The item arrived quickly and was exactly as described.", "Great seller" },
                    { 2, "I purchased this product and it exceeded my expectations. The quality was great and it worked perfectly.", "Excellent product" },
                    { 3, "The item was shipped quickly and arrived in perfect condition. I would definitely buy from this seller again.", "Fast shipping" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
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
                table: "User",
                columns: new[] { "UserID", "AddressID", "CompanyID", "CouponID", "Email", "Name", "Nip", "Password", "RegistationDate", "RoleID", "Surname" },
                values: new object[] { 1, 1, null, 1, "johndoe@example.com", "John", null, "password", new DateTime(2023, 3, 13, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(7754), 1, "Doe" });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "BasketID", "NumberOfItems", "SummaryPrice", "UserID" },
                values: new object[] { 1, 2, 50f, 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "AddressID", "CompanyID", "CouponID", "Email", "Name", "Nip", "Password", "RegistationDate", "RoleID", "Surname" },
                values: new object[] { 2, 2, 1, null, "janedoe@example.com", "Jane", null, "password", new DateTime(2023, 3, 17, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(7770), 2, "Doe" });

            migrationBuilder.InsertData(
                table: "Auction",
                columns: new[] { "AuctionID", "BasketID", "BuyItNow", "CategoryID", "DateOfIssue", "EndDate", "ImageURL", "ItemID", "Pieces", "Price", "PurchaseCounter", "ReviewID", "SubCategoryID", "Title", "UserID", "WarrantyID" },
                values: new object[,]
                {
                    { 1, null, false, null, new DateTime(2023, 3, 20, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5165), new DateTime(2023, 3, 27, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5201), "https://m.media-amazon.com/images/I/71dpTXFz+dL._AC_UF1000,1000_QL80_.jpg", 1, 5, 100m, 0, 1, 1, "Iphone", 2, 1 },
                    { 2, null, true, null, new DateTime(2023, 3, 20, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5210), new DateTime(2023, 4, 3, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5212), "https://grube.pl/wp-content/uploads/2017/07/product-135.jpg", 2, 3, 200m, 0, 2, 2, "Shovel", 2, 2 },
                    { 3, null, false, null, new DateTime(2023, 3, 20, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5215), new DateTime(2023, 4, 10, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5217), "https://a.allegroimg.com/original/1e76f9/ba5267f249a8bb358f5d3cf50ec6", 3, 1, 300m, 0, 3, 3, "Boots", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "BasketID", "NumberOfItems", "SummaryPrice", "UserID" },
                values: new object[] { 2, 1, 15f, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Auction_BasketID",
                table: "Auction",
                column: "BasketID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_CategoryID",
                table: "Auction",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_ItemID",
                table: "Auction",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_ReviewID",
                table: "Auction",
                column: "ReviewID");

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
                name: "IX_Company_CompanyAddressID",
                table: "Company",
                column: "CompanyAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryID",
                table: "SubCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressID",
                table: "User",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyID",
                table: "User",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CouponID",
                table: "User",
                column: "CouponID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Warranty");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
