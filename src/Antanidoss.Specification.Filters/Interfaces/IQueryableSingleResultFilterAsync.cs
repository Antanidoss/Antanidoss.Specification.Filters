using System.Linq;
using System.Threading.Tasks;

namespace Antanidoss.Specification.Filters.Interfaces
{
    public interface IQueryableSingleResultFilterAsync<TEntity> : IBaseFilter<Task<TEntity>, IQueryable<TEntity>, TEntity>
        where TEntity : class
    {
    }
}
