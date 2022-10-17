using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class fullBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Minis_Size_SizeId",
                table: "Minis");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Minis_MiniId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c58d1e4a-fdaf-4a5b-bfd6-726691e2cc35", "92ef0b45-6bee-4c38-bfcf-a098c29ce8c8" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c58d1e4a-fdaf-4a5b-bfd6-726691e2cc35");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92ef0b45-6bee-4c38-bfcf-a098c29ce8c8");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Review_MiniId",
                table: "Reviews",
                newName: "IX_Reviews_MiniId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16add1a9-d822-4fbf-8e48-1610a3efcfcf", "f580c64f-e711-44a4-b2a3-77afdb85ac7d", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2e06b81-5a15-460c-89b7-a58a528ab5dd", 0, "163784c1-1207-49d9-af41-a9a75050ed57", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAELwlXZRyCzCtgTOe7N6rGHlqKeoNB7wC1IEBwYrRLaNQef4iqXhJXYAoeySIwieXIg==", null, false, "9a2fbe31-e1fc-486a-82c8-9f20a4b8d919", false, "admin@test.ca" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Dungeons & Dragons");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "PathFinder");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "GloomHeaven");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Cyberpunk Red");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Gamma World");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                column: "SizeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 13,
                column: "SizeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 14,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 19,
                column: "SizeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 20,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 25,
                column: "SizeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 26,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 31,
                column: "SizeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 32,
                column: "SizeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Tiny");

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Small");

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Medium");

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 5, "Huge" },
                    { 4, "Large" },
                    { 6, "Gargantuan" }
                });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "En inventaire");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Bientôt");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "En rupture de stock");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16add1a9-d822-4fbf-8e48-1610a3efcfcf", "c2e06b81-5a15-460c-89b7-a58a528ab5dd" });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                column: "SizeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                column: "SizeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                column: "SizeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                column: "SizeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                column: "SizeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 11,
                column: "SizeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 15,
                column: "SizeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 16,
                column: "SizeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 17,
                column: "SizeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 21,
                column: "SizeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 22,
                column: "SizeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 23,
                column: "SizeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 27,
                column: "SizeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 28,
                column: "SizeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 29,
                column: "SizeId",
                value: 6);

            migrationBuilder.AddForeignKey(
                name: "FK_Minis_Sizes_SizeId",
                table: "Minis",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Minis_MiniId",
                table: "Reviews",
                column: "MiniId",
                principalTable: "Minis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Minis_Sizes_SizeId",
                table: "Minis");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Minis_MiniId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16add1a9-d822-4fbf-8e48-1610a3efcfcf", "c2e06b81-5a15-460c-89b7-a58a528ab5dd" });

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16add1a9-d822-4fbf-8e48-1610a3efcfcf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2e06b81-5a15-460c-89b7-a58a528ab5dd");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_MiniId",
                table: "Review",
                newName: "IX_Review_MiniId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c58d1e4a-fdaf-4a5b-bfd6-726691e2cc35", "46bbb99b-06a7-4951-bd1b-87e1a252f600", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "92ef0b45-6bee-4c38-bfcf-a098c29ce8c8", 0, "dd9a25bf-b126-45b8-98a9-47b6d305fed3", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEHHFla7Nqi0k3YOTx0h0b9EEn/gE4mIrW/d+B7oVwCnhA5xEdE2DTHsRxW5fqf3UcQ==", null, false, "4bb81d77-bb36-4b9f-8198-f04da3126137", false, "admin@test.ca" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Category 1");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Category 2");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Category 3");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Category 4");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Category 5");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Category 8" },
                    { 6, "Category 6" },
                    { 9, "Category 9" },
                    { 12, "Category 12" },
                    { 11, "Category 11" },
                    { 10, "Category 10" },
                    { 7, "Category 7" }
                });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 11,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 13,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 14,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 15,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 16,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 17,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 19,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 20,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 21,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 22,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 23,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 25,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 26,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 27,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 28,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 29,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 31,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 32,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "S");

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "L");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Tout");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Disponible");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Rupture de stock");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c58d1e4a-fdaf-4a5b-bfd6-726691e2cc35", "92ef0b45-6bee-4c38-bfcf-a098c29ce8c8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Minis_Size_SizeId",
                table: "Minis",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Minis_MiniId",
                table: "Review",
                column: "MiniId",
                principalTable: "Minis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
