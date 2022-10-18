using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class Initial_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f0204c3c-a66f-4215-b5c3-283a96f9f8ee", "fc621b7f-f010-4ab3-ad27-7bb418e9f38f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0204c3c-a66f-4215-b5c3-283a96f9f8ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc621b7f-f010-4ab3-ad27-7bb418e9f38f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53e77889-f3db-493d-a29d-d3072cfd4a0e", "2b1e63ca-2d2e-4d53-988f-bb513d63ffa8", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a90a5b13-6698-4df3-bf52-1d6e2eca2360", 0, "271261d1-5871-40e8-8d83-f9d8cfc375e0", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAENVFHKGjV0w1dIlGCFfzaCTHoF5EAmg1eAxCTHkrovS+tOAzpGU7raZP13uU06DMuQ==", null, false, "3e1ecc08-4c4b-4e2d-b68b-c44ab1d346a7", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "53e77889-f3db-493d-a29d-d3072cfd4a0e", "a90a5b13-6698-4df3-bf52-1d6e2eca2360" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f0204c3c-a66f-4215-b5c3-283a96f9f8ee", "9a237f37-f5a7-459e-b76d-c23d8f0ebb7a", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fc621b7f-f010-4ab3-ad27-7bb418e9f38f", 0, "e2074358-58a5-4f20-9193-e80488c2ea20", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEOCG19n4R1ZxmsLWBIF35knMeucTAwtPp6nW5UQkYdw8/6elrlnu3E1JeDQIG7ZaqA==", null, false, "de8f209e-37e7-4cd0-a748-9b355c230a92", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f0204c3c-a66f-4215-b5c3-283a96f9f8ee", "fc621b7f-f010-4ab3-ad27-7bb418e9f38f" });
        }
    }
}
