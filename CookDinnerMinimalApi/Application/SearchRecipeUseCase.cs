using CookDinnerMinimalApi.Domain;
using CookDinnerMinimalApi.Domain.Ports;

namespace CookDinnerMinimalApi.Application;

public class SearchRecipeUseCase(IRecipeRepository repository, IFilterService<Recipe> filter ) : ISearchRecipeUseCase
{
    public IEnumerable<Recipe> GetRecipes(FiltersList filters)
    {
        var recipes = repository.GetRecipes();
        return filter.ApplyFilters(recipes, filters.GetValue());
    }
}