using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthApp.Migrations
{
    public partial class Refactorbuildingtable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "NumberOfFloors",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "PropertyCode",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Buildings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Floors",
                table: "Buildings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d58af74d-e154-49ae-b353-2393e9a66ccf", "ad2840c4-00b7-41ee-b413-e794556faa29", "Admin", "ADMIN" },
                    { "87e2c776-7450-46e1-8641-0ebbe3037ef9", "25ea38ae-b8a1-4c2b-b75f-dfb5a528cfec", "User", "USER" },
                    { "f2451e87-85d3-4840-8528-cc5cf83280ab", "c590b815-0baa-4f1d-af30-d08c161b4d0b", "Property-Administrator", "PROPERTY-ADMINISTRATOR" },
                    { "8a5a9d32-1119-4270-abda-a29fde10633a", "db974b6b-dd5d-4347-8f19-35ea65635bcd", "Caretaker", "CARETAKER" },
                    { "ea993f55-e566-4ceb-9f42-00ae08241bd7", "8394ca14-a967-429b-bd8f-857c71a1e8de", "Landlord", "LANDLORD" },
                    { "9a03f787-9800-466e-9e65-ddce64a30bec", "ad52b454-a021-4374-b022-6c1b6965c88b", "Access-control", "ACCESS-CONTROL" },
                    { "04d2a2fe-8cff-4500-ad99-ab137af6ef71", "0704b6dd-45e0-43ba-8664-7f43ccca061a", "Tenant", "TENANT" },
                    { "069a608b-22f8-4bd3-a891-571317608737", "025ca65e-42ce-4790-bce8-635970dc70eb", "Visitor", "VISITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d2a2fe-8cff-4500-ad99-ab137af6ef71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "069a608b-22f8-4bd3-a891-571317608737");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e2c776-7450-46e1-8641-0ebbe3037ef9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a5a9d32-1119-4270-abda-a29fde10633a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a03f787-9800-466e-9e65-ddce64a30bec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d58af74d-e154-49ae-b353-2393e9a66ccf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea993f55-e566-4ceb-9f42-00ae08241bd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2451e87-85d3-4840-8528-cc5cf83280ab");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Floors",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFloors",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyCode",
                table: "Buildings",
                type: "int",
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
    }
}
