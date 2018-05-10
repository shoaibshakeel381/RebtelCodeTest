using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.Specifications
{
    public interface ISpecification<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        Expression<Func<TEntity, bool>> Criteria { get; }

        List<Expression<Func<TEntity, object>>> Includes { get; }

        List<string> IncludeStrings { get; }

        bool IsSatisfiedBy(TEntity item);
    }
}
