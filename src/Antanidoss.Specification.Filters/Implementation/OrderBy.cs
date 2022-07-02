using Antanidoss.Specification.Filters.Interfaces;
using Antanidoss.Specification.Interfaces;
using System;
using System.Linq;

namespace Antanidoss.Specification.Filters.Implementation
{
    internal class OrderBy<TEntity> : IQueryableMultipleResultFilter<TEntity>
        where TEntity : class
    {
        public ISpecification<TEntity> Specification { get; private set; }

        public OrderBy(ISpecification<TEntity> specification)
        {
            Specification = specification;
        }

        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> entities)
        {
            return ToFunc().Invoke(entities);
        }

        public Func<IQueryable<TEntity>, IQueryable<TEntity>> ToFunc()
        {
            return q => q.OrderBy(Specification.ToExpression());
        }
    }
}
