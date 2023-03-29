using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class nullreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auction_Review_ReviewID",
                table: "Auction");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewID",
                table: "Auction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 3, 24, 21, 40, 9, 862, DateTimeKind.Local).AddTicks(4129), new DateTime(2023, 3, 31, 21, 40, 9, 862, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 3, 24, 21, 40, 9, 862, DateTimeKind.Local).AddTicks(4174), new DateTime(2023, 4, 7, 21, 40, 9, 862, DateTimeKind.Local).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 3, 24, 21, 40, 9, 862, DateTimeKind.Local).AddTicks(4179), new DateTime(2023, 4, 14, 21, 40, 9, 862, DateTimeKind.Local).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 17, 21, 40, 9, 862, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 21, 21, 40, 9, 862, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.AddForeignKey(
                name: "FK_Auction_Review_ReviewID",
                table: "Auction",
                column: "ReviewID",
                principalTable: "Review",
                principalColumn: "ReviewID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auction_Review_ReviewID",
                table: "Auction");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewID",
                table: "Auction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 3, 20, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5165), new DateTime(2023, 3, 27, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 3, 20, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5210), new DateTime(2023, 4, 3, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 3, 20, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5215), new DateTime(2023, 4, 10, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(5217) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 13, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 17, 17, 55, 48, 19, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.AddForeignKey(
                name: "FK_Auction_Review_ReviewID",
                table: "Auction",
                column: "ReviewID",
                principalTable: "Review",
                principalColumn: "ReviewID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
