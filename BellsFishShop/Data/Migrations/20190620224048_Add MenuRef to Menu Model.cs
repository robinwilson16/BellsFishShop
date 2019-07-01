using Microsoft.EntityFrameworkCore.Migrations;

namespace BellsFishShop.Data.Migrations
{
    public partial class AddMenuReftoMenuModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleExtra",
                table: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "MenuRef",
                table: "Menu",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuRef",
                table: "Menu",
                column: "MenuRef");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Menu_MenuRef",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "MenuRef",
                table: "Menu");

            migrationBuilder.AddColumn<string>(
                name: "TitleExtra",
                table: "Menu",
                maxLength: 100,
                nullable: true);
        }
    }
}
