using Antanidoss.Specification.Filters.Implementation;
using Antanidoss.Specification.Filters.Interfaces;

namespace Antanidoss.Specification.Filters.Extensions
{
    public static class FilterBuilder
    {
        public static IQueryableMultipleResultFilter<TEntity> Connect<TEntity>(this IQueryableMultipleResultFilter<TEntity> firstFilter, IQueryableMultipleResultFilter<TEntity> secondFilter)
            where TEntity : class
        {
            return new ConnectIQueryableMultipleResultFilter<TEntity>(firstFilter, secondFilter);
        }

        public static IQueryableSingleResultFilter<TEntity> Connect<TEntity>(this IQueryableMultipleResultFilter<TEntity> firstFilter, IQueryableSingleResultFilter<TEntity> secondFilter)
            where TEntity : class
        {
            return new ConnectIQueryableSingleResultFilter<TEntity>(firstFilter, secondFilter);
        }
    }
}
