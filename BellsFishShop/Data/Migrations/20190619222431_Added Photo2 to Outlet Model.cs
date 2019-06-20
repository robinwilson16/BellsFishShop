using Microsoft.EntityFrameworkCore.Migrations;

namespace BellsFishShop.Data.Migrations
{
    public partial class AddedPhoto2toOutletModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo2",
                table: "Outlet",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo2",
                table: "Outlet");
        }
    }
}
