using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class homePageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeGallery_Homes_HomeId",
                table: "HomeGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeGallery",
                table: "HomeGallery");

            migrationBuilder.RenameTable(
                name: "HomeGallery",
                newName: "HomeGalleries");

            migrationBuilder.RenameIndex(
                name: "IX_HomeGallery_HomeId",
                table: "HomeGalleries",
                newName: "IX_HomeGalleries_HomeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeGalleries",
                table: "HomeGalleries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HomeOurClientsSliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeOurClientsSliders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HomeGalleries_Homes_HomeId",
                table: "HomeGalleries",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeGalleries_Homes_HomeId",
                table: "HomeGalleries");

            migrationBuilder.DropTable(
                name: "HomeOurClientsSliders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeGalleries",
                table: "HomeGalleries");

            migrationBuilder.RenameTable(
                name: "HomeGalleries",
                newName: "HomeGallery");

            migrationBuilder.RenameIndex(
                name: "IX_HomeGalleries_HomeId",
                table: "HomeGallery",
                newName: "IX_HomeGallery_HomeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeGallery",
                table: "HomeGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeGallery_Homes_HomeId",
                table: "HomeGallery",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
