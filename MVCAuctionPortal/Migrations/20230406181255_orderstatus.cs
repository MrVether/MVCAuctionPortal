using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class orderstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 6, 20, 12, 55, 629, DateTimeKind.Local).AddTicks(8497), new DateTime(2023, 4, 13, 20, 12, 55, 629, DateTimeKind.Local).AddTicks(8532) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 6, 20, 12, 55, 629, DateTimeKind.Local).AddTicks(8541), new DateTime(2023, 4, 20, 20, 12, 55, 629, DateTimeKind.Local).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 6, 20, 12, 55, 629, DateTimeKind.Local).AddTicks(8547), new DateTime(2023, 4, 27, 20, 12, 55, 629, DateTimeKind.Local).AddTicks(8548) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 30, 20, 12, 55, 630, DateTimeKind.Local).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                column: "RegistationDate",
                value: new DateTime(2023, 4, 3, 20, 12, 55, 630, DateTimeKind.Local).AddTicks(1580));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 4, 23, 3, 53, 349, DateTimeKind.Local).AddTicks(6718), new DateTime(2023, 4, 11, 23, 3, 53, 349, DateTimeKind.Local).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 4, 23, 3, 53, 349, DateTimeKind.Local).AddTicks(6759), new DateTime(2023, 4, 18, 23, 3, 53, 349, DateTimeKind.Local).AddTicks(6761) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 4, 23, 3, 53, 349, DateTimeKind.Local).AddTicks(6764), new DateTime(2023, 4, 25, 23, 3, 53, 349, DateTimeKind.Local).AddTicks(6766) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "RegistationDate",
                value: new DateTime(2023, 3, 28, 23, 3, 53, 349, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                column: "RegistationDate",
                value: new DateTime(2023, 4, 1, 23, 3, 53, 349, DateTimeKind.Local).AddTicks(8825));
        }
    }
}
