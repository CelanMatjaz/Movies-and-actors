using ActorsService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString(args.Length == 1 ? args[0] : "Database");

builder.Services.AddDbContext<ActorsDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddResponseCaching();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllerRoute("actors", "{controller=Actors}/{action=GetActors}/{id?}");
app.Run();
