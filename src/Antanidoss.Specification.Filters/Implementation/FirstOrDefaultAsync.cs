using Antanidoss.Specification.Filters.Interfaces;
using Antanidoss.Specification.Filters.Validations;
using Antanidoss.Specification.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Antanidoss.Specification.Filters.Implementation
{
    public class FirstOrDefaultAsync<TEntity> : IQueryableSingleResultFilterAsync<TEntity>
        where TEntity : class
    {
        public ISpecification<TEntity> Specification { get; private set; }

        public FirstOrDefaultAsync(ISpecification<TEntity> specification)
        {
            SpecificationValidator.SetEmptySpecificationIfNull(ref specification);

            Specification = specification;
        }

        public async Task<TEntity> ApplyFilter(IQueryable<TEntity> entities)
        {
            return await ToFunc().Invoke(entities);
        }

        public Func<IQueryable<TEntity>, Task<TEntity>> ToFunc()
        {
            return async q => await q.FirstOrDefaultAsync(Specification.ToExpression());
        }
    }
}
