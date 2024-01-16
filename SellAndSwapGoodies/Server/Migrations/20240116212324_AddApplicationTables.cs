using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellAndSwapGoodies.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24da8b8c-d110-4f7d-bc49-b8768916797e", "AQAAAAIAAYagAAAAEM5xybUTnuuwPWo1QtGB6f02BvqhW8F7l89dyJepMFHXK/N9K3W3XsVahXGZSMwHTg==", "2ac82350-5ac5-4b5b-8184-c8b3fef03f57" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7372b4a-0194-4c0a-8653-58d228468829", "AQAAAAIAAYagAAAAENqBeZx/IackZQjcETAGuHQNTWVJZAOm05obNkRBpi+8trzjROS6AXlGq/tMECOIuA==", "73d7d3e2-95b4-42a4-9df1-7ec20b609987" });
        }
    }
}
