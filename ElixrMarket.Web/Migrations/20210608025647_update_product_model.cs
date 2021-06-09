using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElixrMarket.Web.Migrations
{
    public partial class update_product_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeveloperId",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RequirementsId",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    OS = table.Column<string>(type: "TEXT", nullable: true),
                    MinProc = table.Column<string>(type: "TEXT", nullable: true),
                    MaxProc = table.Column<string>(type: "TEXT", nullable: true),
                    MinMem = table.Column<string>(type: "TEXT", nullable: true),
                    MaxMem = table.Column<string>(type: "TEXT", nullable: true),
                    MinGraph = table.Column<string>(type: "TEXT", nullable: true),
                    MaxGraph = table.Column<string>(type: "TEXT", nullable: true),
                    MinStorage = table.Column<string>(type: "TEXT", nullable: true),
                    MaxStorage = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeveloperId",
                table: "Products",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_ProductId",
                table: "Requirements",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_DeveloperId",
                table: "Products",
                column: "DeveloperId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_DeveloperId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeveloperId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RequirementsId",
                table: "Products");
        }
    }
}
