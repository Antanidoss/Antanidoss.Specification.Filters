﻿using Antanidoss.Specification.Filters.Interfaces;
using Antanidoss.Specification.Interfaces;
using System;
using System.Linq;

namespace Antanidoss.Specification.Filters.Implementation
{
    internal class FirstOrDefault<TEntity> : IQueryableSingleResultFilter<TEntity>
        where TEntity : class
    {
        public ISpecification<TEntity> Specification { get; private set; }

        public FirstOrDefault(ISpecification<TEntity> specification)
        {
            Specification = specification;
        }

        public TEntity ApplyFilter(IQueryable<TEntity> entities)
        {
            return ToFunc().Invoke(entities);
        }

        public Func<IQueryable<TEntity>, TEntity> ToFunc()
        {
            return q => q.FirstOrDefault(Specification.ToExpression());
        }
    }
}
