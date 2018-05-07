using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Rebtel.Business.DAL.DbInfrastructure;
using Rebtel.Business.DAL.Infrastructure;

namespace Rebtel.Business.DAL.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, new()
    {
        #region Protected Properties
        protected bool _disposed;
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        protected AppDbContext DbContext
        {
            get
            {
                var dbContext = _ambientDbContextLocator.Get<AppDbContext>();
                if (dbContext == null)
                {
                    throw new InvalidOperationException("No ambient DbContext of type AppDbContext found. This means " +
                                                        "that this repository method has been called outside of the scope of a DbContextScope. " +
                                                        "A repository must only be accessed within the scope of a DbContextScope, which takes care " +
                                                        "creating the DbContext instances that the repositories need and making them available as " +
                                                        "ambient contexts. This is what ensures that, for any given DbContext-derived type, the " +
                                                        "same instance is used throughout the duration of a business transaction. To fix this issue, " +
                                                        "use IDbContextScopeFactory in your top-level business logic service method to create a " +
                                                        "DbContextScope that wraps the entire business transaction that your service method implements. " +
                                                        "Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs " +
                                                        "file for more details.");
                }

                return dbContext;
            }
        }
        #endregion

        protected GenericRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        #region CRUD Methods
        /// <summary>
        /// Attach entity to Db context so that it can be added
        /// to database on next database commit
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Attach entity to Db context so that it can be updated
        /// to database on next database commit
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Attach entity to Db context so that it can be permanentaly deleted
        /// from database on next database commit
        /// ** WARNING - Most items should be Soft Deleted
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbContext.Set<TEntity>().Attach(entity);
            }

            DbContext.Entry(entity).State = EntityState.Deleted;
        }
        
        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition
        /// or a default value if no such element exists; this method throws an exception
        /// if more than one element satisfies the condition.
        /// </summary>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <exception cref="System.ArgumentNullException">Db collection or predicate is null</exception>
        /// <exception cref="System.InvalidOperationException">More than one element satisfies the 
        /// condition in predicate</exception>
        /// <returns>The single element of the input sequence that satisfies the condition in
        /// predicate, or default(TSource) if no such element is found.</returns>
        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().SingleOrDefault(predicate);
        }
        #endregion

        #region Dispose Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                //if(DbContext != null) {
                //    DbContext.Dispose();
                //}
            }

            _disposed = true;
        }
        #endregion
    }
}
