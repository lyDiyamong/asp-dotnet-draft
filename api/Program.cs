// Create a builder for the web application using command-line arguments.
using api.Data;
using api.Interfaces;
using api.Repositories;
using api.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers(options =>
{
    options.Conventions.Insert(0, new RoutePrefixConvention("api/v1"));
});
// NewtonJson
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// In Program.cs or Startup.cs
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Register controllers
app.MapControllers();

app.Run();
