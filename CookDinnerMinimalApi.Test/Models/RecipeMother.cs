using Bogus;
using CookDinnerMinimalApi.Models;

namespace CookDinnerMinimalApi.Test.Models;

public static class RecipeMother
{
    public static List<Recipe> Create(int items = 0)
    {
        return Generate(items < 0 ? 0 : items);
    }

    private static List<Recipe> Generate(int items)
    {
        var faker = new Faker<Recipe>()
            .RuleFor(r => r.Id, f => f.Random.Guid())
            .RuleFor(r => r.Name, f => f.Lorem.Sentence())
            .RuleFor(r => r.Ingredients, f => f.Make(3, () => f.Commerce.ProductName()))
            .RuleFor(r => r.PreparationTime, f => f.Random.Number(1, 100))
            .RuleFor(r => r.CusineType, f => f.PickRandom<CusineType>())
            .RuleFor(r => r.Difficulty, f => f.PickRandom<DifficultyLevel>())
            .RuleFor(r => r.Likes, f => f.Random.Number(1, 100));
        
        return faker.Generate(items);
    }
}