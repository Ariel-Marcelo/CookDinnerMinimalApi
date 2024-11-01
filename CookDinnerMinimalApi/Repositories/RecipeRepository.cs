using Bogus;
using CookDinnerMinimalApi.Models;

namespace CookDinnerMinimalApi.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly List<Recipe> recipes = [];

    public RecipeRepository(int items = 30)
    {
        var faker = new Faker<Recipe>()
            .RuleFor(r => r.Id, f => f.Random.Guid())
            .RuleFor(r => r.Name, f => f.Lorem.Sentence())
            .RuleFor(r => r.Ingredients, f => f.Make(3, () => f.Commerce.ProductName()))
            .RuleFor(r => r.PreparationTime, f => f.Random.Number(1, 100))
            .RuleFor(r => r.CusineType, f => f.PickRandom<CusineType>())
            .RuleFor(r => r.Difficulty, f => f.PickRandom<DifficultyLevel>())
            .RuleFor(r => r.Likes, f => f.Random.Number(1, 100));
        recipes = faker.Generate(items);
    }

    public ICollection<Recipe> GetRecipes(string? name = null, string? ingredient = null, int? cookingTime = null,
        DifficultyLevel? difficultyLevel = null,
        int? likes = null)
    {
        return recipes;
    }
}