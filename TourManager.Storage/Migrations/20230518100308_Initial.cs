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
                    StandardColumnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guides = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drivers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expenses = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    DecimalValue = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    IntValue = table.Column<int>(type: "int", nullable: true),
                    DateTimeValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BoolValue = table.Column<bool>(type: "bit", nullable: true),
                    GuidValue = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    { new Guid("6b52973d-171c-47b3-8fb3-7976d9056da6"), "TourStartDate", 0, "Начало тура", 2, 0, 4 },
                    { new Guid("8d01e4cd-aba4-487e-acb0-f1c4ebf5aa1d"), "TourEndDate", 0, "Конец тура", 2, 1, 4 },
                    { new Guid("8661aad6-4130-44dd-8f03-5edd405a6144"), "Номер заказа", 0, "OrderNumber", 2, 2, 2 },
                    { new Guid("37926df9-b966-4f28-9927-0aea4caaa354"), "TourName", 0, "Название тура", 2, 3, 2 },
                    { new Guid("08e1d00e-85d2-4ea8-b2a6-b4449845fe4c"), "FullName", 0, "Имя", 2, 4, 2 },
                    { new Guid("72de359f-a758-4179-901c-4830e866e755"), "ArrivingDate", 0, "Дата и время приезда", 2, 5, 2 },
                    { new Guid("d69856ed-5b91-40dd-b966-66d4ab577be4"), "DepartureDate", 0, "Дата и время отъезда", 2, 6, 2 },
                    { new Guid("c1fa0201-c634-47dc-89b9-70ff4c0c66af"), "BirthData", 0, "Дата рождения", 2, 7, 4 },
                    { new Guid("35d88ff3-8ad6-47c2-9a93-dc1ec1d03f57"), "PhoneNumber", 0, "Номер телефона", 2, 8, 2 },
                    { new Guid("638d7910-902e-48ce-a671-0d2729916e09"), "PassportId", 0, "Номер паспорта", 2, 9, 2 },
                    { new Guid("84f31ee3-19a4-4058-82b5-2bfa17ad6c89"), "Comment", 0, "Коментарии", 2, 10, 2 },
                    { new Guid("3a8805ee-97cf-4a55-baf4-e1fddb05e61d"), "Accommodation", 0, "Отель", 2, 11, 2 }
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
