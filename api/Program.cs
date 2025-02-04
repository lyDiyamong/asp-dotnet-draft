// Create a builder for the web application using command-line arguments.
using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This is where you register application services with the dependency injection container.
// In this case, we're adding OpenAPI support (for API documentation).
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDBContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Build the web application from the builder configuration.
var app = builder.Build();

// Configure the HTTP request pipeline.
// This section sets up middleware components that handle incoming HTTP requests.

// Check if the application is running in a development environment.
if (app.Environment.IsDevelopment())
{
    // In development, map the OpenAPI endpoint.
    // This allows you to see generated OpenAPI (Swagger) documentation at runtime.
    // http://localhost:5172/openapi/v1.json
    app.MapOpenApi();
}

// Add middleware to redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Run the web application.
// This starts listening for incoming HTTP requests.
app.Run();
