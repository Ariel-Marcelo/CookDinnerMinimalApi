namespace CookDinnerMinimalApi.Domain.Ports;

public interface IFilterService<T>
{
    IEnumerable<T> ApplyFilters(IEnumerable<T> items, IEnumerable<Filter> filters);
}