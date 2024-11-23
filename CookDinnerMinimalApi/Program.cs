using CookDinnerMinimalApi.Application;
using CookDinnerMinimalApi.Controllers;
using CookDinnerMinimalApi.Domain.Ports;
using CookDinnerMinimalApi.Infrastructure;
using CookDinnerMinimalApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dependency Inyection
builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();

// Acceder a la configuración
var configuration = builder.Configuration;
var customMessage = configuration["CustomMessage"];
Console.WriteLine($"Custom Message: {customMessage}");

// Build App
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await DataSeeder.SeedDataAsync(dbContext);
}

// Endpoints
app.MapGet("/environment", () => new
{
    Environment = builder.Environment.EnvironmentName,
    CustomMessage = customMessage
});

app.MapSearchRecipe();

app.Run();