using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniStore.Migrations
{
    public partial class InitV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdresseViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressNumber = table.Column<int>(type: "int", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresseViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Messages",
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
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCommand = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_CartUserId",
                        column: x => x.CartUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Minis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPainted = table.Column<bool>(type: "bit", nullable: false),
                    IsLuminous = table.Column<bool>(type: "bit", nullable: false),
                    QtyInventory = table.Column<int>(type: "int", nullable: false),
                    NormalPrice = table.Column<double>(type: "float", nullable: false),
                    ReducedPrice = table.Column<double>(type: "float", nullable: false),
                    IsFrontPage = table.Column<bool>(type: "bit", nullable: false),
                    QtySold = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Minis_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Minis_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemInCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    MiniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemInCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemInCarts_Minis_MiniId",
                        column: x => x.MiniId,
                        principalTable: "Minis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Minis_MiniId",
                        column: x => x.MiniId,
                        principalTable: "Minis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e4a1511-3c5d-4c1a-b477-7d983a721944", "ad67fe9e-88f8-406c-bd78-be026f90de5b", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fb812715-f4a6-4183-b0c3-83e8923f4671", 0, "afb3dd2e-96ac-43e5-abb3-e3148bd50b4d", "admin@test.ca", false, null, null, false, null, "ADMIN@TEST.CA", "ADMIN@TEST.CA", "AQAAAAEAACcQAAAAEGM1DWEEDofErcXcnq65PW8nhZPp9GA9ifk4qc1nA1FzmFgUNBkb670hSjYVuR71+w==", null, false, "d02d638f-fa4c-4100-b692-10570e6b2c45", false, "admin@test.ca" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dungeons & Dragons" },
                    { 2, "PathFinder" },
                    { 3, "GloomHeaven" },
                    { 4, "Cyberpunk Red" },
                    { 5, "Gamma World" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Email", "Name", "Text" },
                values: new object[] { 1, "bob@gmail.com", "bob", "allo je mappel bob." });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 6, "Gargantuan" },
                    { 5, "Huge" },
                    { 4, "Large" },
                    { 1, "Tiny" },
                    { 2, "Small" },
                    { 3, "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 3, "Indisponible" },
                    { 1, "En inventaire" },
                    { 2, "Précommande" },
                    { 4, "En rupture de stock" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5e4a1511-3c5d-4c1a-b477-7d983a721944", "fb812715-f4a6-4183-b0c3-83e8923f4671" });

            migrationBuilder.InsertData(
                table: "Minis",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "IsFrontPage", "IsLuminous", "IsPainted", "Name", "NormalPrice", "QtyInventory", "QtySold", "ReducedPrice", "SizeId", "StatusId" },
                values: new object[,]
                {
                    { 30, 1, "This is a description of Mini 30", "Creature30.png", false, true, true, "Mini 30", 600.0, 150, 60, 300.0, 1, 1 },
                    { 29, 5, "This is a description of Mini 29", "Creature29.png", false, false, true, "Mini 29", 580.0, 145, 58, 290.0, 6, 1 },
                    { 28, 4, "This is a description of Mini 28", "Creature28.png", false, true, true, "Mini 28", 560.0, 140, 56, 280.0, 5, 1 },
                    { 27, 3, "This is a description of Mini 27", "Creature27.png", false, false, true, "Mini 27", 540.0, 135, 54, 270.0, 4, 1 },
                    { 26, 2, "This is a description of Mini 26", "Creature26.png", false, true, true, "Mini 26", 520.0, 130, 52, 260.0, 3, 1 },
                    { 25, 1, "This is a description of Mini 25", "Creature25.png", false, false, true, "Mini 25", 500.0, 125, 50, 250.0, 2, 1 },
                    { 24, 5, "This is a description of Mini 24", "Creature24.png", false, true, true, "Mini 24", 480.0, 120, 48, 240.0, 1, 1 },
                    { 23, 4, "This is a description of Mini 23", "Creature23.png", false, false, true, "Mini 23", 460.0, 115, 46, 230.0, 6, 1 },
                    { 22, 3, "This is a description of Mini 22", "Creature22.png", false, true, true, "Mini 22", 440.0, 110, 44, 220.0, 5, 1 },
                    { 21, 2, "This is a description of Mini 21", "Creature21.png", false, false, true, "Mini 21", 420.0, 105, 42, 210.0, 4, 1 },
                    { 20, 1, "This is a description of Mini 20", "Creature20.png", false, true, true, "Mini 20", 400.0, 100, 40, 200.0, 3, 1 },
                    { 19, 5, "This is a description of Mini 19", "Creature19.png", false, false, true, "Mini 19", 380.0, 95, 38, 190.0, 2, 1 },
                    { 18, 4, "This is a description of Mini 18", "Creature18.png", false, true, true, "Mini 18", 360.0, 90, 36, 180.0, 1, 1 },
                    { 17, 3, "This is a description of Mini 17", "Creature17.png", false, false, true, "Mini 17", 340.0, 85, 34, 170.0, 6, 1 },
                    { 31, 2, "This is a description of Mini 31", "Creature31.png", false, false, true, "Mini 31", 620.0, 155, 62, 310.0, 2, 1 },
                    { 16, 2, "This is a description of Mini 16", "Creature16.png", false, true, true, "Mini 16", 320.0, 80, 32, 160.0, 5, 1 },
                    { 14, 5, "This is a description of Mini 14", "Creature14.png", false, true, true, "Mini 14", 280.0, 70, 28, 140.0, 3, 1 },
                    { 13, 4, "This is a description of Mini 13", "Creature13.png", false, false, true, "Mini 13", 260.0, 65, 26, 130.0, 2, 1 },
                    { 12, 3, "This is a description of Mini 12", "Creature12.png", false, true, true, "Mini 12", 240.0, 60, 24, 120.0, 1, 1 },
                    { 11, 2, "This is a description of Mini 11", "Creature11.png", false, false, true, "Mini 11", 220.0, 55, 22, 110.0, 6, 1 },
                    { 10, 1, "This is a description of Mini 10", "Creature10.png", false, true, true, "Mini 10", 200.0, 50, 20, 100.0, 5, 1 },
                    { 9, 5, "This is a description of Mini 9", "Creature9.png", false, false, true, "Mini 9", 180.0, 45, 18, 90.0, 4, 1 },
                    { 8, 4, "This is a description of Mini 8", "Creature8.png", false, true, true, "Mini 8", 160.0, 40, 16, 80.0, 3, 1 },
                    { 7, 3, "This is a description of Mini 7", "Creature7.png", false, false, true, "Mini 7", 140.0, 35, 14, 70.0, 2, 1 },
                    { 6, 2, "This is a description of Mini 6", "Creature6.png", false, true, true, "Mini 6", 120.0, 30, 12, 60.0, 1, 1 },
                    { 5, 1, "This is a description of Mini 5", "Creature5.png", false, false, true, "Mini 5", 100.0, 25, 10, 50.0, 6, 1 },
                    { 4, 5, "This is a description of Mini 4", "Creature4.png", false, true, true, "Mini 4", 80.0, 20, 8, 40.0, 5, 1 },
                    { 3, 4, "This is a description of Mini 3", "Creature3.png", false, false, true, "Mini 3", 60.0, 15, 6, 30.0, 4, 1 },
                    { 2, 3, "This is a description of Mini 2", "Creature2.png", false, true, true, "Mini 2", 40.0, 10, 4, 20.0, 3, 1 },
                    { 1, 2, "This is a description of Mini 1", "Creature1.png", false, false, true, "Mini 1", 20.0, 5, 2, 10.0, 2, 1 },
                    { 15, 1, "This is a description of Mini 15", "Creature15.png", false, false, true, "Mini 15", 300.0, 75, 30, 150.0, 4, 1 },
                    { 32, 3, "This is a description of Mini 32", "Creature32.png", false, true, true, "Mini 32", 640.0, 160, 64, 320.0, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "MiniId", "Rating", "Text", "UserName" },
                values: new object[] { 1, 1, (byte)5, "Good", "Review 1" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartUserId",
                table: "Carts",
                column: "CartUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInCarts_CartId",
                table: "ItemInCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInCarts_MiniId",
                table: "ItemInCarts",
                column: "MiniId");

            migrationBuilder.CreateIndex(
                name: "IX_Minis_CategoryId",
                table: "Minis",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Minis_SizeId",
                table: "Minis",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Minis_StatusId",
                table: "Minis",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MiniId",
                table: "Reviews",
                column: "MiniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AdresseViewModel");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ItemInCarts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Minis");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
