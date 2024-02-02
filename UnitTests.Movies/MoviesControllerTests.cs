using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MoviesService;

namespace UnitTests.Movies;

public class MoviesControllerTests
{
    [Fact]
    public async void GetMovies_ReturnsCorrectCountOfMovies()
    {
        var dbContext = SetupFunctions.CreateMoviesDbContext();
        var controller = new MoviesController(dbContext);

        {
            var result = await controller.GetMovies(null, null);
            var value = Assert.IsAssignableFrom<IEnumerable<Movie>>(result.Value);
            Assert.Empty(value);
        }

        SetupFunctions.CreateDefaultMovies(dbContext, 5);

        {
            var result = await controller.GetMovies(null, null);
            var value = Assert.IsAssignableFrom<IEnumerable<Movie>>(result.Value);
            Assert.Equal(5, value.Count());
        }
    }

    [Fact]
    public async void GetMovies_ReturnsCorrectCountOfMovies_WhenPaginationIsUsed()
    {
        var dbContext = SetupFunctions.CreateMoviesDbContext();
        var controller = new MoviesController(dbContext);
        const int pageSize = 5;

        {
            const int page = 1;
            var result = await controller.GetMovies(pageSize, page);
            var value = Assert.IsAssignableFrom<IEnumerable<Movie>>(result.Value);
            Assert.Empty(value);
        }

        SetupFunctions.CreateDefaultMovies(dbContext, 7);

        {
            const int page = 1;
            var result = await controller.GetMovies(pageSize, page);
            var value = Assert.IsAssignableFrom<IEnumerable<Movie>>(result.Value);
            Assert.Equal(pageSize, value.Count());
        }

        {
            const int page = 2;
            var result = await controller.GetMovies(pageSize, page);
            var value = Assert.IsAssignableFrom<IEnumerable<Movie>>(result.Value);
            Assert.Equal(2, value.Count());
        }

        {
            const int page = 3;
            var result = await controller.GetMovies(pageSize, page);
            var value = Assert.IsAssignableFrom<IEnumerable<Movie>>(result.Value);
            Assert.Empty(value);
        }
    }

    [Fact]
    public async void GetMovies_ReturnsBadRequest_WhenPaginationIsUsedIncorrectly()
    {
        var dbContext = SetupFunctions.CreateMoviesDbContext();
        var controller = new MoviesController(dbContext);

        {
            const int correctPageSize = 10;
            const int incorrectPage = -1;
            var result = await controller.GetMovies(correctPageSize, incorrectPage);
            Assert.Null(result.Value);
        }

        {
            const int incorrectPageSize = -1;
            const int correctPage = 1;
            var result = await controller.GetMovies(incorrectPageSize, correctPage);
            Assert.Null(result.Value);
        }

        {
            const int incorrectPageSize = -1;
            const int incorrectPage = -1;
            var result = await controller.GetMovies(incorrectPageSize, incorrectPage);
            Assert.Null(result.Value);
        }
    }

    [Fact]
    public async void GetMovie_ReturnsNotFound_WhenAnIdThatDoesNotExistIsProvided()
    {
        var dbContext = SetupFunctions.CreateMoviesDbContext();
        var controller = new MoviesController(dbContext);

        {
            var result = await controller.GetMovie(9999999);
            var notFoundResult = Assert.IsAssignableFrom<NotFoundResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        SetupFunctions.CreateDefaultMovies(dbContext, 1);

        {
            var firstExistingMovie = dbContext.Movies.ToList()[0];
            var result = await controller.GetMovie(firstExistingMovie.Id);
            Assert.IsAssignableFrom<ActionResult<Movie>>(result);
        }
    }

    [Fact]
    public async void PostMovie_CreatesAndReturnsNewMovie()
    {
        var dbContext = SetupFunctions.CreateMoviesDbContext();
        var controller = new MoviesController(dbContext);

        {
            var newMovie = new Movie()
            {
                Title = "New movie",
                Description = "New description",
                ListOfActors = "New list of actors",
                Year = 2000,
                ImageLink = "New image link"
            };

            var result = await controller.PostMovie(newMovie);
            var statusCodeResult = Assert.IsAssignableFrom<CreatedAtActionResult>(result.Result);
            Assert.Equal(201, statusCodeResult.StatusCode);
        }
    }

    [Fact]
    public async void PutMovie_UpdatesMovieCorrectlyWithoutErrors()
    {
        var dbContext = SetupFunctions.CreateMoviesDbContext();
        var controller = new MoviesController(dbContext);

        const string newTitle = "New movie";
        const string newDescription = "New description";
        const string newListOfActors = "New list of actors";
        const int newYear = 2000;
        const string newImageLink = "New image link";

        var newMovie = new Movie()
        {
            Title = newTitle,
            Description = newDescription,
            ListOfActors = newListOfActors,
            Year = newYear,
            ImageLink = newImageLink
        };

        dbContext.Movies.Add(newMovie);
        dbContext.SaveChanges();

        {
            var updatedMovie = new Movie()
            {
                Id = newMovie.Id,
                Title = newTitle + " updated",
                Description = newDescription + " updated",
                ListOfActors = newListOfActors + " updated",
                Year = newYear + 1,
                ImageLink = newImageLink + " updated"
            };

            var result = await controller.PutMovie(updatedMovie.Id, updatedMovie);
            var statusCodeResult = Assert.IsAssignableFrom<NoContentResult>(result);
            Assert.Equal(204, statusCodeResult.StatusCode);

            var movie = dbContext.Movies.Find(updatedMovie.Id);
            Assert.NotNull(movie);

            Assert.Equal(newTitle + " updated", movie.Title);
            Assert.Equal(newDescription + " updated", movie.Description);
            Assert.Equal(newListOfActors + " updated", movie.ListOfActors);
            Assert.Equal(newYear + 1, movie.Year);
            Assert.Equal(newImageLink + " updated", movie.ImageLink);
        }

        {
            var updatedMovie = new Movie()
            {
                Id = 999999,
                Title = newTitle + " updated",
                Description = newDescription + " updated",
                ListOfActors = newListOfActors + " updated",
                Year = newYear + 1,
                ImageLink = newImageLink + " updated"
            };

            var result = await controller.PutMovie(updatedMovie.Id, updatedMovie);
            var statusCodeResult = Assert.IsAssignableFrom<NotFoundResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
    }

    [Fact]
    public async void DeleteMovie_DeletesTheRightMovie_WithoutErrors()
    {
        var dbContext = SetupFunctions.CreateMoviesDbContext();
        var controller = new MoviesController(dbContext);

        SetupFunctions.CreateDefaultMovies(dbContext, 5);
        Assert.Equal(5, dbContext.Movies.Count());

        {
            var firstExistingMovieId = dbContext.Movies.ToList()[0].Id;
            var result = await controller.DeleteMovie(firstExistingMovieId);
            var statusCodeResult = Assert.IsAssignableFrom<NoContentResult>(result);
            Assert.Equal(204, statusCodeResult.StatusCode);
            Assert.Equal(4, dbContext.Movies.Count());

            var foundDeletedMovie = dbContext.Movies.Find(firstExistingMovieId);
            Assert.Null(foundDeletedMovie);
        }

        {
            var result = await controller.DeleteMovie(999999);
            var statusCodeResult = Assert.IsAssignableFrom<NotFoundResult>(result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
    }
}