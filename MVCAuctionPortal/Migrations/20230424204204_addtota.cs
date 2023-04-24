using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCAuctionPortal.Migrations
{
    /// <inheritdoc />
    public partial class addtota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Orders");

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
    }
}
