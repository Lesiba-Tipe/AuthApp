using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthApp.Migrations
{
    public partial class apartmentroleconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d42f6608-3019-4ba1-963f-891eac149505");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efb0d386-80b6-4849-8d6f-3e4c7aab3c5f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ee1eef96-8f97-4e41-8536-740fb3ec634c", "9b1c1bef-831a-4372-b51a-4b66aedd8af1", "Admin", "ADMIN" },
                    { "814a69bf-37d7-4227-9a62-1ae5cfb82006", "18d3d39f-b54c-4c05-9e71-63d618a86d67", "User", "USER" },
                    { "b57357ba-6c0a-4617-a8e4-a7236179423c", "e9fe7781-4f42-4290-b63b-34464becb894", "Property-Administrator", "PROPERTY-ADMINISTRATOR" },
                    { "a299fb20-1d5b-4f17-9f9b-f520d99d8650", "b6590757-4c83-4b04-b8b6-01f9f0cb236f", "Caretaker", "CARETAKER" },
                    { "c83fefba-fe66-4df8-9f51-58d970e687dd", "63b0747a-7480-4ea0-bfea-a73bebb18e6e", "Landlord", "LANDLORD" },
                    { "bb0e34e3-6076-41df-9899-3491010bab0f", "5b483a99-46d6-4a5c-8fe9-e4ba7d4e8ad2", "Access-control", "ACCESS-CONTROL" },
                    { "12c8a72a-ad06-4a38-9f95-34b6d033a40c", "c011c5a8-28c7-454a-9aee-40e19cf10827", "Tenant", "TENANT" },
                    { "6e943fef-8563-4aeb-a9ac-6baa5fa8015d", "5e694e9c-5ee2-48bf-8bc3-7c5b37f182bb", "Visitor", "VISITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12c8a72a-ad06-4a38-9f95-34b6d033a40c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e943fef-8563-4aeb-a9ac-6baa5fa8015d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "814a69bf-37d7-4227-9a62-1ae5cfb82006");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a299fb20-1d5b-4f17-9f9b-f520d99d8650");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b57357ba-6c0a-4617-a8e4-a7236179423c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb0e34e3-6076-41df-9899-3491010bab0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c83fefba-fe66-4df8-9f51-58d970e687dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee1eef96-8f97-4e41-8536-740fb3ec634c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efb0d386-80b6-4849-8d6f-3e4c7aab3c5f", "7813275f-ebe2-4828-88fd-39c001b096b4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d42f6608-3019-4ba1-963f-891eac149505", "b7b27653-06c6-4c3c-a5de-c1094bc8da1d", "User", "USER" });
        }
    }
}
