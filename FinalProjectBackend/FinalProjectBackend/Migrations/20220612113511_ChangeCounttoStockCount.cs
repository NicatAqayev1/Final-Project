using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class ChangeCounttoStockCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ProductColorSizes");

            migrationBuilder.AddColumn<int>(
                name: "StockCount",
                table: "ProductColorSizes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "ProductColorSizes");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ProductColorSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
