using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "Creature1.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "Creature2.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "Creature3.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "Creature4.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: "Creature5.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "Creature6.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: "Creature7.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: "Creature8.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: "Creature9.png");

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: "Creature10.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: null);
        }
    }
}
