using Actors.Data;
using Microsoft.EntityFrameworkCore;

namespace ActorsService;

public class ActorsDbContext : DbContext
{
    public ActorsDbContext(DbContextOptions<ActorsDbContext> options) : base(options) { }

    public DbSet<Actor> Actors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SeedActors();
    }
}
