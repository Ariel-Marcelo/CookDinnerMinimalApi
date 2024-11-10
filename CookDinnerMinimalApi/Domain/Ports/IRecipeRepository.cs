namespace CookDinnerMinimalApi.Domain.Ports;

public interface IRecipeRepository
{
    public IQueryable<Recipe> GetRecipes();
    
    public void AddRecipe(Recipe recipe);
    
    Task SaveChangesAsync();
}