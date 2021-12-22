using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManager.Storage.Migrations
{
    public partial class AddForeignColumnForTouristTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tourist",
                newName: "TouristId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tour",
                newName: "TourId");

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosePrice",
                table: "Tourist",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "TourId",
                table: "Tourist",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tourist_TourId",
                table: "Tourist",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourist_Tour_TourId",
                table: "Tourist",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "TourId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourist_Tour_TourId",
                table: "Tourist");

            migrationBuilder.DropIndex(
                name: "IX_Tourist_TourId",
                table: "Tourist");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "Tourist");

            migrationBuilder.RenameColumn(
                name: "TouristId",
                table: "Tourist",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Tour",
                newName: "Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "ClosePrice",
                table: "Tourist",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
