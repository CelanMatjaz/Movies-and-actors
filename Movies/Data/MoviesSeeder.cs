using Microsoft.EntityFrameworkCore;
using MoviesService;

namespace Movies.Data
{
    public static class MoviesSeeder
    {
        public static void SeedMovies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData([
                new Movie() {
                    Id = 10001,
                    Title = "Argylle",
                    Year = 2024,
                    Description = "A reclusive author who writes espionage novels about a secret agent...",
                    ListOfActors = "Actor 1, Actor 2, Actor 3",
                    ImageLink = "https://m.media-amazon.com/images/M/MV5BZDM3YTg4MGUtZmUxNi00YmEyLTllNTctNjYyNjZlZGViNmFhXkEyXkFqcGdeQXVyMTUzMTg2ODkz._V1_UX140_CR0,0,140,209_AL_.jpg"
                },
                new Movie()
                {
                    Id = 10002,
                    Title = "Mr. & Mrs. Smith",
                    Year = 2024,
                    Description = "Two strangers land jobs with a spy agency that offers them a life of espionage, wealth, and travel. The catch: new identities in an arranged marriage.",
                    ListOfActors = "Actor 1, Actor 2, Actor 3",
                    ImageLink = "https://m.media-amazon.com/images/M/MV5BMDE0M2YyM2UtODRmNC00YjAyLWIwMjktOTAwMDBiYjBhMGZmXkEyXkFqcGdeQXVyMjkwOTAyMDU@._V1_UY209_CR0,0,140,209_AL_.jpg"
                }
            ]);
        }
    }
}
