using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class MigrationAjoutAdresse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdresseViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressNumber = table.Column<int>(type: "int", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresseViewModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49455b95-7677-4aac-97ec-150416737023", "7c72acb5-77eb-4c4a-a8be-145980df936f", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CommandId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3481842-2e42-4cb7-9cfa-05e6f2d97cbb", 0, null, "d45ffcd9-ad99-4cea-97a6-7b444a6e934b", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEKnr82fBIHKrWK1JbP/AM29kmEHkScyzACZzcuWKEizIC/r4WjSfT3+1LdBfbGnbBw==", null, false, "9e3f8747-e843-4587-a551-859c14c0799d", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "49455b95-7677-4aac-97ec-150416737023", "b3481842-2e42-4cb7-9cfa-05e6f2d97cbb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresseViewModel");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49455b95-7677-4aac-97ec-150416737023", "b3481842-2e42-4cb7-9cfa-05e6f2d97cbb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49455b95-7677-4aac-97ec-150416737023");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3481842-2e42-4cb7-9cfa-05e6f2d97cbb");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Addresses");

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
        }
    }
}
