using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthApp.Migrations
{
    public partial class roleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efb0d386-80b6-4849-8d6f-3e4c7aab3c5f", "7813275f-ebe2-4828-88fd-39c001b096b4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d42f6608-3019-4ba1-963f-891eac149505", "b7b27653-06c6-4c3c-a5de-c1094bc8da1d", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d42f6608-3019-4ba1-963f-891eac149505");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efb0d386-80b6-4849-8d6f-3e4c7aab3c5f");
        }
    }
}
