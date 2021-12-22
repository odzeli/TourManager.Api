using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManager.Storage.Migrations
{
    public partial class TouristChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseCost",
                table: "Tourist");

            migrationBuilder.RenameColumn(
                name: "OpenCost",
                table: "Tourist",
                newName: "ClosePrice");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "Tourist",
                newName: "DepartureDateAndTime");

            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "Tourist",
                newName: "CheckOutDate");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "Tourist",
                newName: "CheckInDate");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                table: "Tourist",
                newName: "ArrivalDateAndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartureDateAndTime",
                table: "Tourist",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "ClosePrice",
                table: "Tourist",
                newName: "OpenCost");

            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "Tourist",
                newName: "DepartureDate");

            migrationBuilder.RenameColumn(
                name: "CheckInDate",
                table: "Tourist",
                newName: "ArrivalTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalDateAndTime",
                table: "Tourist",
                newName: "ArrivalDate");

            migrationBuilder.AddColumn<decimal>(
                name: "CloseCost",
                table: "Tourist",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
