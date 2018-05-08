using System;
using System.Collections.Generic;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.DTOs;
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

        public IEnumerable<SubscriptionListDTO> GetAll()
        {
            // Processing Phase
            using (_dbContextScopeFactory.Create())
            {
                var result = _repositoryFactory.Get<ISubscriptionRepository>().GetAll();

                // Mapping Phase
                return result.ToListDTO();
            }
        }

        public SubscriptionDetailDTO Get(string id)
        {
            // Processing Phase
            using (_dbContextScopeFactory.Create())
            {
                var result = _repositoryFactory.Get<ISubscriptionRepository>().SingleOrDefault(a => a.Id == id);
                if (result == null)
                {
                    throw new NotFoundException("Subscription with provided id was not found.");
                }

                // Mapping Phase
                return result.ToDetailsDTO();
            }
        }

        public string Create(SubscriptionCreateDTO subscription)
        {
            var result = subscription.ToDomainEntity();

            // Processing Phase
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _repositoryFactory.Get<ISubscriptionRepository>().Create(result);
                dbContextScope.SaveChanges();
            }

            return result.Id;
        }

        public string Update(SubscriptionUpdateDTO subscription)
        {
            // Processing Phase
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                var result = _repositoryFactory.Get<ISubscriptionRepository>().SingleOrDefault(a => a.Id == subscription.Id);
                if (result == null)
                {
                    throw new NotFoundException("Subscription with provided id was not found.");
                }

                // Mapping Phase
                subscription.ToDomainEntity(result);

                _repositoryFactory.Get<ISubscriptionRepository>().Update(result);
                dbContextScope.SaveChanges();
            }

            return subscription.Id;
        }

        public bool Delete(string id)
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
