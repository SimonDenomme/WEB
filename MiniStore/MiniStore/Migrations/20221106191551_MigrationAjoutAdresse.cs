using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class MigrationAjoutAdresse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88d03fb8-6ea5-4883-8db2-b3fa629d09b5", "00bb983c-728e-46b9-a076-484df0a6a682", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CommandId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "212bba6a-0f15-40d9-a8f4-3ccb0406be2b", 0, null, "c5d8d9ce-b1d4-4d16-a16c-40cd79633d2a", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEIiNDrremP4yh1zGHlfgU1KEZ4bWNPm4I2kqqtWYv7rH5wlN0P7sYwUMjI+rSw9aMg==", null, false, "f04b7c72-982a-4d3a-a9c6-d4dbe2d22d22", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "88d03fb8-6ea5-4883-8db2-b3fa629d09b5", "212bba6a-0f15-40d9-a8f4-3ccb0406be2b" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88d03fb8-6ea5-4883-8db2-b3fa629d09b5", "212bba6a-0f15-40d9-a8f4-3ccb0406be2b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88d03fb8-6ea5-4883-8db2-b3fa629d09b5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "212bba6a-0f15-40d9-a8f4-3ccb0406be2b");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
