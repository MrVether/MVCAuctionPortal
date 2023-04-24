using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class addtotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(4173), new DateTime(2023, 5, 1, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(4195), new DateTime(2023, 5, 8, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(4200), new DateTime(2023, 5, 15, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(4202) });

            migrationBuilder.UpdateData(
                table: "Coupon",
                keyColumn: "CouponID",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2023, 5, 24, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Coupon",
                keyColumn: "CouponID",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2023, 6, 24, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "caea9ac2-b1bb-4680-9de2-0a31100b036f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3f2bbf1c-f77e-49f6-a0dd-91cf086cb2a8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5b4edbbc-7932-4138-893f-d278e4b48f62");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistationDate" },
                values: new object[] { "32aafbb4-93d7-44cb-8206-b2756461283d", new DateTime(2023, 4, 17, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistationDate" },
                values: new object[] { "3bcc7aab-ddc3-44f6-8881-6cf4f2b84396", new DateTime(2023, 4, 21, 22, 6, 37, 597, DateTimeKind.Local).AddTicks(2206) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 21, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(2893), new DateTime(2023, 4, 28, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(2905) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 21, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(2916), new DateTime(2023, 5, 5, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(2918) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 21, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(2921), new DateTime(2023, 5, 12, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(2922) });

            migrationBuilder.UpdateData(
                table: "Coupon",
                keyColumn: "CouponID",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2023, 5, 21, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Coupon",
                keyColumn: "CouponID",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2023, 6, 21, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "92ea290d-063a-4b17-b411-874bdde1d35e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fa483a23-822c-474f-8de2-fdd6ad3e7de0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "33bfea3d-113c-4251-9c3c-6ad54a09072b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistationDate" },
                values: new object[] { "16cc088d-8ad4-49e8-a33a-6806e7822733", new DateTime(2023, 4, 14, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(38) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistationDate" },
                values: new object[] { "b8ec5191-f1a6-4f57-b271-fc8adc7e8dec", new DateTime(2023, 4, 18, 20, 5, 31, 8, DateTimeKind.Local).AddTicks(76) });
        }
    }
}
