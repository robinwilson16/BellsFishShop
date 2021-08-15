using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BellsFishShop.Data.Migrations
{
    public partial class OpeningTimesSecondSetAdjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutletTypeID",
                table: "OutletOpeningTime");

            migrationBuilder.RenameColumn(
                name: "OpeningTime",
                table: "OutletOpeningTime",
                newName: "OpeningTime2");

            migrationBuilder.RenameColumn(
                name: "ClosingTime",
                table: "OutletOpeningTime",
                newName: "OpeningTime1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingTime1",
                table: "OutletOpeningTime",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingTime2",
                table: "OutletOpeningTime",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingTime1",
                table: "OutletOpeningTime");

            migrationBuilder.DropColumn(
                name: "ClosingTime2",
                table: "OutletOpeningTime");

            migrationBuilder.RenameColumn(
                name: "OpeningTime2",
                table: "OutletOpeningTime",
                newName: "OpeningTime");

            migrationBuilder.RenameColumn(
                name: "OpeningTime1",
                table: "OutletOpeningTime",
                newName: "ClosingTime");

            migrationBuilder.AddColumn<int>(
                name: "OutletTypeID",
                table: "OutletOpeningTime",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
