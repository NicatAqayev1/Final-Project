using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class Links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Settings",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Settings",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pinterest",
                table: "Settings",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Pinterest",
                table: "Settings");
        }
    }
}
