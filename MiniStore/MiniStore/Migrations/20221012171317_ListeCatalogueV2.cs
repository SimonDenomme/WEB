using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class ListeCatalogueV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MinisModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalPrice = table.Column<double>(type: "float", nullable: false),
                    ReducedPrice = table.Column<double>(type: "float", nullable: false),
                    MiniId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_MinisModel_MiniId",
                table: "MinisModel",
                column: "MiniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MinisModel");
        }
    }
}
