using Microsoft.EntityFrameworkCore.Migrations;

namespace BellsFishShop.Data.Migrations
{
    public partial class AddImageURLAndThumbmailURLToMenuCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "MenuCategory",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "MenuCategory",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "MenuCategory");

            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "MenuCategory");
        }
    }
}
