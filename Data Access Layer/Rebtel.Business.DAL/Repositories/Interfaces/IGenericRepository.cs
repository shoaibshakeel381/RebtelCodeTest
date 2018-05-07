using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rebtel.Business.DAL.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable
        where TEntity : class, new()
    {
        #region CRUD Methods
        /// <summary>
        /// Attach entity to Db context so that it can be added
        /// to database on next database commit
        /// </summary>
        /// <param name="entity"></param>
        void Create(TEntity entity);

        /// <summary>
        /// Attach entity to Db context so that it can be updated
        /// to database on next database commit
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Attach entity to Db context so that it can be permanentaly deleted
        /// from database on next database commit
        /// ** WARNING - Most items should be Soft Deleted
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
        #endregion
        
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
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition
        /// or a default value if no such element exists; this method throws an exception
        /// if more than one element satisfies the condition.
        /// </summary>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <param name="includes">List of Properties to Include.</param>
        /// <exception cref="System.ArgumentNullException">Db collection or predicate is null</exception>
        /// <exception cref="System.InvalidOperationException">More than one element satisfies the 
        /// condition in predicate</exception>
        /// <returns>The single element of the input sequence that satisfies the condition in
        /// predicate, or default(TSource) if no such element is found.</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes);

        /// <summary>
        /// Return all Records
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
    }
}
