using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthApp.Migrations
{
    public partial class buildingcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfFloors = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1c94e4a-2b1b-47e0-93d5-5bb3705cafb6", "1ff0b885-fba6-4811-9e42-57336f3a5a4e", "Admin", "ADMIN" },
                    { "40165f92-4b41-4b7b-9e1f-ebc94c7650d4", "e5986b3f-1221-4b88-a6ee-0848098d6d3a", "User", "USER" },
                    { "f5ba02a5-6806-4ffc-aa52-78cd143ccaee", "a01e8c1c-36cd-494d-9aa6-8b203b8d14e2", "Property-Administrator", "PROPERTY-ADMINISTRATOR" },
                    { "9b239f34-5482-42be-930c-963c071c6507", "64a1cbc6-5c85-48f4-8d3e-cc833a184e38", "Caretaker", "CARETAKER" },
                    { "fe6f9978-e5b1-4b98-a327-f8d8490c5cb5", "d55bd918-af84-4e09-8a1d-f3b2e208565e", "Landlord", "LANDLORD" },
                    { "2c1404e5-d944-4533-914e-5ef97efcd6da", "9d8e85d8-805a-46f9-b6c6-144673d093f3", "Access-control", "ACCESS-CONTROL" },
                    { "8b67c20a-8fc2-4162-b4aa-cff2b95fa37d", "d5befb54-b895-487e-8f1a-b3b23619d4d0", "Tenant", "TENANT" },
                    { "463be5bb-1280-472f-b055-701c70b10a6f", "bb3ea6c2-3a10-4cec-9893-eff4e677296d", "Visitor", "VISITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c1404e5-d944-4533-914e-5ef97efcd6da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40165f92-4b41-4b7b-9e1f-ebc94c7650d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463be5bb-1280-472f-b055-701c70b10a6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b67c20a-8fc2-4162-b4aa-cff2b95fa37d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b239f34-5482-42be-930c-963c071c6507");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1c94e4a-2b1b-47e0-93d5-5bb3705cafb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5ba02a5-6806-4ffc-aa52-78cd143ccaee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe6f9978-e5b1-4b98-a327-f8d8490c5cb5");

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
    }
}
