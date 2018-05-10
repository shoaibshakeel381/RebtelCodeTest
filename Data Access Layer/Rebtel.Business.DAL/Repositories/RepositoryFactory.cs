using System;
using System.Collections.Generic;
using System.Data.Entity;
using Rebtel.Business.DAL.Infrastructure;

namespace Rebtel.Business.DAL.Repositories
{
    public class RepositoryFactory<TDbContext> : IRepositoryFactory
        where TDbContext : DbContext
    {
        #region Fields & Constructor
        private readonly IDictionary<Type, Type> _registeredTypes;
        private readonly IDictionary<Type, object> _InstatiatedTypes;
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        private TDbContext DbContext
        {
            get
            {
                var dbContext = _ambientDbContextLocator.Get<TDbContext>();
                if (dbContext == null)
                {
                    throw new InvalidOperationException("No ambient context found. This means " +
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

            if (!forceNew && _InstatiatedTypes.ContainsKey(repositoryType))
            {
                return (TRepository)_InstatiatedTypes[repositoryType];
            }

            object repository = GetRepository<TRepository>();

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

            if (_registeredTypes.TryGetValue(repositoryType, out var implType))
            {
                return (TRepository) Activator.CreateInstance(implType, DbContext);
            }

            return default(TRepository);
        }
        #endregion
    }
}
