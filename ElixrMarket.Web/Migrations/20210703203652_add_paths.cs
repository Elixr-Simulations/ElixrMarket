using Microsoft.EntityFrameworkCore.Migrations;

namespace ElixrMarket.Web.Migrations
{
    public partial class add_paths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BinaryPath",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarouselPath",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BinaryPath",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CarouselPath",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Products");
        }
    }
}
