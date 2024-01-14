using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellAndSwapGoodies.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "73188bc8-e2fb-41f7-912e-ca0d9d8ae38a", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIPi1XP0gQHp9XeWT0oukkIInV9Bx38Dl7WwYIUTeW2mGljo0V22lebnlw8xvLdWoQ==", null, false, "cefaab70-8b30-495a-9d19-7baa0bd7e6af", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4677), new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4691), "Electrical Appliances", "System" },
                    { 2, "System", new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4693), new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4694), "Clothing", "System" },
                    { 3, "System", new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4695), new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4696), "Watches", "System" },
                    { 4, "System", new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4697), new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4697), "Toys", "System" },
                    { 5, "System", new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4698), new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4699), "Cars", "System" },
                    { 6, "System", new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4700), new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4700), "Home Services", "System" },
                    { 7, "System", new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4701), new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4701), "Electronics", "System" },
                    { 8, "System", new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4702), new DateTime(2024, 1, 14, 21, 49, 26, 322, DateTimeKind.Local).AddTicks(4703), "Furniture", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
