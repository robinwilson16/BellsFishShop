using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BellsFishShop.Data.Migrations
{
    public partial class InitialDatabaseDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.FacilityID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    TextTop = table.Column<string>(maxLength: 1000, nullable: true),
                    TextBottom = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "Outlet",
                columns: table => new
                {
                    OutletID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    SubTitle = table.Column<string>(maxLength: 100, nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: false),
                    HeaderImage = table.Column<string>(nullable: false),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    Address4 = table.Column<string>(nullable: true),
                    PostcodeOut = table.Column<string>(nullable: false),
                    PostcodeIn = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(maxLength: 15, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    GoogleMapLink = table.Column<string>(nullable: true),
                    GoogleReviewsLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlet", x => x.OutletID);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategory",
                columns: table => new
                {
                    MenuCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategory", x => x.MenuCategoryID);
                    table.ForeignKey(
                        name: "FK_MenuCategory_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutletFacility",
                columns: table => new
                {
                    OutletFacilityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OutletID = table.Column<int>(nullable: false),
                    FacilityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutletFacility", x => x.OutletFacilityID);
                    table.ForeignKey(
                        name: "FK_OutletFacility_Facility_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "Facility",
                        principalColumn: "FacilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutletFacility_Outlet_OutletID",
                        column: x => x.OutletID,
                        principalTable: "Outlet",
                        principalColumn: "OutletID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutletOpeningTime",
                columns: table => new
                {
                    OutletOpeningTimeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OutletID = table.Column<int>(nullable: false),
                    DayID = table.Column<int>(nullable: false),
                    OpeningTime = table.Column<DateTime>(nullable: false),
                    ClosingTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutletOpeningTime", x => x.OutletOpeningTimeID);
                    table.ForeignKey(
                        name: "FK_OutletOpeningTime_Outlet_OutletID",
                        column: x => x.OutletID,
                        principalTable: "Outlet",
                        principalColumn: "OutletID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    MenuItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuCategoryID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.MenuItemID);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuCategory_MenuCategoryID",
                        column: x => x.MenuCategoryID,
                        principalTable: "MenuCategory",
                        principalColumn: "MenuCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategory_MenuID",
                table: "MenuCategory",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuCategoryID",
                table: "MenuItem",
                column: "MenuCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OutletFacility_FacilityID",
                table: "OutletFacility",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_OutletFacility_OutletID",
                table: "OutletFacility",
                column: "OutletID");

            migrationBuilder.CreateIndex(
                name: "IX_OutletOpeningTime_OutletID",
                table: "OutletOpeningTime",
                column: "OutletID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "OutletFacility");

            migrationBuilder.DropTable(
                name: "OutletOpeningTime");

            migrationBuilder.DropTable(
                name: "MenuCategory");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Outlet");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
