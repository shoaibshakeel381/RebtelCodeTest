using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.Specifications
{
    public abstract class Specification<TEntity, TKey> : ISpecification<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; }
        public List<Expression<Func<TEntity, object>>> Includes { get; }
        public List<string> IncludeStrings { get; }

        protected Specification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
            Includes = new List<Expression<Func<TEntity, object>>>();
            IncludeStrings = new List<string>();
        }

        protected virtual void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        public bool IsSatisfiedBy(TEntity item)
        {
            return Criteria.Compile().Invoke(item);
        }
    }
}
