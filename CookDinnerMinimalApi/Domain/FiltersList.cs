namespace CookDinnerMinimalApi.Domain;

public class FiltersList(List<Filter> filters)
{
    public IEnumerable<Filter> GetValue()
    {
        return filters;
    }
}