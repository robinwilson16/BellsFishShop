using Microsoft.EntityFrameworkCore.Migrations;

namespace BellsFishShop.Data.Migrations
{
    public partial class AddVenueTypeforOpeningHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutletTypeID",
                table: "OutletOpeningTime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OpeningTimeVenueType1",
                table: "Outlet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningTimeVenueType2",
                table: "Outlet",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutletTypeID",
                table: "OutletOpeningTime");

            migrationBuilder.DropColumn(
                name: "OpeningTimeVenueType1",
                table: "Outlet");

            migrationBuilder.DropColumn(
                name: "OpeningTimeVenueType2",
                table: "Outlet");
        }
    }
}
