using CookDinnerMinimalApi.Controllers;
using CookDinnerMinimalApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Use Kestrel
if (Environment.GetEnvironmentVariable("USE_KESTREL") == "true")
{
    builder.WebHost.UseKestrel();
}

// Dependency Inyection
builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();

// Build App
var app = builder.Build();

// Endpoints
app.MapGet("/environment", () => Environment.GetEnvironmentVariable("USE_KESTREL"));
app.MapSearchRecipe();

app.Run();