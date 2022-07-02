using Antanidoss.Specification.Interfaces;
using System;

namespace Antanidoss.Specification.Filters.Interfaces
{
    public interface IBaseFilter<TResult, TParam, TEntity>
        where TEntity : class
    {
        ISpecification<TEntity> Specification { get; }

        TResult ApplyFilter(TParam param);
        Func<TParam, TResult> ToFunc(); 
    }
}
