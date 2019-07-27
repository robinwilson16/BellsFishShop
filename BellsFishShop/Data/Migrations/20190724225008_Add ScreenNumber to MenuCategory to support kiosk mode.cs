using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BellsFishShop.Data.Migrations
{
    public partial class AddScreenNumbertoMenuCategorytosupportkioskmode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScreenNumber",
                table: "MenuCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OpeningDay",
                columns: table => new
                {
                    OpeningDayID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayName = table.Column<string>(nullable: true),
                    OutletOpeningTimeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningDay", x => x.OpeningDayID);
                    table.ForeignKey(
                        name: "FK_OpeningDay_OutletOpeningTime_OutletOpeningTimeID",
                        column: x => x.OutletOpeningTimeID,
                        principalTable: "OutletOpeningTime",
                        principalColumn: "OutletOpeningTimeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpeningDay_OutletOpeningTimeID",
                table: "OpeningDay",
                column: "OutletOpeningTimeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpeningDay");

            migrationBuilder.DropColumn(
                name: "ScreenNumber",
                table: "MenuCategory");
        }
    }
}
