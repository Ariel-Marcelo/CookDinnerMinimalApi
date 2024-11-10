using System.Text.RegularExpressions;
using CookDinnerMinimalApi.Application;
using CookDinnerMinimalApi.Domain;

namespace CookDinnerMinimalApi.Controllers;

public static class SearchRecipes
{
    public static void MapSearchRecipe(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", (HttpRequest request, ISearchRecipeUseCase useCase) =>
        {
            var filters = ParseFilters(request.Query);
            var recipes = useCase.GetRecipes(filters);
            return Results.Ok(recipes);
        });
    }

    private static FiltersList ParseFilters(IQueryCollection query)
    {
        var filters = new Dictionary<int, Filter>();

        foreach (var (key, value) in query)
        {
            var match = Regex.Match(key, @"filters\[(\d+)]\[(.+)]");

            if (match.Success)
            {
                var index = int.Parse(match.Groups[1].Value);
                var property = match.Groups[2].Value;

                if (!filters.ContainsKey(index))
                {
                    filters[index] = new Filter();
                }

                switch (property)
                {
                    case "field":
                        filters[index].Field = value;
                        break;
                    case "operator":
                        filters[index].Operator = value;
                        break;
                    case "value":
                        filters[index].Value = value;
                        break;
                }
            }
        }

        return new FiltersList(filters.Values
            .Where(f => !string.IsNullOrEmpty(f.Field) && 
                        !string.IsNullOrEmpty(f.Value) &&
                        !string.IsNullOrEmpty(f.Operator))
            .ToList());
    }

}