using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class Maj2Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16add1a9-d822-4fbf-8e48-1610a3efcfcf", "c2e06b81-5a15-460c-89b7-a58a528ab5dd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16add1a9-d822-4fbf-8e48-1610a3efcfcf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2e06b81-5a15-460c-89b7-a58a528ab5dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e47e1f5-9467-4541-98d7-ce1bd470d5f4", "4bf5f118-daa5-46f6-87bb-05f5307b690d", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5b7a46b3-6921-4e31-88ef-b5c030a59aa8", 0, "cc846b24-ad8b-4e82-ad63-b1648bb07e0a", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAELmMIqXcGAZOzN1vjZhTg5DO2dpJ7GyCYkhuB4QMtUUtFtq+3ilB/AhruxSnqXSyfw==", null, false, "5977fd0b-aa04-43ef-ab1d-b5b4860b57c7", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e47e1f5-9467-4541-98d7-ce1bd470d5f4", "5b7a46b3-6921-4e31-88ef-b5c030a59aa8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e47e1f5-9467-4541-98d7-ce1bd470d5f4", "5b7a46b3-6921-4e31-88ef-b5c030a59aa8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e47e1f5-9467-4541-98d7-ce1bd470d5f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b7a46b3-6921-4e31-88ef-b5c030a59aa8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16add1a9-d822-4fbf-8e48-1610a3efcfcf", "f580c64f-e711-44a4-b2a3-77afdb85ac7d", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2e06b81-5a15-460c-89b7-a58a528ab5dd", 0, "163784c1-1207-49d9-af41-a9a75050ed57", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAELwlXZRyCzCtgTOe7N6rGHlqKeoNB7wC1IEBwYrRLaNQef4iqXhJXYAoeySIwieXIg==", null, false, "9a2fbe31-e1fc-486a-82c8-9f20a4b8d919", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16add1a9-d822-4fbf-8e48-1610a3efcfcf", "c2e06b81-5a15-460c-89b7-a58a528ab5dd" });
        }
    }
}
