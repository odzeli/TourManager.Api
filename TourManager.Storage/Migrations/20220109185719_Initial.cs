using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManager.Storage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StandardColumn",
                columns: table => new
                {
                    StandardColumnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueType = table.Column<int>(type: "int", nullable: false),
                    DefaultAccess = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Options = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardColumn", x => x.StandardColumnId);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guides = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drivers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "Column",
                columns: table => new
                {
                    ColumnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueType = table.Column<int>(type: "int", nullable: false),
                    DefaultAccess = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Options = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Column", x => x.ColumnId);
                    table.ForeignKey(
                        name: "FK_Column_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tourist",
                columns: table => new
                {
                    TouristId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourist", x => x.TouristId);
                    table.ForeignKey(
                        name: "FK_Tourist_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cell",
                columns: table => new
                {
                    TouristId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StringValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IntValue = table.Column<int>(type: "int", nullable: false),
                    DateTimeValue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoolValue = table.Column<bool>(type: "bit", nullable: false),
                    GuidValue = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cell", x => new { x.ColumnId, x.TouristId });
                    table.ForeignKey(
                        name: "FK_Cell_Column_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Column",
                        principalColumn: "ColumnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cell_Tourist_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Tourist",
                        principalColumn: "TouristId");
                });

            migrationBuilder.InsertData(
                table: "StandardColumn",
                columns: new[] { "StandardColumnId", "Code", "DefaultAccess", "Name", "Options", "SortOrder", "ValueType" },
                values: new object[,]
                {
                    { 1, "name", 0, "Имя", 2, 0, 2 },
                    { 2, "startDate", 0, "Начало тура", 2, 1, 4 },
                    { 3, "endDate", 0, "Конец тура", 2, 3, 4 },
                    { 4, "daysNumber", 0, "Дней в туре", 2, 4, 1 },
                    { 5, "nightsInHotel", 0, "Ночей в отеле", 2, 5, 1 },
                    { 6, "tourStars", 0, "Категория тура", 2, 6, 1 },
                    { 7, "roomType", 0, "Тип номера", 2, 7, 2 },
                    { 8, "phone", 0, "Номер телефона", 2, 8, 2 },
                    { 9, "hotel", 0, "Отель", 2, 9, 2 },
                    { 10, "closedPrice", 0, "Закрытая цена", 2, 10, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cell_TouristId",
                table: "Cell",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_Column_TourId",
                table: "Column",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourist_TourId",
                table: "Tourist",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cell");

            migrationBuilder.DropTable(
                name: "StandardColumn");

            migrationBuilder.DropTable(
                name: "Column");

            migrationBuilder.DropTable(
                name: "Tourist");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
