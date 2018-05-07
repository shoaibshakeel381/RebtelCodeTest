using System;
using System.Collections.Generic;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.Services.ServiceContracts;

namespace Rebtel.Business.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        #region Private Fields
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        #endregion

        #region Constructor
        public SubscriptionService(
            IRepositoryFactory repositoryFactory,
            IDbContextScopeFactory dbContextScopeFactory)
        {
            _repositoryFactory = repositoryFactory;
            _dbContextScopeFactory = dbContextScopeFactory;
        }
        #endregion

        public IEnumerable<Subscription> GetAll()
        {
            throw new NotImplementedException();
        }

        public Subscription Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public int Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            using (var dbContextScrope = _dbContextScopeFactory.Create())
            {
                var user = _repositoryFactory.Get<ISubscriptionRepository>().SingleOrDefault(a => a.Id == id);
                if (user == null)
                {
                    throw new NotFoundException("Subscription with provided id was not found.");
                }

                _repositoryFactory.Get<ISubscriptionRepository>().Delete(user);

                dbContextScrope.SaveChanges();
            }
            return true;
        }
    }
}
