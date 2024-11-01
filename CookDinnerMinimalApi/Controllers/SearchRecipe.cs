
using CookDinnerMinimalApi.Repositories;

namespace CookDinnerMinimalApi.Controllers;

public static class SearchRecipe
{
    public static void MapSearchRecipe(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", (IRecipeRepository repository) =>
        {
            var recipes = repository.GetRecipes();
            return Results.Ok(recipes);
        });
    }
}