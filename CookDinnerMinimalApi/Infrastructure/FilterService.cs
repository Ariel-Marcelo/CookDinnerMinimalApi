using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using CookDinnerMinimalApi.Domain;
using CookDinnerMinimalApi.Domain.Constants;
using CookDinnerMinimalApi.Domain.Ports;

namespace CookDinnerMinimalApi.Infrastructure;

public class FilterService : IFilterService
{
    public IEnumerable<T> ApplyFilters<T>(IEnumerable<T> items, IEnumerable<Filter> filters)
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
    
    public IEnumerable<Filter> ParseFilters(IQueryCollection query)
    {
        var filters = new Dictionary<int, Filter>();

        foreach (var (key, value) in query)
        {
            var match = Regex.Match(key, Patterns.FILTER_PATTERN);

            if (match.Success)
            {
                var index = int.Parse(match.Groups[1].Value);
                var property = match.Groups[2].Value;

                if (!filters.ContainsKey(index))
                {
                    filters[index] = new Filter();
                }

                switch (property)
                {
                    case "field":
                        filters[index].Field = value;
                        break;
                    case "operator":
                        filters[index].Operator = value;
                        break;
                    case "value":
                        filters[index].Value = value;
                        break;
                }
            }
        }

        return filters.Values
            .Where(f => !string.IsNullOrEmpty(f.Field) && 
                        !string.IsNullOrEmpty(f.Value) &&
                        !string.IsNullOrEmpty(f.Operator))
            .ToList();
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