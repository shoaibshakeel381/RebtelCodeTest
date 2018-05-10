using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Specifications;

namespace Rebtel.Business.DAL.Repositories
{
    public abstract class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>, new()
    {
        protected bool _disposed;
        protected readonly AppDbContext _dbContext;

        protected GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <inheritdoc cref="IGenericRepository{TEntity,TKey}.Create"/>
        public virtual void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
        }
        
        /// <inheritdoc cref="IGenericRepository{TEntity,TKey}.Update"/>
        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <inheritdoc cref="IGenericRepository{TEntity,TKey}.Delete"/>
        public virtual void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entity);
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        /// <inheritdoc cref="IGenericRepository{TEntity,TKey}.SingleOrDefault"/>
        public virtual TEntity SingleOrDefault(ISpecification<TEntity, TKey> specification)
        {
            return List(specification).SingleOrDefault();
        }

        /// <inheritdoc cref="IGenericRepository{TEntity,TKey}.FindById"/>
        public TEntity FindById(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        /// <inheritdoc cref="IGenericRepository{TEntity,TKey}.ListAll()"/>
        public IEnumerable<TEntity> ListAll()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        /// <inheritdoc cref="IGenericRepository{TEntity,TKey}.ListAll(Specifications.ISpecification{TEntity,TKey})"/>
        public IEnumerable<TEntity> ListAll(ISpecification<TEntity, TKey> specification)
        {
            return List(specification);
        }

        protected virtual IEnumerable<TEntity> List(ISpecification<TEntity, TKey> specification)
        {
            // Query all results with all expression-based includes
            var sequence = specification.Includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(),
                (entities, expression) => entities.Include(expression));

            // Update Query to handle all string-based includes
            sequence = specification.IncludeStrings.Aggregate(sequence, (entities, includeString) => entities.Include(includeString));

            // Apply Fiter Criteria and return results
            return sequence.Where(specification.Criteria).AsEnumerable();
        }
    }
}
