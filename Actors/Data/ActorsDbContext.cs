using Microsoft.EntityFrameworkCore;

namespace ActorsService;

public class ActorsDbContext : DbContext
{
    public ActorsDbContext(DbContextOptions<ActorsDbContext> options) : base(options) { }

    public DbSet<Actor> Actors { get; set; }
}
