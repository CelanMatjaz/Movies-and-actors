using MoviesService;
using Microsoft.EntityFrameworkCore;
using CommonData;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<MoviesDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDbContext<RequestEntryDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddResponseCaching();
builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<RequestCountMiddleware>("movies");

app.MapControllerRoute("movies", "{controller=Movies}/{action=GetMovies}/{id?}");
app.Run();
