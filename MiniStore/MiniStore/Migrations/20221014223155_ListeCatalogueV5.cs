using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class ListeCatalogueV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MinisModel");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                column: "CategoryId",
                value: 11);

            migrationBuilder.InsertData(
                table: "Minis",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "IsFrontPage", "IsLuminous", "IsPainted", "Name", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[,]
                {
                    { 11, 12, "This is a description", "Creature11.png", false, false, true, "Mini 11", 220.0, 55, 22, 110.0, 1, 2 },
                    { 32, 9, "This is a description", "Creature32.png", false, true, true, "Mini 32", 640.0, 160, 64, 320.0, 1, 2 },
                    { 31, 8, "This is a description", "Creature31.png", false, false, true, "Mini 31", 620.0, 155, 62, 310.0, 1, 2 },
                    { 30, 7, "This is a description", "Creature30.png", false, true, true, "Mini 30", 600.0, 150, 60, 300.0, 1, 2 },
                    { 29, 6, "This is a description", "Creature29.png", false, false, true, "Mini 29", 580.0, 145, 58, 290.0, 1, 2 },
                    { 27, 4, "This is a description", "Creature27.png", false, false, true, "Mini 27", 540.0, 135, 54, 270.0, 1, 2 },
                    { 28, 5, "This is a description", "Creature28.png", false, true, true, "Mini 28", 560.0, 140, 56, 280.0, 1, 2 },
                    { 18, 7, "This is a description", "Creature18.png", false, true, true, "Mini 18", 360.0, 90, 36, 180.0, 1, 2 },
                    { 25, 2, "This is a description", "Creature25.png", false, false, true, "Mini 25", 500.0, 125, 50, 250.0, 1, 2 },
                    { 24, 1, "This is a description", "Creature24.png", false, true, true, "Mini 24", 480.0, 120, 48, 240.0, 1, 2 },
                    { 23, 12, "This is a description", "Creature23.png", false, false, true, "Mini 23", 460.0, 115, 46, 230.0, 1, 2 },
                    { 22, 11, "This is a description", "Creature22.png", false, true, true, "Mini 22", 440.0, 110, 44, 220.0, 1, 2 },
                    { 21, 10, "This is a description", "Creature21.png", false, false, true, "Mini 21", 420.0, 105, 42, 210.0, 1, 2 },
                    { 20, 9, "This is a description", "Creature20.png", false, true, true, "Mini 20", 400.0, 100, 40, 200.0, 1, 2 },
                    { 19, 8, "This is a description", "Creature19.png", false, false, true, "Mini 19", 380.0, 95, 38, 190.0, 1, 2 },
                    { 26, 3, "This is a description", "Creature26.png", false, true, true, "Mini 26", 520.0, 130, 52, 260.0, 1, 2 },
                    { 17, 6, "This is a description", "Creature17.png", false, false, true, "Mini 17", 340.0, 85, 34, 170.0, 1, 2 },
                    { 16, 5, "This is a description", "Creature16.png", false, true, true, "Mini 16", 320.0, 80, 32, 160.0, 1, 2 },
                    { 15, 4, "This is a description", "Creature15.png", false, false, true, "Mini 15", 300.0, 75, 30, 150.0, 1, 2 },
                    { 14, 3, "This is a description", "Creature14.png", false, true, true, "Mini 14", 280.0, 70, 28, 140.0, 1, 2 },
                    { 13, 2, "This is a description", "Creature13.png", false, false, true, "Mini 13", 260.0, 65, 26, 130.0, 1, 2 },
                    { 12, 1, "This is a description", "Creature12.png", false, true, true, "Mini 12", 240.0, 60, 24, 120.0, 1, 2 }
                });

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
                keyValue: 3,
                column: "Title",
                value: "Indisponible");

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Rupture de stock" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "MinisModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiniId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalPrice = table.Column<double>(type: "float", nullable: false),
                    ReducedPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinisModel_Minis_MiniId",
                        column: x => x.MiniId,
                        principalTable: "Minis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Status 1");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Status 2");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Status 3");

            migrationBuilder.CreateIndex(
                name: "IX_MinisModel_MiniId",
                table: "MinisModel",
                column: "MiniId");
        }
    }
}
