using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManager.Storage.Migrations
{
    public partial class TouristModelColumnsRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalType",
                table: "Tourist");

            migrationBuilder.DropColumn(
                name: "DepartureType",
                table: "Tourist");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalTransportType",
                table: "Tourist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureTransportType",
                table: "Tourist",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTransportType",
                table: "Tourist");

            migrationBuilder.DropColumn(
                name: "DepartureTransportType",
                table: "Tourist");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalType",
                table: "Tourist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartureType",
                table: "Tourist",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
