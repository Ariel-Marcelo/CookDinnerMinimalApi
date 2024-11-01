using CookDinnerMinimalApi.Controllers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoints
app.MapSearchRecipe();

app.Run();