using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class shipaddresss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "Orders",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocalNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LocalNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Orders",
                newName: "ShippingAddress");

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
        }
    }
}
