using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpeedyAirProj.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Departure = table.Column<int>(type: "INTEGER", nullable: false),
                    Arrival = table.Column<int>(type: "INTEGER", nullable: false),
                    Day = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    BoxesLoaded = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightNumber);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Destination = table.Column<int>(type: "INTEGER", nullable: false),
                    FlightNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    FlightNumber1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Flights_FlightNumber1",
                        column: x => x.FlightNumber1,
                        principalTable: "Flights",
                        principalColumn: "FlightNumber");
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightNumber", "Arrival", "BoxesLoaded", "Capacity", "Day", "Departure" },
                values: new object[,]
                {
                    { 1, 2, 0, 20, 1, 1 },
                    { 2, 3, 0, 20, 1, 1 },
                    { 3, 4, 0, 20, 1, 1 },
                    { 4, 2, 0, 20, 2, 1 },
                    { 5, 3, 0, 20, 2, 1 },
                    { 6, 4, 0, 20, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlightNumber1",
                table: "Orders",
                column: "FlightNumber1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
