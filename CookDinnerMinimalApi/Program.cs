using CookDinnerMinimalApi.Controllers;
using CookDinnerMinimalApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Dependency Inyection
builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();

// Acceder a la configuración
var configuration = builder.Configuration;
var customMessage = configuration["CustomMessage"];
Console.WriteLine($"Custom Message: {customMessage}");

// Build App
var app = builder.Build();

// Endpoints
app.MapGet("/environment", () => new
{
    Environment = builder.Environment.EnvironmentName,
    CustomMessage = customMessage
});

app.MapSearchRecipe();

app.Run();