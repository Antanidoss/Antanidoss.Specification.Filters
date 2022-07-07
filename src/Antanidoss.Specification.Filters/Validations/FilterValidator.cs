using Antanidoss.Specification.Filters.Interfaces;
using System;

namespace Antanidoss.Specification.Filters.Validations
{
    internal static class FilterValidator
    {
        public static void ThrowExceptionIfNull<TResult, TParam, TEntity>(IBaseFilter<TResult, TParam, TEntity> filter)
            where TEntity : class
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
        }
    }
}
