using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBackend.Migrations
{
    public partial class CorrectonOnHomePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountsImage",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "CountsText",
                table: "Homes");

            migrationBuilder.CreateTable(
                name: "HomeCounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CountsImage = table.Column<string>(nullable: true),
                    CountsText = table.Column<string>(nullable: true),
                    HomeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCounts_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeCounts_HomeId",
                table: "HomeCounts",
                column: "HomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeCounts");

            migrationBuilder.AddColumn<string>(
                name: "CountsImage",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountsText",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
