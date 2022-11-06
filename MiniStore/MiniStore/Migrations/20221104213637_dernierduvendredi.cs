using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class dernierduvendredi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Command_CommandId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Command");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CommandId",
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
                name: "CommandId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsCommand",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b84dece-8fdc-49c4-93a4-6a080ced56db", "0ac9cb4d-cc5c-4965-9ddf-f2d112606c7c", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "359192d7-80da-4c15-ae2b-d8dd2716659f", 0, null, "efdad9fa-dc0d-4662-8bff-752e57b5ad81", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEOrzV5ID44QYyESzBy8n8TxpWI/2ZDWM1DgjiDHhwcTnOCJ4e1mgOoQQ0DjIF+zOkg==", null, false, "8afa635e-7fe5-4912-b96f-d4289fb4270b", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3b84dece-8fdc-49c4-93a4-6a080ced56db", "359192d7-80da-4c15-ae2b-d8dd2716659f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3b84dece-8fdc-49c4-93a4-6a080ced56db", "359192d7-80da-4c15-ae2b-d8dd2716659f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b84dece-8fdc-49c4-93a4-6a080ced56db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "359192d7-80da-4c15-ae2b-d8dd2716659f");

            migrationBuilder.DropColumn(
                name: "IsCommand",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CommandId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Command",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FraisLivraison = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: true),
                    Taxe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalApresTaxe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAvantTaxe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Command_Carts_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_AspNetUsers_CommandId",
                table: "AspNetUsers",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_Command_ItemsId",
                table: "Command",
                column: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Command_CommandId",
                table: "AspNetUsers",
                column: "CommandId",
                principalTable: "Command",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
