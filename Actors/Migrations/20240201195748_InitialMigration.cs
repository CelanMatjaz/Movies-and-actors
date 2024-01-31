using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Actors.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    born_date = table.Column<DateOnly>(type: "date", nullable: false),
                    list_of_movies = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "id", "born_date", "first_name", "last_name", "list_of_movies" },
                values: new object[,]
                {
                    { 10000, new DateOnly(2000, 1, 2), "First Name 0", "Last Name 0", "Movies 0" },
                    { 10001, new DateOnly(2000, 1, 2), "First Name 1", "Last Name 1", "Movies 1" },
                    { 10002, new DateOnly(2000, 1, 2), "First Name 2", "Last Name 2", "Movies 2" },
                    { 10003, new DateOnly(2000, 1, 2), "First Name 3", "Last Name 3", "Movies 3" },
                    { 10004, new DateOnly(2000, 1, 2), "First Name 4", "Last Name 4", "Movies 4" },
                    { 10005, new DateOnly(2000, 1, 2), "First Name 5", "Last Name 5", "Movies 5" },
                    { 10006, new DateOnly(2000, 1, 2), "First Name 6", "Last Name 6", "Movies 6" },
                    { 10007, new DateOnly(2000, 1, 2), "First Name 7", "Last Name 7", "Movies 7" },
                    { 10008, new DateOnly(2000, 1, 2), "First Name 8", "Last Name 8", "Movies 8" },
                    { 10009, new DateOnly(2000, 1, 2), "First Name 9", "Last Name 9", "Movies 9" },
                    { 10010, new DateOnly(2000, 1, 2), "First Name 10", "Last Name 10", "Movies 10" },
                    { 10011, new DateOnly(2000, 1, 2), "First Name 11", "Last Name 11", "Movies 11" },
                    { 10012, new DateOnly(2000, 1, 2), "First Name 12", "Last Name 12", "Movies 12" },
                    { 10013, new DateOnly(2000, 1, 2), "First Name 13", "Last Name 13", "Movies 13" },
                    { 10014, new DateOnly(2000, 1, 2), "First Name 14", "Last Name 14", "Movies 14" },
                    { 10015, new DateOnly(2000, 1, 2), "First Name 15", "Last Name 15", "Movies 15" },
                    { 10016, new DateOnly(2000, 1, 2), "First Name 16", "Last Name 16", "Movies 16" },
                    { 10017, new DateOnly(2000, 1, 2), "First Name 17", "Last Name 17", "Movies 17" },
                    { 10018, new DateOnly(2000, 1, 2), "First Name 18", "Last Name 18", "Movies 18" },
                    { 10019, new DateOnly(2000, 1, 2), "First Name 19", "Last Name 19", "Movies 19" },
                    { 10020, new DateOnly(2000, 1, 2), "First Name 20", "Last Name 20", "Movies 20" },
                    { 10021, new DateOnly(2000, 1, 2), "First Name 21", "Last Name 21", "Movies 21" },
                    { 10022, new DateOnly(2000, 1, 2), "First Name 22", "Last Name 22", "Movies 22" },
                    { 10023, new DateOnly(2000, 1, 2), "First Name 23", "Last Name 23", "Movies 23" },
                    { 10024, new DateOnly(2000, 1, 2), "First Name 24", "Last Name 24", "Movies 24" },
                    { 10025, new DateOnly(2000, 1, 2), "First Name 25", "Last Name 25", "Movies 25" },
                    { 10026, new DateOnly(2000, 1, 2), "First Name 26", "Last Name 26", "Movies 26" },
                    { 10027, new DateOnly(2000, 1, 2), "First Name 27", "Last Name 27", "Movies 27" },
                    { 10028, new DateOnly(2000, 1, 2), "First Name 28", "Last Name 28", "Movies 28" },
                    { 10029, new DateOnly(2000, 1, 2), "First Name 29", "Last Name 29", "Movies 29" },
                    { 10030, new DateOnly(2000, 1, 2), "First Name 30", "Last Name 30", "Movies 30" },
                    { 10031, new DateOnly(2000, 1, 2), "First Name 31", "Last Name 31", "Movies 31" },
                    { 10032, new DateOnly(2000, 1, 2), "First Name 32", "Last Name 32", "Movies 32" },
                    { 10033, new DateOnly(2000, 1, 2), "First Name 33", "Last Name 33", "Movies 33" },
                    { 10034, new DateOnly(2000, 1, 2), "First Name 34", "Last Name 34", "Movies 34" },
                    { 10035, new DateOnly(2000, 1, 2), "First Name 35", "Last Name 35", "Movies 35" },
                    { 10036, new DateOnly(2000, 1, 2), "First Name 36", "Last Name 36", "Movies 36" },
                    { 10037, new DateOnly(2000, 1, 2), "First Name 37", "Last Name 37", "Movies 37" },
                    { 10038, new DateOnly(2000, 1, 2), "First Name 38", "Last Name 38", "Movies 38" },
                    { 10039, new DateOnly(2000, 1, 2), "First Name 39", "Last Name 39", "Movies 39" },
                    { 10040, new DateOnly(2000, 1, 2), "First Name 40", "Last Name 40", "Movies 40" },
                    { 10041, new DateOnly(2000, 1, 2), "First Name 41", "Last Name 41", "Movies 41" },
                    { 10042, new DateOnly(2000, 1, 2), "First Name 42", "Last Name 42", "Movies 42" },
                    { 10043, new DateOnly(2000, 1, 2), "First Name 43", "Last Name 43", "Movies 43" },
                    { 10044, new DateOnly(2000, 1, 2), "First Name 44", "Last Name 44", "Movies 44" },
                    { 10045, new DateOnly(2000, 1, 2), "First Name 45", "Last Name 45", "Movies 45" },
                    { 10046, new DateOnly(2000, 1, 2), "First Name 46", "Last Name 46", "Movies 46" },
                    { 10047, new DateOnly(2000, 1, 2), "First Name 47", "Last Name 47", "Movies 47" },
                    { 10048, new DateOnly(2000, 1, 2), "First Name 48", "Last Name 48", "Movies 48" },
                    { 10049, new DateOnly(2000, 1, 2), "First Name 49", "Last Name 49", "Movies 49" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actors");
        }
    }
}
