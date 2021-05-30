using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class validatorupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDanger",
                table: "ShippmentPackages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLiquid",
                table: "ShippmentPackages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isPet",
                table: "ShippmentPackages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDanger",
                table: "ShippmentPackages");

            migrationBuilder.DropColumn(
                name: "isLiquid",
                table: "ShippmentPackages");

            migrationBuilder.DropColumn(
                name: "isPet",
                table: "ShippmentPackages");
        }
    }
}
