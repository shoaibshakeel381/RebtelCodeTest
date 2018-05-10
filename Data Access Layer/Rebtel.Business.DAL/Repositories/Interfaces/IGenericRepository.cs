using System;
using System.Collections.Generic;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Specifications;

namespace Rebtel.Business.DAL.Repositories
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>, new()
    {
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
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition
        /// or a default value if no such element exists; this method throws an exception
        /// if more than one element satisfies the condition.
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        TEntity SingleOrDefault(ISpecification<TEntity, TKey> specification);
        
        /// <summary>
        /// Find element by its id. Will return null if more than one found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FindById(TKey id);

        /// <summary>
        /// Return all Records
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> ListAll();

        /// <summary>
        /// Return all Records which match provided specification
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> ListAll(ISpecification<TEntity, TKey> specification);
    }
}
