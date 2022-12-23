using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class AboutPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IntroHeader = table.Column<string>(maxLength: 255, nullable: true),
                    IntroText = table.Column<string>(maxLength: 1000, nullable: true),
                    OfferHeader = table.Column<string>(maxLength: 255, nullable: true),
                    OfferText = table.Column<string>(maxLength: 1000, nullable: true),
                    AboutWineHeader = table.Column<string>(maxLength: 255, nullable: true),
                    AboutWineText = table.Column<string>(maxLength: 1000, nullable: true),
                    StaffHEader = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
