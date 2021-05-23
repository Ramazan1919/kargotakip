using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class kadirKorkmazbatanlarBirliğiFaruk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverAddress",
                table: "ShippmentPackages");

            migrationBuilder.DropColumn(
                name: "SenderAddress",
                table: "ShippmentPackages");

            migrationBuilder.AddColumn<int>(
                name: "Remaining",
                table: "Shipments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remaining",
                table: "Shipments");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverAddress",
                table: "ShippmentPackages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderAddress",
                table: "ShippmentPackages",
                nullable: true);
        }
    }
}
