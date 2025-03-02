using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2fe392f-4f60-4963-ba3a-ea52b71fb53e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55a652a6-c832-4b93-ab0b-e51ee54b6676", "AQAAAAIAAYagAAAAEMIkf3yt3OOZtCAG5G7Oz8UuL3exgzK/jrOtYAQIvMvFF4mtVCEiJMn7D2cx10JSyA==", "92b71f01-7fa2-4761-bee2-31d456142c8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4757375-a497-496b-85dc-a510027bd9b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81625884-7c64-44be-ab16-8d8e69d2381b", "AQAAAAIAAYagAAAAEEw0NRLO9NgIIZWaPMFCT8LyQBQC0j48ZdV8uHpaizo5QbqNfq1jniXtw02zF5hq8w==", "48d227ef-f949-433a-a3da-b6ceea1c5828" });

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 640, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 640, DateTimeKind.Utc).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7673));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 12, 8, 1, 554, DateTimeKind.Utc).AddTicks(7751));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2fe392f-4f60-4963-ba3a-ea52b71fb53e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad84efc8-4ac6-4139-bfae-b4dcf1da1888", "AQAAAAIAAYagAAAAEHbJ8QrjXQscxk7z/cQ1vy70LxR7ADV3EzE6dsJZ4qwK/wGO2gej/Ak69pq4ypMcIg==", "e555737f-dc15-4ff2-88d9-fe156a7ca89a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4757375-a497-496b-85dc-a510027bd9b1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0a312ea-d210-45f8-902b-108794371746", "AQAAAAIAAYagAAAAEAqwgk0uh1pLNuniumbyxWDKpVqfr6RxiPc+lfk/CtJB9eKlph/fZNSc+HfUXvFA9Q==", "12fff2b3-82d1-4d98-b8a7-510f4c9e54c8" });

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 866, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 866, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreateDate",
                value: new DateTime(2025, 2, 8, 7, 23, 9, 766, DateTimeKind.Utc).AddTicks(2284));
        }
    }
}
