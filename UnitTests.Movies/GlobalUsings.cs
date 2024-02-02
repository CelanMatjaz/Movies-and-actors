global using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq;
using MoviesService;

public static class SetupFunctions
{
    public static MoviesDbContext CreateMoviesDbContext()
    {
        var dbContextOptions = new DbContextOptionsBuilder<MoviesDbContext>()
                    .UseInMemoryDatabase("db")
                    .Options;

        var dbContext = new MoviesDbContext(dbContextOptions);
        dbContext.Database.EnsureDeleted();

        return dbContext;
    }

    public static void CreateDefaultMovies(MoviesDbContext dbContext, int count)
    {
        for (int i = 0; i < count; ++i)
        {
            var newMovie = new Movie()
            {
                Title = $"Title {i}",
                Description = $"Description {i}",
                ListOfActors = $"Actors {i}",
                Year = (short)(i + 2000),
                ImageLink = $"ImageLink {i}"
            };

            dbContext.Movies.Add(newMovie);
        }

        dbContext.SaveChanges();
    }
}