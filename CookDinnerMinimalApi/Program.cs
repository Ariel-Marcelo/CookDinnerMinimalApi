using CookDinnerMinimalApi.Controllers;
using CookDinnerMinimalApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Use Kestrel
builder.WebHost.UseKestrel();

// Dependency Inyection
builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();

// Build App
var app = builder.Build();

// Endpoints
app.MapSearchRecipe();

app.Run();