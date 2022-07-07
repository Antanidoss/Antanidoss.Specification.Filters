using Antanidoss.Specification.Filters.Interfaces;
using Antanidoss.Specification.Filters.Validations;
using Antanidoss.Specification.Interfaces;
using System;
using System.Linq;

namespace Antanidoss.Specification.Filters.Implementation
{
    public class Where<TEntity> : IQueryableMultipleResultFilter<TEntity>
        where TEntity : class
    {
        public ISpecification<TEntity> Specification { get; private set; }

        public Where(ISpecification<TEntity> specification)
        {
            SpecificationValidator.SetEmptySpecificationIfNull(ref specification);

            Specification = specification;
        }

        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> entities)
        {
            return ToFunc().Invoke(entities);
        }

        public Func<IQueryable<TEntity>, IQueryable<TEntity>> ToFunc()
        {
            return q => q.Where(Specification.ToExpression());
        }
    }
}
