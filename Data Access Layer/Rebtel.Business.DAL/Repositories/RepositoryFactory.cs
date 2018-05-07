using System;
using System.Collections.Generic;
using Rebtel.Business.DAL.Infrastructure;

namespace Rebtel.Business.DAL.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        #region Fields & Constructor
        private readonly IDictionary<Type, Type> _registeredTypes;
        private readonly IDictionary<Type, object> _InstatiatedTypes;
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        public RepositoryFactory(
           IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
            _InstatiatedTypes = new Dictionary<Type, object>();
            _registeredTypes = new Dictionary<Type, Type>();

            RegisterRepositoryTypes();
        }
        #endregion

        #region Register Repository Types
        private void RegisterRepositoryTypes()
        {   
            Register(typeof(IUserRepository), typeof(UserRepository));
            Register(typeof(ISubscriptionRepository), typeof(SubscriptionRepository));
        }

        /// <inheritdoc />
        /// <summary>
        /// Register new type with implementation type
        /// </summary>
        /// <param name="TInterface"></param>
        /// <param name="TImplementation"></param>
        public void Register(Type TInterface, Type TImplementation)
        {
            _registeredTypes.Add(TInterface, TImplementation);
        }
        #endregion

        #region Create Repository
        /// <inheritdoc />
        /// <summary>
        /// Create and return repository instance for given type
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <param name="forceNew">Force create new instace and overwrite old one, if present.</param>
        /// <returns></returns>
        /// <returns></returns>
        public TRepository Get<TRepository>(bool forceNew = false) where TRepository : class
        {
            var repositoryType = typeof(TRepository);
            object repository;

            if (!forceNew && _InstatiatedTypes.ContainsKey(repositoryType))
            {
                return (TRepository)_InstatiatedTypes[repositoryType];
            }

            repository = GetRepository<TRepository>();

            if (repository != null)
            {
                _InstatiatedTypes[repositoryType] = repository;
                return (TRepository)repository;
            }

            throw new InvalidOperationException("Requested repository type is not registered with this factory. Please first register its implementation using Register method");
        }

        /// <summary>
        /// instantiare Non generic type
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <returns></returns>
        private TRepository GetRepository<TRepository>()
        {
            var repositoryType = typeof(TRepository);

            var res = _registeredTypes.TryGetValue(repositoryType, out var ImplType);

            return res ? (TRepository)
                Activator.CreateInstance(ImplType, _ambientDbContextLocator)
                : default(TRepository);
        }
        #endregion
    }
}
