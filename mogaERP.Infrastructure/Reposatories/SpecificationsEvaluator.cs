using mogaERP.Domain.Specifications;

namespace mogaERP.Infrastructure.Reposatories;
public static class SpecificationsEvaluator<TEntity> where TEntity : class
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
    {
        var query = inputQuery;

        if (spec.Criteria is not null)
            query = query.Where(spec.Criteria);

        if (spec.OrderBy != null)
            query = query.OrderBy(spec.OrderBy);
        else if (spec.OrderByDescending != null)
            query = query.OrderByDescending(spec.OrderByDescending);

        if (spec.IsPaginationEnabled)
            query = query.Skip(spec.Skip).Take(spec.Take);

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        if (spec.IncludeStrings != null)
        {
            foreach (var includeString in spec.IncludeStrings)
            {
                query = query.Include(includeString);
            }
        }

        if (spec.AsNoTracking)
            query = query.AsNoTracking();

        return query;
    }
}