namespace CookDinnerMinimalApi.Domain;

public class Filter
{
    public string? Field { get; set; }
    
    public string? Operator { get; set; }
    
    public string? Value { get; set; }
}