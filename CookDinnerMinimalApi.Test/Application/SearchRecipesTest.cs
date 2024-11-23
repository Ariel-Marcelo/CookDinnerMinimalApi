using CookDinnerMinimalApi.Application;
using CookDinnerMinimalApi.Domain;
using CookDinnerMinimalApi.Domain.Enums;
using CookDinnerMinimalApi.Domain.Ports;
using FluentAssertions;
using Moq;

namespace CookDinnerMinimalApi.Test.Application;

public class SearchRecipesTest
{
    [Fact]
    public void GetRecipes_WhenAddFiltersList_ShouldGetRecipesWithFiltersApplied()
    {
        // Arrange
        var filtersList = GivenFiltersList();
        var sampleRecipes = AndSampleRecipes();
        var expectedResponse = ExpectedResponse();
        // And Mock Repository
        var mockRepository = new Mock<IRecipeRepository>();
        mockRepository.Setup(repo => repo.GetRecipes()).Returns(sampleRecipes);
        // And Mock Filter Service
        var mockService = new Mock<IFilterService>();
        mockService
            .Setup(filterService => filterService.ApplyFilters(sampleRecipes, filtersList))
            .Returns(expectedResponse);
        // And UseCase instance
        var searchRecipe = new SearchRecipeUseCase(mockRepository.Object, mockService.Object);

        // Act
        var result = searchRecipe.GetRecipes(filtersList);

        // Assert
        var enumerable = result.ToList();
        enumerable.Should().ContainSingle();
        enumerable.First().Name.Should().Be("Spaghetti");

        mockService.Verify(filterService => filterService.ApplyFilters(sampleRecipes, filtersList),
            Times.Once);
    }

    private static List<Recipe> ExpectedResponse()
    {
        return [new Recipe { Name = "Spaghetti", PreparationTime = 20, EnumDifficulty = EnumDifficultyLevel.Medium }];
    }

    private static IQueryable<Recipe> AndSampleRecipes()
    {
        return new List<Recipe>
        {
            new Recipe { Name = "Spaghetti", PreparationTime = 20, EnumDifficulty = EnumDifficultyLevel.Medium },
            new Recipe { Name = "Salad", PreparationTime = 10, EnumDifficulty = EnumDifficultyLevel.Easy },
            new Recipe { Name = "Curry", PreparationTime = 40, EnumDifficulty = EnumDifficultyLevel.Hard }
        }.AsQueryable();
    }

    private static IEnumerable<Filter> GivenFiltersList()
    {
        var filters = new List<Filter>
        {
            new Filter { Field = "PreparationTime", Operator = "LessThan", Value = "30" },
            new Filter { Field = "Difficulty", Operator = "Equals", Value = "Medium" }
        };
        return filters;
    }
}