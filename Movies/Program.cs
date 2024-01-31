using MoviesService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString(args.Length == 1 ? args[0] : "Database");

builder.Services.AddDbContext<MoviesDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddResponseCaching();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllerRoute("movies", "{controller=Movies}/{action=GetMovies}/{id?}");
app.Run();
