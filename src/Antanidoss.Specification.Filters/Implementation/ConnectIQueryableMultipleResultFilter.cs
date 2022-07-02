using Antanidoss.Specification.Builders;
using Antanidoss.Specification.Filters.Interfaces;
using Antanidoss.Specification.Interfaces;
using System;
using System.Linq;

namespace Antanidoss.Specification.Filters.Implementation
{
    public class ConnectIQueryableMultipleResultFilter<TEntity> : IQueryableMultipleResultFilter<TEntity>
        where TEntity : class
    {
        public ISpecification<TEntity> Specification { get; private set; }

        private readonly IQueryableMultipleResultFilter<TEntity> _firstmultipleResultFilter;

        private readonly IQueryableMultipleResultFilter<TEntity> _secondResultFilter;

        public ConnectIQueryableMultipleResultFilter(IQueryableMultipleResultFilter<TEntity> firstmultipleResultFilter, IQueryableMultipleResultFilter<TEntity> secondResultFilter)
        {
            _firstmultipleResultFilter = firstmultipleResultFilter;
            _secondResultFilter = secondResultFilter;

            Specification = _firstmultipleResultFilter.Specification.And(_secondResultFilter.Specification);
        }

        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> entities)
        {
            return ToFunc().Invoke(entities);
        }

        public Func<IQueryable<TEntity>, IQueryable<TEntity>> ToFunc()
        {
            return q => _secondResultFilter.ToFunc().Invoke(_firstmultipleResultFilter.ToFunc().Invoke(q));
        }
    }
}
