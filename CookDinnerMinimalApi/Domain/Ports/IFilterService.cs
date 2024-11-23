namespace CookDinnerMinimalApi.Domain.Ports;

public interface IFilterService
{
    IEnumerable<T> ApplyFilters<T>(IEnumerable<T> items, IEnumerable<Filter> filters);
    IEnumerable<Filter> ParseFilters(IQueryCollection query);
}