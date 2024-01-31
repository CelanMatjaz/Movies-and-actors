using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actors.Migrations
{
    /// <inheritdoc />
    public partial class InsertDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var date = DateOnly.Parse("1-1-2000");

            for (int i = 0; i < insertDataCount; ++i)
            {
                migrationBuilder.InsertData(
                    "actors",
                    ["first_name", "last_name", "born_date", "list_of_movies"],
                    [$"Actor {i + 1} first name", $"Actor {i + 1} last name", date.AddDays(i), $"Movies {i + 1}"]
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 0; i < insertDataCount; ++i)
            {
                migrationBuilder.DeleteData("actors", "id", 1);
            }
        }

        static uint insertDataCount = 50;
    }
}
