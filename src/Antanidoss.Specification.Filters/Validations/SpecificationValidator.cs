using Antanidoss.Specification.Implementation.Specifications;
using Antanidoss.Specification.Interfaces;

namespace Antanidoss.Specification.Filters.Validations
{
    internal static class SpecificationValidator
    {
        public static void SetEmptySpecificationIfNull<TEntity>(ref ISpecification<TEntity> specification)
            where TEntity : class
        {
            if (specification == null)
                specification = new EmptySpecification<TEntity>();
        }
    }
}
