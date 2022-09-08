using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Minis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minis_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" },
                    { 3, "Category 3" },
                    { 4, "Category 4" },
                    { 5, "Category 5" },
                    { 6, "Category 6" },
                    { 7, "Category 7" },
                    { 8, "Category 8" },
                    { 9, "Category 9" },
                    { 10, "Category 10" },
                    { 11, "Category 11" },
                    { 12, "Category 12" }
                });

            migrationBuilder.InsertData(
                table: "Minis",
                columns: new[] { "Id", "CategoryId", "Cost", "Discount", "Name" },
                values: new object[,]
                {
                    { 1, 1, 10m, 2m, "Mini 1" },
                    { 2, 2, 20m, 4m, "Mini 2" },
                    { 3, 3, 30m, 6m, "Mini 3" },
                    { 4, 4, 40m, 8m, "Mini 4" },
                    { 5, 5, 50m, 10m, "Mini 5" },
                    { 6, 6, 60m, 12m, "Mini 6" },
                    { 7, 7, 70m, 14m, "Mini 7" },
                    { 8, 8, 80m, 16m, "Mini 8" },
                    { 9, 9, 90m, 18m, "Mini 9" },
                    { 10, 10, 100m, 20m, "Mini 10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Minis_CategoryId",
                table: "Minis",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Minis");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
