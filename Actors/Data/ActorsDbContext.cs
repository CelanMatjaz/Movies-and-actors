using ActorsService.Models;
using Microsoft.EntityFrameworkCore;

namespace ActorsService.Data;

public class ActorsDbContext : DbContext
{
    public ActorsDbContext(DbContextOptions<ActorsDbContext> options) : base(options) { }

    public DbSet<Actor> Actors { get; set; }
}
