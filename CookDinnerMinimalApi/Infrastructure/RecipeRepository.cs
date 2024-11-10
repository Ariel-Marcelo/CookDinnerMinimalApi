using Bogus;
using CookDinnerMinimalApi.Domain;
using CookDinnerMinimalApi.Domain.Ports;
using CookDinnerMinimalApi.Infrastructure.Services;

namespace CookDinnerMinimalApi.Infrastructure;

public class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _context;
    
    public RecipeRepository(AppDbContext context, int items = 30)
    {
        _context = context;
        var faker = new Faker<Recipe>()
            .RuleFor(r => r.Id, f => f.Random.Guid())
            .RuleFor(r => r.Name, f => f.Lorem.Sentence())
            .RuleFor(r => r.Ingredients, f => f.Make(3, () => f.Commerce.ProductName()))
            .RuleFor(r => r.PreparationTime, f => f.Random.Number(1, 100))
            .RuleFor(r => r.CusineType, f => f.PickRandom<CusineType>())
            .RuleFor(r => r.Difficulty, f => f.PickRandom<DifficultyLevel>())
            .RuleFor(r => r.Likes, f => f.Random.Number(1, 100));
        
        _context.Recipes.AddRange(faker.Generate(items));
        
        
    }

    public IQueryable<Recipe> GetRecipes()
    {
        return _context.Recipes.AsQueryable();
    }

    public void AddRecipe(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}