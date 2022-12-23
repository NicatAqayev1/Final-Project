using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class SomeCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Baskets");

            migrationBuilder.AddColumn<double>(
                name: "ExTax",
                table: "Baskets",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExTax",
                table: "Baskets");

            migrationBuilder.AddColumn<double>(
                name: "DiscountPrice",
                table: "Baskets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
