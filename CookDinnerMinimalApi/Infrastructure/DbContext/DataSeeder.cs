using Bogus;
using CookDinnerMinimalApi.Domain;
using CookDinnerMinimalApi.Domain.Enums;

namespace CookDinnerMinimalApi.Infrastructure.DbContext;

public static class DataSeeder
{
    public static async Task SeedDataAsync(AppDbContext dbContext)
    {
        if (!dbContext.Recipes.Any())
        {
            var faker = new Faker<Recipe>()
                .RuleFor(r => r.Id, f => f.Random.Guid())
                .RuleFor(r => r.Name, f => f.Lorem.Sentence())
                .RuleFor(r => r.Ingredients, f => f.Make(3, () => f.Commerce.ProductName()))
                .RuleFor(r => r.PreparationTime, f => f.Random.Number(1, 100))
                .RuleFor(r => r.EcumCusineType, f => f.PickRandom<EcumCusineType>())
                .RuleFor(r => r.EnumDifficulty, f => f.PickRandom<EnumDifficultyLevel>())
                .RuleFor(r => r.Likes, f => f.Random.Number(1, 100));
        
            dbContext.Recipes.AddRange(faker.Generate(40));

            await dbContext.SaveChangesAsync();
        }
    }
}
