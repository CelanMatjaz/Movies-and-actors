using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class InsertDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // movies taken from https://www.imdb.com/list/ls524330659/?ref_=hm_edcft_sw_pks_feb24_1_i

            migrationBuilder.InsertData(
                "movies",
                ["title", "year", "description", "list_of_actors", "image_link"],
                ["Argylle", 2024, "A reclusive author who writes espionage novels about a secret agent and a global spy syndicate realizes the plot of the new book she's writing starts to mirror real-world events, in real time.", "Actor 1, Actor 2, Actor 3", "https://m.media-amazon.com/images/M/MV5BZDM3YTg4MGUtZmUxNi00YmEyLTllNTctNjYyNjZlZGViNmFhXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_UX140_CR0,0,140,209_AL_.jpg"]
            );

            migrationBuilder.InsertData(
                "movies",
                ["title", "year", "description", "list_of_actors", "image_link"],
                ["Mr. & Mrs. Smith", 2024, "Two strangers land jobs with a spy agency that offers them a life of espionage, wealth, and travel. The catch: new identities in an arranged marriage.", "Actor 1, Actor 2, Actor 3", "https://m.media-amazon.com/images/M/MV5BMDE0M2YyM2UtODRmNC00YjAyLWIwMjktOTAwMDBiYjBhMGZmXkEyXkFqcGdeQXVyMjkwOTAyMDU@._V1_UY209_CR0,0,140,209_AL_.jpg"]
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
