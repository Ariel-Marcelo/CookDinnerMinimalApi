using CookDinnerMinimalApi.Domain;
using CookDinnerMinimalApi.Domain.Ports;

namespace CookDinnerMinimalApi.Application;

public class SearchRecipeUseCase(IRecipeRepository repository, IFilterService service) : ISearchRecipeUseCase
{
    public IEnumerable<Recipe> GetRecipes(IEnumerable<Filter> filters)
    {
        var recipes = repository.GetRecipes();
        return service.ApplyFilters(recipes, filters);
    }
}