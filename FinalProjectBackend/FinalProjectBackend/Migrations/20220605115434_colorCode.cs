using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class colorCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeCounts_Homes_HomeId",
                table: "HomeCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeGalleries_Homes_HomeId",
                table: "HomeGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeOurClientsSliders_Homes_HomeId",
                table: "HomeOurClientsSliders");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeSpecialCards_Homes_HomeId",
                table: "HomeSpecialCards");

            migrationBuilder.DropForeignKey(
                name: "FK_IntroSliders_Homes_HomeId",
                table: "IntroSliders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Homes_HomeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_HomeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_IntroSliders_HomeId",
                table: "IntroSliders");

            migrationBuilder.DropIndex(
                name: "IX_HomeSpecialCards_HomeId",
                table: "HomeSpecialCards");

            migrationBuilder.DropIndex(
                name: "IX_HomeOurClientsSliders_HomeId",
                table: "HomeOurClientsSliders");

            migrationBuilder.DropIndex(
                name: "IX_HomeGalleries_HomeId",
                table: "HomeGalleries");

            migrationBuilder.DropIndex(
                name: "IX_HomeCounts_HomeId",
                table: "HomeCounts");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "IntroSliders");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "HomeSpecialCards");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "HomeOurClientsSliders");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "HomeGalleries");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "HomeCounts");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "Colors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "Colors");

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "IntroSliders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "HomeSpecialCards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "HomeOurClientsSliders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "HomeGalleries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "HomeCounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_HomeId",
                table: "Products",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_IntroSliders_HomeId",
                table: "IntroSliders",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSpecialCards_HomeId",
                table: "HomeSpecialCards",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeOurClientsSliders_HomeId",
                table: "HomeOurClientsSliders",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeGalleries_HomeId",
                table: "HomeGalleries",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCounts_HomeId",
                table: "HomeCounts",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeCounts_Homes_HomeId",
                table: "HomeCounts",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeGalleries_Homes_HomeId",
                table: "HomeGalleries",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeOurClientsSliders_Homes_HomeId",
                table: "HomeOurClientsSliders",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSpecialCards_Homes_HomeId",
                table: "HomeSpecialCards",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IntroSliders_Homes_HomeId",
                table: "IntroSliders",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Homes_HomeId",
                table: "Products",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
