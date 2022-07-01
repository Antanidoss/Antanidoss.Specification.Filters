using System.Linq;

namespace Antanidoss.Specification.Filters.Interfaces
{
    public interface IQueryableMultipleResultFilter<TEntity> : IBaseFilter<IQueryable<TEntity>, IQueryable<TEntity>, TEntity>
        where TEntity : class
    {
    }
}
