using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CommonData;

public class RequestEntryDbContext : DbContext
{
    public RequestEntryDbContext(DbContextOptions<RequestEntryDbContext> options) : base(options) { }

    public DbSet<RequestCountEntry> Entries { get; set; }
}

public class RequestEntryDbContextFactory : IDesignTimeDbContextFactory<RequestEntryDbContext>
{
    public RequestEntryDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<RequestEntryDbContext>();
        var connectionString = configuration.GetConnectionString("Database");
        builder.UseNpgsql(connectionString);

        return new RequestEntryDbContext(builder.Options);
    }
}