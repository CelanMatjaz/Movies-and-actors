using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CommonData;

public class MigrationsStartup
{
    public MigrationsStartup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<RequestEntryDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("Database")));
    }
}