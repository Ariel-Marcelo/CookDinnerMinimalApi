using CookDinnerMinimalApi.Domain.Enums;

namespace CookDinnerMinimalApi.Domain;

public class Recipe
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public List<string>? Ingredients { get; set; }
    
    public int PreparationTime { get; set; }
    
    public EcumCusineType EcumCusineType { get; set; }
    
    public EnumDifficultyLevel EnumDifficulty { get; set; }
    
    public int Likes { get; set; }
}