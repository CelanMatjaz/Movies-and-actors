using Microsoft.EntityFrameworkCore;
using Movies.Data;

namespace MoviesService;

public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SeedMovies();
    }
}
