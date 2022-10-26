using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class StatusName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "53e77889-f3db-493d-a29d-d3072cfd4a0e", "a90a5b13-6698-4df3-bf52-1d6e2eca2360" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53e77889-f3db-493d-a29d-d3072cfd4a0e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a90a5b13-6698-4df3-bf52-1d6e2eca2360");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8383fac3-1946-4815-92f6-e9556a0ac556", "e4d51e77-8658-48e5-8968-b24b0a933b89", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a0303b31-b626-4f55-95b6-adb90bd2ae7f", 0, "f3a82890-2692-41ea-8834-c2d762279bf2", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEBVYzdML5ax/XKGuvJLay1y/hHd/nu634s1vrbjIYUhxVfvKIGq91uHG5ZH2uIa43Q==", null, false, "96d54272-d1f6-48ac-84b8-e9a6a5a8eea0", false, "admin@test.ca" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Précommande");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8383fac3-1946-4815-92f6-e9556a0ac556", "a0303b31-b626-4f55-95b6-adb90bd2ae7f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8383fac3-1946-4815-92f6-e9556a0ac556", "a0303b31-b626-4f55-95b6-adb90bd2ae7f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8383fac3-1946-4815-92f6-e9556a0ac556");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0303b31-b626-4f55-95b6-adb90bd2ae7f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53e77889-f3db-493d-a29d-d3072cfd4a0e", "2b1e63ca-2d2e-4d53-988f-bb513d63ffa8", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a90a5b13-6698-4df3-bf52-1d6e2eca2360", 0, "271261d1-5871-40e8-8d83-f9d8cfc375e0", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAENVFHKGjV0w1dIlGCFfzaCTHoF5EAmg1eAxCTHkrovS+tOAzpGU7raZP13uU06DMuQ==", null, false, "3e1ecc08-4c4b-4e2d-b68b-c44ab1d346a7", false, "admin@test.ca" });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Bientôt");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "53e77889-f3db-493d-a29d-d3072cfd4a0e", "a90a5b13-6698-4df3-bf52-1d6e2eca2360" });
        }
    }
}
