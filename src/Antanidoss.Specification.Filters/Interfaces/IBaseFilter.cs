using Antanidoss.Specification.Interfaces;

namespace Antanidoss.Specification.Filters.Interfaces
{
    public interface IBaseFilter<TResult, TParam, TEntity>
        where TEntity : class
    {
        TResult ApplyFilter(TParam param, ISpecification<TEntity> specification);
    }
}
