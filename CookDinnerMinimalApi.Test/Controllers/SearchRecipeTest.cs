using CookDinnerMinimalApi.Models;
using CookDinnerMinimalApi.Repositories;
using FluentAssertions;

namespace CookDinnerMinimalApi.Test.Controllers;

public class SearchRecipeTest
{
    [Fact]
    public void SearchRecipe_WhenNoAddParameters_GetAllRecipes()
    {
        // Arrange
        IRecipeRepository repository = new RecipeRepository();

        // Act
        var recipes = repository.GetRecipes();

        // Assert
        recipes.Should().BeOfType<List<Recipe>>();
    }
    
    [Fact]
    public void SearchRecipe_WhenSearchByShorterCookingTime_GetAllRecipesOrderShorterCookingTimeFirst()
    {
        // Arrange
        
        // Act
        
        // Assert
        
    }
}