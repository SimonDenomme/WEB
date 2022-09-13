using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class AddingReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "Minis",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Minis",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Minis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsColored",
                table: "Minis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Minis",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiniId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Minis_MiniId",
                        column: x => x.MiniId,
                        principalTable: "Minis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 10.0, 2.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 20.0, 4.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 30.0, 6.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 40.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 50.0, 10.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 60.0, 12.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 70.0, 14.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 80.0, 16.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 90.0, 18.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 100.0, 20.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Review_MiniId",
                table: "Review",
                column: "MiniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Minis");

            migrationBuilder.DropColumn(
                name: "IsColored",
                table: "Minis");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Minis");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Minis",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Minis",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 10m, 2m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 20m, 4m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 30m, 6m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 40m, 8m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 50m, 10m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 60m, 12m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 70m, 14m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 80m, 16m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 90m, 18m });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Discount" },
                values: new object[] { 100m, 20m });
        }
    }
}
