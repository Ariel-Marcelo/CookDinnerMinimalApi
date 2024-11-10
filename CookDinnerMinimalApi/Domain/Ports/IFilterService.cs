namespace CookDinnerMinimalApi.Domain.Ports;

public interface IFilterService
{
    IEnumerable<Recipe> ApplyFilters(IEnumerable<Recipe> items, IEnumerable<Filter> filters);
}