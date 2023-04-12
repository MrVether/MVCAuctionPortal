using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class nullpmethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 11, 20, 10, 48, 938, DateTimeKind.Local).AddTicks(6322), new DateTime(2023, 4, 18, 20, 10, 48, 938, DateTimeKind.Local).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 11, 20, 10, 48, 938, DateTimeKind.Local).AddTicks(6367), new DateTime(2023, 4, 25, 20, 10, 48, 938, DateTimeKind.Local).AddTicks(6369) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 11, 20, 10, 48, 938, DateTimeKind.Local).AddTicks(6372), new DateTime(2023, 5, 2, 20, 10, 48, 938, DateTimeKind.Local).AddTicks(6374) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "RegistationDate",
                value: new DateTime(2023, 4, 4, 20, 10, 48, 938, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2,
                column: "RegistationDate",
                value: new DateTime(2023, 4, 8, 20, 10, 48, 938, DateTimeKind.Local).AddTicks(8960));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
