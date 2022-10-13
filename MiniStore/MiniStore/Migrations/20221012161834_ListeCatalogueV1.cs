using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class ListeCatalogueV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Minis");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Minis",
                newName: "ReducedPrice");

            migrationBuilder.RenameColumn(
                name: "IsColored",
                table: "Minis",
                newName: "IsPainted");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Minis",
                newName: "NormalPrice");

            migrationBuilder.AddColumn<bool>(
                name: "IsFrontPage",
                table: "Minis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLuminous",
                table: "Minis",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QtyInventory",
                table: "Minis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtySold",
                table: "Minis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Minis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Minis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Email", "Name", "Text" },
                values: new object[] { 1, "bob@gmail.com", "bob", "allo je mappel bob." });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "M" },
                    { 3, "L" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Status 1" },
                    { 2, "Status 2" },
                    { 3, "Status 3" }
                });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsPainted", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 20.0, 5, 2, 10.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsLuminous", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 40.0, 10, 4, 20.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsPainted", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 60.0, 15, 6, 30.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsLuminous", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 80.0, 20, 8, 40.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsPainted", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 100.0, 25, 10, 50.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsLuminous", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 120.0, 30, 12, 60.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "IsPainted", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 140.0, 35, 14, 70.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IsLuminous", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 160.0, 40, 16, 80.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "IsPainted", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 180.0, 45, 18, 90.0, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "IsLuminous", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[] { true, 200.0, 50, 20, 100.0, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Minis_SizeId",
                table: "Minis",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Minis_StatusId",
                table: "Minis",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Minis_Size_SizeId",
                table: "Minis",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Minis_Status_StatusId",
                table: "Minis",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Minis_Size_SizeId",
                table: "Minis");

            migrationBuilder.DropForeignKey(
                name: "FK_Minis_Status_StatusId",
                table: "Minis");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Minis_SizeId",
                table: "Minis");

            migrationBuilder.DropIndex(
                name: "IX_Minis_StatusId",
                table: "Minis");

            migrationBuilder.DropColumn(
                name: "IsFrontPage",
                table: "Minis");

            migrationBuilder.DropColumn(
                name: "IsLuminous",
                table: "Minis");

            migrationBuilder.DropColumn(
                name: "QtyInventory",
                table: "Minis");

            migrationBuilder.DropColumn(
                name: "QtySold",
                table: "Minis");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Minis");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Minis");

            migrationBuilder.RenameColumn(
                name: "ReducedPrice",
                table: "Minis",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "NormalPrice",
                table: "Minis",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "IsPainted",
                table: "Minis",
                newName: "IsColored");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Minis",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "Discount", "IsColored", "Price" },
                values: new object[] { 10.0, 2.0, false, 20.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "Discount", "Price" },
                values: new object[] { 20.0, 4.0, 40.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "Discount", "IsColored", "Price" },
                values: new object[] { 30.0, 6.0, false, 60.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "Discount", "Price" },
                values: new object[] { 40.0, 8.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "Discount", "IsColored", "Price" },
                values: new object[] { 50.0, 10.0, false, 100.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "Discount", "Price" },
                values: new object[] { 60.0, 12.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "Discount", "IsColored", "Price" },
                values: new object[] { 70.0, 14.0, false, 140.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "Discount", "Price" },
                values: new object[] { 80.0, 16.0, 160.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "Discount", "IsColored", "Price" },
                values: new object[] { 90.0, 18.0, false, 180.0 });

            migrationBuilder.UpdateData(
                table: "Minis",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "Discount", "Price" },
                values: new object[] { 100.0, 20.0, 200.0 });
        }
    }
}
