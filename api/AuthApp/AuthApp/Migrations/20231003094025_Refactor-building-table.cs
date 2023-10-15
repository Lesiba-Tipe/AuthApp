using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthApp.Migrations
{
    public partial class Refactorbuildingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "PropertyCode",
                table: "Buildings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d7f4c2c-ced4-49d3-8f41-529db7225dd9", "09882b4c-2a29-4121-a6a2-e2e46dbfa826", "Admin", "ADMIN" },
                    { "224c6ac9-e883-4775-a8ab-58d87349a3b1", "a84e3141-9889-4a7c-9eb4-afba74ddb184", "User", "USER" },
                    { "bca2704a-a806-496b-b731-cc2343ac2379", "1b093803-9ff5-4b3e-add0-767114a80ec1", "Property-Administrator", "PROPERTY-ADMINISTRATOR" },
                    { "a8b8d91c-0af5-4b71-bbc2-1c57e07be8ab", "d12de407-12b9-4aad-8911-dfc6d506b617", "Caretaker", "CARETAKER" },
                    { "84c28eb8-b05b-4083-a79b-57ee4c61166b", "0d669472-58f0-4fe2-98ea-a024abaedc2a", "Landlord", "LANDLORD" },
                    { "ce04fa66-e006-4379-b37a-021e292cf5fd", "a130b36d-0b93-4b42-a706-0bce15d49a09", "Access-control", "ACCESS-CONTROL" },
                    { "4a8e7f84-b4f3-4aa2-9178-90e7cd40b835", "46e49a28-635b-49f7-bf0f-862fbe78ad94", "Tenant", "TENANT" },
                    { "46023e42-7361-46e0-b27b-7ddfcb0a7a1f", "1bc86ed1-38c6-44ae-9eb5-743df5ebce09", "Visitor", "VISITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "224c6ac9-e883-4775-a8ab-58d87349a3b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d7f4c2c-ced4-49d3-8f41-529db7225dd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46023e42-7361-46e0-b27b-7ddfcb0a7a1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a8e7f84-b4f3-4aa2-9178-90e7cd40b835");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84c28eb8-b05b-4083-a79b-57ee4c61166b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8b8d91c-0af5-4b71-bbc2-1c57e07be8ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bca2704a-a806-496b-b731-cc2343ac2379");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce04fa66-e006-4379-b37a-021e292cf5fd");

            migrationBuilder.DropColumn(
                name: "PropertyCode",
                table: "Buildings");

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
    }
}
