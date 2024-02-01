using ActorsService;
using Microsoft.EntityFrameworkCore;

namespace Actors.Data
{
    public static class ActorsSeeder
    {
        public static void SeedActors(this ModelBuilder modelBuilder)
        {
            var date = DateOnly.Parse("1-1-2000");

            for (int i = 0; i < 50; ++i)
            {
                modelBuilder.Entity<Actor>().HasData([
                   new Actor()
                   {
                        Id = 10000 + i,
                        FirstName = $"First Name {i}",
                        LastName = $"Last Name {i}",
                        BornDate = date.AddDays(1),
                        ListOfMovies = $"Movies {i}"
                   }
                ]);
            }
        }
    }
}
