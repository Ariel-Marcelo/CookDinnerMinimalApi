using CookDinnerMinimalApi.Domain;

namespace CookDinnerMinimalApi.Application;

public interface ISearchRecipeUseCase
{
    public IEnumerable<Recipe> GetRecipes(FiltersList filters);
}