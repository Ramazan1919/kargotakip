using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class gereksizAlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainigDistance",
                table: "ShippmentPackages");

            migrationBuilder.DropColumn(
                name: "TotalDistance",
                table: "ShippmentPackages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RemainigDistance",
                table: "ShippmentPackages",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDistance",
                table: "ShippmentPackages",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
