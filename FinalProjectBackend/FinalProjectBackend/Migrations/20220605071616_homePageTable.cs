using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class homePageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "IntroSliders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpgradeLatestImage = table.Column<string>(nullable: true),
                    UpgradeLatestHeader = table.Column<string>(nullable: true),
                    UpgradeLatestText = table.Column<string>(nullable: true),
                    UpgradeLatestSignImage = table.Column<string>(nullable: true),
                    SpecialImage = table.Column<string>(nullable: true),
                    SpecialHeader = table.Column<string>(nullable: true),
                    SpecialText = table.Column<string>(nullable: true),
                    HurryImage = table.Column<string>(nullable: true),
                    HurryHeader = table.Column<string>(nullable: true),
                    HurrySaleText = table.Column<string>(nullable: true),
                    ArrivalHeader = table.Column<string>(nullable: true),
                    ArrivalText = table.Column<string>(nullable: true),
                    ArrivalFeatureBtnText = table.Column<string>(nullable: true),
                    ArrivalNewBtnText = table.Column<string>(nullable: true),
                    ArrivalBestBtnText = table.Column<string>(nullable: true),
                    GalleryHeader = table.Column<string>(nullable: true),
                    GalleryText = table.Column<string>(nullable: true),
                    featuredProdsImage = table.Column<string>(nullable: true),
                    featuredProdsHeader = table.Column<string>(nullable: true),
                    featuredProdsText = table.Column<string>(nullable: true),
                    CountsImage = table.Column<string>(nullable: true),
                    CountsText = table.Column<string>(nullable: true),
                    OurClientsHeader = table.Column<string>(nullable: true),
                    OurClientsText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeGallery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    HomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeGallery_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeSpecialCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CardImage = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    CardText = table.Column<string>(nullable: true),
                    HomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSpecialCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeSpecialCards_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_HomeId",
                table: "Products",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_IntroSliders_HomeId",
                table: "IntroSliders",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeGallery_HomeId",
                table: "HomeGallery",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSpecialCards_HomeId",
                table: "HomeSpecialCards",
                column: "HomeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntroSliders_Homes_HomeId",
                table: "IntroSliders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Homes_HomeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "HomeGallery");

            migrationBuilder.DropTable(
                name: "HomeSpecialCards");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Products_HomeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_IntroSliders_HomeId",
                table: "IntroSliders");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "IntroSliders");
        }
    }
}
