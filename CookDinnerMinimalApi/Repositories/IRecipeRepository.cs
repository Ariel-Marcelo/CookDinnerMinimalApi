using CookDinnerMinimalApi.Models;

namespace CookDinnerMinimalApi.Repositories;

public interface IRecipeRepository
{
    public ICollection<Recipe> GetRecipes(string? name = null, string? ingredient = null, int? cookingTime = null,
        DifficultyLevel? difficultyLevel = null,
        int? likes = null);
}