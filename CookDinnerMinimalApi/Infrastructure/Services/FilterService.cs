using CookDinnerMinimalApi.Domain;
using CookDinnerMinimalApi.Domain.Ports;
using System.Linq.Dynamic.Core;

namespace CookDinnerMinimalApi.Infrastructure.Services;

public class FilterService : IFilterService
{
    public IEnumerable<Recipe> ApplyFilters(IEnumerable<Recipe> items, IEnumerable<Filter> filters)
    {
        var query = items.AsQueryable();

        foreach (var filter in filters)
        {
            if (string.IsNullOrEmpty(filter.Field) || string.IsNullOrEmpty(filter.Operator) || filter.Value == null)
                continue;

            string? predicate = GetPredicate(filter);
            if (!string.IsNullOrEmpty(predicate))
            {
                query = query.Where(predicate, filter.Value);
            }
        }

        return query.ToList();
    }

    private string? GetPredicate(Filter filter)
    {
        return filter.Operator switch
        {
            "Equals" => $"{filter.Field} == @0",
            "Contains" => $"{filter.Field}.Contains(@0)",
            "GreaterThan" => $"{filter.Field} > @0",
            "LessThan" => $"{filter.Field} < @0",
            _ => null,
        };
    }
}