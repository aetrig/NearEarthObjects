using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NASA_API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asteroids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nasa_id = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    magnitude = table.Column<double>(type: "REAL", nullable: false),
                    is_potentially_hazardous = table.Column<bool>(type: "INTEGER", nullable: false),
                    is_sentry_object = table.Column<bool>(type: "INTEGER", nullable: false),
                    estimated_diameter_estimated_diameter_max_feet = table.Column<double>(type: "REAL", nullable: false),
                    estimated_diameter_estimated_diameter_max_km = table.Column<double>(type: "REAL", nullable: false),
                    estimated_diameter_estimated_diameter_max_m = table.Column<double>(type: "REAL", nullable: false),
                    estimated_diameter_estimated_diameter_max_miles = table.Column<double>(type: "REAL", nullable: false),
                    estimated_diameter_estimated_diameter_min_feet = table.Column<double>(type: "REAL", nullable: false),
                    estimated_diameter_estimated_diameter_min_km = table.Column<double>(type: "REAL", nullable: false),
                    estimated_diameter_estimated_diameter_min_m = table.Column<double>(type: "REAL", nullable: false),
                    estimated_diameter_estimated_diameter_min_miles = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asteroids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "approaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<string>(type: "TEXT", nullable: false),
                    orbiting_body = table.Column<string>(type: "TEXT", nullable: false),
                    asteroidId = table.Column<int>(type: "INTEGER", nullable: false),
                    miss_distance_astronomical = table.Column<string>(type: "TEXT", nullable: false),
                    miss_distance_kilometers = table.Column<string>(type: "TEXT", nullable: false),
                    miss_distance_lunar = table.Column<string>(type: "TEXT", nullable: false),
                    miss_distance_miles = table.Column<string>(type: "TEXT", nullable: false),
                    velocity_kilometers_per_hour = table.Column<string>(type: "TEXT", nullable: false),
                    velocity_kilometers_per_second = table.Column<string>(type: "TEXT", nullable: false),
                    velocity_miles_per_hour = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approaches_asteroids_asteroidId",
                        column: x => x.asteroidId,
                        principalTable: "asteroids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approaches_asteroidId",
                table: "approaches",
                column: "asteroidId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approaches");

            migrationBuilder.DropTable(
                name: "asteroids");
        }
    }
}
