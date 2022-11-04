using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class vendrediPLusTardEncore2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d858fb2-fba9-4a46-9458-21c5e8833efc", "86e69416-a356-4162-9de5-1091bf977c89" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d858fb2-fba9-4a46-9458-21c5e8833efc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86e69416-a356-4162-9de5-1091bf977c89");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1929cdc5-e462-4db9-aff9-eb205c1d9d39", "73a4ba38-59f6-48d1-8001-18f2974999b2", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CommandId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f9e7382e-8848-43a7-8936-ee6c35cc3042", 0, null, null, "46db062b-9547-4153-bb61-657a7e020ae1", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAED0BPW/kQ3YwFrAGe89L6dewNbDeAAV807822jMN1NZklWn75VIoQsW1c0+X0GwkzA==", null, false, "f988f718-219f-469e-92c8-ac6b3855a720", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1929cdc5-e462-4db9-aff9-eb205c1d9d39", "f9e7382e-8848-43a7-8936-ee6c35cc3042" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1929cdc5-e462-4db9-aff9-eb205c1d9d39", "f9e7382e-8848-43a7-8936-ee6c35cc3042" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1929cdc5-e462-4db9-aff9-eb205c1d9d39");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9e7382e-8848-43a7-8936-ee6c35cc3042");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d858fb2-fba9-4a46-9458-21c5e8833efc", "8cabe01b-98d9-4939-8e25-69a78f355a89", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CommandId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "86e69416-a356-4162-9de5-1091bf977c89", 0, null, null, "56e9cbca-e491-4c04-82e9-1ec16961db45", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEE7M16p1Mo9uI+71V+koVhmdxfUh74crmKBZiFzUCAwxXLdmTVpx2JWu9YT9ia/lsQ==", null, false, "82eb4674-e0dd-4911-9afa-e39cdbdfc0a2", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8d858fb2-fba9-4a46-9458-21c5e8833efc", "86e69416-a356-4162-9de5-1091bf977c89" });
        }
    }
}
