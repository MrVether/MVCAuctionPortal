using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class addtot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercentage",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 23, 13, 36, 452, DateTimeKind.Local).AddTicks(3045), new DateTime(2023, 5, 1, 23, 13, 36, 452, DateTimeKind.Local).AddTicks(3079) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 23, 13, 36, 452, DateTimeKind.Local).AddTicks(3088), new DateTime(2023, 5, 8, 23, 13, 36, 452, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 23, 13, 36, 452, DateTimeKind.Local).AddTicks(3093), new DateTime(2023, 5, 15, 23, 13, 36, 452, DateTimeKind.Local).AddTicks(3096) });

            migrationBuilder.UpdateData(
                table: "Coupon",
                keyColumn: "CouponID",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2023, 5, 24, 23, 13, 36, 452, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Coupon",
                keyColumn: "CouponID",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2023, 6, 24, 23, 13, 36, 452, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "dd6b1aca-cce9-451b-b746-9bd95eda16fa");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3cc48986-020f-405b-a4d4-fc747afd0778");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1e056af0-bb65-4702-b384-10838120fc41");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistationDate" },
                values: new object[] { "f4138ce2-057f-4528-9fc6-67b5139212f6", new DateTime(2023, 4, 17, 23, 13, 36, 451, DateTimeKind.Local).AddTicks(9296) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistationDate" },
                values: new object[] { "2614112f-4005-4925-bfe3-0199b85a8ec7", new DateTime(2023, 4, 21, 23, 13, 36, 451, DateTimeKind.Local).AddTicks(9341) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercentage",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 1,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(6513), new DateTime(2023, 5, 1, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(6527) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 2,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(6535), new DateTime(2023, 5, 8, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(6537) });

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "AuctionID",
                keyValue: 3,
                columns: new[] { "DateOfIssue", "EndDate" },
                values: new object[] { new DateTime(2023, 4, 24, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(6540), new DateTime(2023, 5, 15, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(6542) });

            migrationBuilder.UpdateData(
                table: "Coupon",
                keyColumn: "CouponID",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2023, 5, 24, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "Coupon",
                keyColumn: "CouponID",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2023, 6, 24, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4deed80e-344e-49ac-bcce-f2208d7ea910");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d8b4fa1d-1030-4068-bbb9-2e16da662099");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a304d204-737d-445b-ac20-c14a251497f4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "RegistationDate" },
                values: new object[] { "8e251894-5719-4f78-b4a7-2a418c53dd1e", new DateTime(2023, 4, 17, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "RegistationDate" },
                values: new object[] { "fbfbc78b-601d-4d83-a44f-8bb549922e67", new DateTime(2023, 4, 21, 22, 42, 4, 542, DateTimeKind.Local).AddTicks(4250) });
        }
    }
}
