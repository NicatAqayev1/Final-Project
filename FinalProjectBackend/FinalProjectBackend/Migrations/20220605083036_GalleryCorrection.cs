using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class GalleryCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "HomeGalleries");

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "HomeOurClientsSliders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "HomeGalleries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HomeOurClientsSliders_HomeId",
                table: "HomeOurClientsSliders",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeGalleries_CategoryId",
                table: "HomeGalleries",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeGalleries_Categories_CategoryId",
                table: "HomeGalleries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeOurClientsSliders_Homes_HomeId",
                table: "HomeOurClientsSliders",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeGalleries_Categories_CategoryId",
                table: "HomeGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeOurClientsSliders_Homes_HomeId",
                table: "HomeOurClientsSliders");

            migrationBuilder.DropIndex(
                name: "IX_HomeOurClientsSliders_HomeId",
                table: "HomeOurClientsSliders");

            migrationBuilder.DropIndex(
                name: "IX_HomeGalleries_CategoryId",
                table: "HomeGalleries");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "HomeOurClientsSliders");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "HomeGalleries");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "HomeGalleries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
