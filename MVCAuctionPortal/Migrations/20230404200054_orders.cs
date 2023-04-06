using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
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

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 4, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4626), new DateTime(2023, 4, 11, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 4, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4666), new DateTime(2023, 4, 18, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4668) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 4, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4672), new DateTime(2023, 4, 25, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(4673) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 28, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                column: "RegistationDate",
                value: new DateTime(2023, 4, 1, 22, 0, 54, 142, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AuctionId",
                table: "OrderItems",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 1, 18, 18, 46, 508, DateTimeKind.Local).AddTicks(2562), new DateTime(2023, 4, 8, 18, 18, 46, 508, DateTimeKind.Local).AddTicks(2603) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 1, 18, 18, 46, 508, DateTimeKind.Local).AddTicks(2613), new DateTime(2023, 4, 15, 18, 18, 46, 508, DateTimeKind.Local).AddTicks(2616) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 1, 18, 18, 46, 508, DateTimeKind.Local).AddTicks(2619), new DateTime(2023, 4, 22, 18, 18, 46, 508, DateTimeKind.Local).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 25, 18, 18, 46, 508, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 29, 18, 18, 46, 508, DateTimeKind.Local).AddTicks(6138));
        }
    }
}
