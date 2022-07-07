using Antanidoss.Specification.Builders;
using Antanidoss.Specification.Filters.Interfaces;
using Antanidoss.Specification.Filters.Validations;
using Antanidoss.Specification.Interfaces;
using System;
using System.Linq;

namespace Antanidoss.Specification.Filters.Implementation
{
    public class ConnectIQueryableSingleResultFilter<TEntity> : IQueryableSingleResultFilter<TEntity>
        where TEntity : class
    {
        public ISpecification<TEntity> Specification { get; private set; }

        private readonly IQueryableMultipleResultFilter<TEntity> _firstMultipleResultFilter;

        private readonly IQueryableSingleResultFilter<TEntity> _secondResultFilter;

        public ConnectIQueryableSingleResultFilter(IQueryableMultipleResultFilter<TEntity> firstMultipleResultFilter, IQueryableSingleResultFilter<TEntity> secondResultFilter)
        {
            FilterValidator.ThrowExceptionIfNull(firstMultipleResultFilter);
            FilterValidator.ThrowExceptionIfNull(secondResultFilter);

            _firstMultipleResultFilter = firstMultipleResultFilter;
            _secondResultFilter = secondResultFilter;

            Specification = _firstMultipleResultFilter.Specification.And(_secondResultFilter.Specification);
        }

        public TEntity ApplyFilter(IQueryable<TEntity> entities)
        {
            return ToFunc().Invoke(entities);
        }

        public Func<IQueryable<TEntity>, TEntity> ToFunc()
        {
            return q => _secondResultFilter.ToFunc().Invoke(_firstMultipleResultFilter.ToFunc().Invoke(q));
        }
    }
}
