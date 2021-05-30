using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class dene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippmentPackages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Weight = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    TotalDistance = table.Column<double>(nullable: false),
                    RemainigDistance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippmentPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightAndSizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeightMin = table.Column<int>(nullable: false),
                    WeightMax = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightAndSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShippmentPackageId = table.Column<int>(nullable: false),
                    TrackingId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ShippingNote = table.Column<string>(nullable: true),
                    SenderAddress = table.Column<string>(nullable: true),
                    ReceiverAddress = table.Column<string>(nullable: true),
                    Remaining = table.Column<int>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_ShippmentPackages_ShippmentPackageId",
                        column: x => x.ShippmentPackageId,
                        principalTable: "ShippmentPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShippmentPackageId",
                table: "Shipments",
                column: "ShippmentPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "WeightAndSizes");

            migrationBuilder.DropTable(
                name: "ShippmentPackages");
        }
    }
}
