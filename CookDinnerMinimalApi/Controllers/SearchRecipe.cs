namespace CookDinnerMinimalApi.Controllers;

public static class SearchRecipe
{
    public static void MapSearchRecipe(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", () => "Hello World!");
    }

    
}