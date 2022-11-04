using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class vendredi04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf0fba68-aced-47a4-8b50-096ae6d21818", "d22c21e7-19db-442b-b453-94a131fdad71" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf0fba68-aced-47a4-8b50-096ae6d21818");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d22c21e7-19db-442b-b453-94a131fdad71");

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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalAvantTaxe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalApresTaxe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FraisLivraison = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: true)
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
                values: new object[] { "8d858fb2-fba9-4a46-9458-21c5e8833efc", "8cabe01b-98d9-4939-8e25-69a78f355a89", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "CommandId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "86e69416-a356-4162-9de5-1091bf977c89", 0, null, null, "56e9cbca-e491-4c04-82e9-1ec16961db45", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEE7M16p1Mo9uI+71V+koVhmdxfUh74crmKBZiFzUCAwxXLdmTVpx2JWu9YT9ia/lsQ==", null, false, "82eb4674-e0dd-4911-9afa-e39cdbdfc0a2", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8d858fb2-fba9-4a46-9458-21c5e8833efc", "86e69416-a356-4162-9de5-1091bf977c89" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { "8d858fb2-fba9-4a46-9458-21c5e8833efc", "86e69416-a356-4162-9de5-1091bf977c89" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d858fb2-fba9-4a46-9458-21c5e8833efc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86e69416-a356-4162-9de5-1091bf977c89");

            migrationBuilder.DropColumn(
                name: "CommandId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf0fba68-aced-47a4-8b50-096ae6d21818", "c46139b2-b49c-4e0a-99ab-0696d7305923", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d22c21e7-19db-442b-b453-94a131fdad71", 0, null, "42744867-e08b-43b6-8823-54299473dc07", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEHw6ZYFWx2scRqNe+XYfy4qllFkmr2YIgUv4zipmGqa0+DfVjy3wIslD6EzrZFXlVw==", null, false, "24fc315b-bf94-4fcc-82f2-a38a95e2ba7b", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cf0fba68-aced-47a4-8b50-096ae6d21818", "d22c21e7-19db-442b-b453-94a131fdad71" });
        }
    }
}
