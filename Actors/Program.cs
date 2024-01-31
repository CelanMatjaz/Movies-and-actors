using ActorsService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<ActorsDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();
app.Run();
