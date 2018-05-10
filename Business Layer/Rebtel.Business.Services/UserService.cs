using System;
using System.Collections.Generic;
using System.Linq;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.DAL.Specifications;
using Rebtel.Business.DTOs;
using Rebtel.Business.Services.ServiceContracts;

namespace Rebtel.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        #region Private Fields
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        #endregion

        #region Constructor
        public UserService(
            IRepositoryFactory repositoryFactory,
            IDbContextScopeFactory dbContextScopeFactory)
        {
            _repositoryFactory = repositoryFactory;
            _dbContextScopeFactory = dbContextScopeFactory;
        }
        #endregion

        public IEnumerable<UserListDTO> GetAll()
        {
            // Processing Phase
            try
            {
                using (_dbContextScopeFactory.Create())
                {
                    var result = _repositoryFactory.Get<IUserRepository>().ListAll();

                    // Mapping Phase
                    return result.ToListDTO();
                }
            }
            catch (Exception e)
            {
                throw GetExceptionResponse(e);
            }
        }

        public UserDetailDTO Get(string id)
        {
            // Processing Phase
            try
            {
                using (_dbContextScopeFactory.Create())
                {
                    var result = _repositoryFactory.Get<IUserRepository>().SingleOrDefault(new FindUserByIdSepecification(id));
                    if (result == null)
                    {
                        throw new NotFoundException("User with provided id was not found.");
                    }
                
                    // Mapping Phase
                    var userDetailDTO = result.ToDetailsDTO();
                    var subscriptions = new List<UserSubscriptionDetailDTO>();
                    foreach (var userSubscription in result.UserSubscriptions)
                    {
                        subscriptions.Add(userSubscription.Subscription.ToUserSubscriptionDetailDTO());
                    }

                    userDetailDTO.Subscriptions = subscriptions;
                    return userDetailDTO;
                }
            }
            catch (Exception e)
            {
                throw GetExceptionResponse(e);
            }
        }

        public string Create(UserCreateDTO user)
        {
            try
            {
                var result = user.ToDomainEntity();
                using (var dbContextScope = _dbContextScopeFactory.Create())
                {
                    _repositoryFactory.Get<IUserRepository>().Create(result);
                    dbContextScope.SaveChanges();
                }

                return result.Id;
            }
            catch (Exception e)
            {
                throw GetExceptionResponse(e);
            }
        }

        public bool Subscribe(string userId, string subscriptionId)
        {
            try
            {
                using (var dbContextScrope = _dbContextScopeFactory.Create())
                {
                    var user = _repositoryFactory.Get<IUserRepository>().SingleOrDefault(new FindUserByIdSepecification(userId));
                    if (user == null)
                    {
                        throw new NotFoundException("User with provided id was not found.");
                    }

                    var subscription = _repositoryFactory.Get<ISubscriptionRepository>().FindById(subscriptionId);
                    if (subscription == null)
                    {
                        throw new NotFoundException("Subscription with provided id was not found.");
                    }

                    if (!user.UserSubscriptions.Any(a => a.UserId == userId && a.SubscriptionId == subscriptionId))
                    {
                        _repositoryFactory.Get<IUserRepository>().AddUserSubscription(user, subscription);
                    }

                    dbContextScrope.SaveChanges();
                }

                return true;
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
                    var user = _repositoryFactory.Get<IUserRepository>().FindById(id);
                    if (user == null)
                    {
                        throw new NotFoundException("User with provided id was not found.");
                    }

                    _repositoryFactory.Get<IUserRepository>().Delete(user);

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
