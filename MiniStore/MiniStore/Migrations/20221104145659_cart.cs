using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9299cafe-79f1-4bf6-a070-86d02370f780", "920dc98c-f813-4aad-9669-e56b007e7937" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9299cafe-79f1-4bf6-a070-86d02370f780");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "920dc98c-f813-4aad-9669-e56b007e7937");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Carts",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "CartUserId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartUserId",
                table: "Carts",
                column: "CartUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_CartUserId",
                table: "Carts",
                column: "CartUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_CartUserId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CartUserId",
                table: "Carts");

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

            migrationBuilder.DropColumn(
                name: "CartUserId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Carts",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9299cafe-79f1-4bf6-a070-86d02370f780", "39fca8dc-5838-493d-97b0-e50b3de4a045", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "920dc98c-f813-4aad-9669-e56b007e7937", 0, null, "b02ab016-a362-4b53-80ff-d33fbe6c9253", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEF9iZL+89gBQkDAlAzzlnCpcG+U5ab4Vanru0jMp8wIDwV+Zk9KJeASqUAgnbz7PzQ==", null, false, "971aa701-74dd-4703-a7e3-1734320f9c87", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9299cafe-79f1-4bf6-a070-86d02370f780", "920dc98c-f813-4aad-9669-e56b007e7937" });
        }
    }
}
