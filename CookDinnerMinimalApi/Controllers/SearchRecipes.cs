using CookDinnerMinimalApi.Application;
using CookDinnerMinimalApi.Domain.Ports;

namespace CookDinnerMinimalApi.Controllers;

public static class SearchRecipes
{
    public static void MapSearchRecipe(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", (HttpRequest request, ISearchRecipeUseCase useCase, IFilterService service) =>
        {
            var filters = service.ParseFilters(request.Query);
            var recipes = useCase.GetRecipes(filters);
            return Results.Ok(recipes);
        });
    }
}