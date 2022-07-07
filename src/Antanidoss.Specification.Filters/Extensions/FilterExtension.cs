using Antanidoss.Specification.Filters.Implementation;
using Antanidoss.Specification.Filters.Interfaces;
using Antanidoss.Specification.Interfaces;

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

        public static IQueryableSingleResultFilter<TEntity> FirstOrDefault<TEntity>(this IQueryableMultipleResultFilter<TEntity> filter, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var firstOrDefaultFilter = new FirstOrDefault<TEntity>(specification);

            return new ConnectIQueryableSingleResultFilter<TEntity>(filter, firstOrDefaultFilter);
        }

        public static IQueryableMultipleResultFilter<TEntity> Where<TEntity>(this IQueryableMultipleResultFilter<TEntity> filter, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var whereFilter = new Where<TEntity>(specification);

            return new ConnectIQueryableMultipleResultFilter<TEntity>(filter, whereFilter);
        }

        public static IQueryableMultipleResultFilter<TEntity> OrderBy<TEntity>(this IQueryableMultipleResultFilter<TEntity> filter, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var orderByFilter = new OrderBy<TEntity>(specification);

            return new ConnectIQueryableMultipleResultFilter<TEntity>(filter, orderByFilter);
        }

        public static IQueryableMultipleResultFilter<TEntity> Include<TEntity>(this IQueryableMultipleResultFilter<TEntity> filter, ISpecification<TEntity> specification)
            where TEntity : class
        {
            var includeFilter = new Include<TEntity>(specification);

            return new ConnectIQueryableMultipleResultFilter<TEntity>(filter, includeFilter);
        }
    }
}
