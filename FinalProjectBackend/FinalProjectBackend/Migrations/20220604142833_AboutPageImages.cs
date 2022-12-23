using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class AboutPageImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutWineImage",
                table: "Abouts",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntroImage",
                table: "Abouts",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfferImage",
                table: "Abouts",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutWineImage",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "IntroImage",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "OfferImage",
                table: "Abouts");
        }
    }
}
