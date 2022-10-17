using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class MajSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b5a55fd7-74fc-42f4-bad0-782b2cc67afc", "cbfd62c3-7192-4219-b283-8b7c54d24459", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c5cbdc29-baa5-44e7-a42b-fb474be18602", 0, "e0736cfe-7286-4891-9d10-e6931bc99995", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAELmdRIwZ+lhUA1ciVorWelFZne6pNGkq6GNgEuGv9UhGG7CjZZWkn1kdx4aSRRxzSw==", null, false, "05ef13ee-6ba6-420b-9d7d-7a19d065cd48", false, "admin@test.ca" });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "This is a description of Mini 1");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "This is a description of Mini 2");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "This is a description of Mini 3");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "This is a description of Mini 4");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "This is a description of Mini 5");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "This is a description of Mini 6");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "This is a description of Mini 7");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "This is a description of Mini 8");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "This is a description of Mini 9");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "This is a description of Mini 10");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "This is a description of Mini 11");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "This is a description of Mini 12");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "This is a description of Mini 13");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "This is a description of Mini 14");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "This is a description of Mini 15");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: "This is a description of Mini 16");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "This is a description of Mini 17");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 18,
                column: "Description",
                value: "This is a description of Mini 18");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: "This is a description of Mini 19");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: "This is a description of Mini 20");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: "This is a description of Mini 21");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: "This is a description of Mini 22");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "This is a description of Mini 23");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 24,
                column: "Description",
                value: "This is a description of Mini 24");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 25,
                column: "Description",
                value: "This is a description of Mini 25");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "This is a description of Mini 26");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "This is a description of Mini 27");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: "This is a description of Mini 28");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 29,
                column: "Description",
                value: "This is a description of Mini 29");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 30,
                column: "Description",
                value: "This is a description of Mini 30");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: "This is a description of Mini 31");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: "This is a description of Mini 32");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b5a55fd7-74fc-42f4-bad0-782b2cc67afc", "c5cbdc29-baa5-44e7-a42b-fb474be18602" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b5a55fd7-74fc-42f4-bad0-782b2cc67afc", "c5cbdc29-baa5-44e7-a42b-fb474be18602" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5a55fd7-74fc-42f4-bad0-782b2cc67afc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5cbdc29-baa5-44e7-a42b-fb474be18602");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e47e1f5-9467-4541-98d7-ce1bd470d5f4", "4bf5f118-daa5-46f6-87bb-05f5307b690d", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5b7a46b3-6921-4e31-88ef-b5c030a59aa8", 0, "cc846b24-ad8b-4e82-ad63-b1648bb07e0a", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAELmMIqXcGAZOzN1vjZhTg5DO2dpJ7GyCYkhuB4QMtUUtFtq+3ilB/AhruxSnqXSyfw==", null, false, "5977fd0b-aa04-43ef-ab1d-b5b4860b57c7", false, "admin@test.ca" });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 15,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 16,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 18,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 24,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 25,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 28,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 29,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 30,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: "This is a description");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: "This is a description");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e47e1f5-9467-4541-98d7-ce1bd470d5f4", "5b7a46b3-6921-4e31-88ef-b5c030a59aa8" });
        }
    }
}
