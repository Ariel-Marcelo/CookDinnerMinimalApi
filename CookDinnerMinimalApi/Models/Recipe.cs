namespace CookDinnerMinimalApi.Models;

public class Recipe
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public List<string> Ingredients { get; set; }
    
    public int PreparationTime { get; set; }
    
    public CusineType CusineType { get; set; }
    
    public DifficultyLevel Difficulty { get; set; }
    
    public int Likes { get; set; }
}