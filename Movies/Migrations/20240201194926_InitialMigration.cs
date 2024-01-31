using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<short>(type: "smallint", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    list_of_actors = table.Column<string>(type: "text", nullable: false),
                    image_link = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "id", "description", "image_link", "list_of_actors", "title", "year" },
                values: new object[,]
                {
                    { 10001, "A reclusive author who writes espionage novels about a secret agent...", "https://m.media-amazon.com/images/M/MV5BZDM3YTg4MGUtZmUxNi00YmEyLTllNTctNjYyNjZlZGViNmFhXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_UX140_CR0,0,140,209_AL_.jpg", "Actor 1, Actor 2, Actor 3", "Argylle", (short)2024 },
                    { 10002, "Two strangers land jobs with a spy agency that offers them a life of espionage, wealth, and travel. The catch: new identities in an arranged marriage.", "https://m.media-amazon.com/images/M/MV5BMDE0M2YyM2UtODRmNC00YjAyLWIwMjktOTAwMDBiYjBhMGZmXkEyXkFqcGdeQXVyMjkwOTAyMDU@._V1_UY209_CR0,0,140,209_AL_.jpg", "Actor 1, Actor 2, Actor 3", "Mr. & Mrs. Smith", (short)2024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
