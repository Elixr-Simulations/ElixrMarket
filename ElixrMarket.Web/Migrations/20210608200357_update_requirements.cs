using Microsoft.EntityFrameworkCore.Migrations;

namespace ElixrMarket.Web.Migrations
{
    public partial class update_requirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxGraph",
                table: "Requirements");

            migrationBuilder.RenameColumn(
                name: "MinStorage",
                table: "Requirements",
                newName: "Storage");

            migrationBuilder.RenameColumn(
                name: "MaxStorage",
                table: "Requirements",
                newName: "RecProc");

            migrationBuilder.RenameColumn(
                name: "MaxProc",
                table: "Requirements",
                newName: "RecMem");

            migrationBuilder.RenameColumn(
                name: "MaxMem",
                table: "Requirements",
                newName: "RecGraph");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Storage",
                table: "Requirements",
                newName: "MinStorage");

            migrationBuilder.RenameColumn(
                name: "RecProc",
                table: "Requirements",
                newName: "MaxStorage");

            migrationBuilder.RenameColumn(
                name: "RecMem",
                table: "Requirements",
                newName: "MaxProc");

            migrationBuilder.RenameColumn(
                name: "RecGraph",
                table: "Requirements",
                newName: "MaxMem");

            migrationBuilder.AddColumn<string>(
                name: "MaxGraph",
                table: "Requirements",
                type: "TEXT",
                nullable: true);
        }
    }
}
