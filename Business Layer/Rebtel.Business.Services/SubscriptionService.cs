using System;
using System.Collections.Generic;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.DTOs;
using Rebtel.Business.Services.ServiceContracts;

namespace Rebtel.Business.Services
{
    public class SubscriptionService : BaseService, ISubscriptionService
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
            try
            {
                IEnumerable<SubscriptionEntity> result;
                using (_dbContextScopeFactory.Create())
                {
                    result = _repositoryFactory.Get<ISubscriptionRepository>().GetAll();
                }

                // Mapping Phase
                return result.ToListDTO();
            }
            catch (Exception e)
            {
                throw GetExceptionResponse(e);
            }
        }

        public SubscriptionDetailDTO Get(string id)
        {
            // Processing Phase
            try
            {
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
            catch (Exception e)
            {
                throw GetExceptionResponse(e);
            }
        }

        public string Create(SubscriptionCreateDTO subscription)
        {
            try
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
            catch (Exception e)
            {
                throw GetExceptionResponse(e);
            }
        }

        public string Update(SubscriptionUpdateDTO subscription)
        {
            // Processing Phase
            try
            {
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
            catch (Exception e)
            {
                throw GetExceptionResponse(e);
            }
        }

        public bool Delete(string id)
        {
            try
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
            catch (Exception e)
            {
                throw GetExceptionResponse(e);
            }
        }
    }
}
