using System.Linq;

namespace Antanidoss.Specification.Filters.Interfaces
{
    public interface IQueryableSingleResultFilter<TEntity> : IBaseFilter<TEntity, IQueryable<TEntity>, TEntity>
        where TEntity : class
    {
    }
}
