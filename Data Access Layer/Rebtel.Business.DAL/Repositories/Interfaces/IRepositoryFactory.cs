using System;

namespace Rebtel.Business.DAL.Repositories
{
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Create and return repository instance for given type
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <param name="forceNew">Force create new instace and overwrite old one, if present.</param>
        /// <returns></returns>
        TRepository Get<TRepository>(bool forceNew = false) where TRepository : class;

        /// <summary>
        /// Register new type with implementation type
        /// </summary>
        /// <param name="TInterface"></param>
        /// <param name="TImplementation"></param>
        void Register(Type TInterface, Type TImplementation);
    }
}
