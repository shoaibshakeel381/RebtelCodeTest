using System;
using System.Collections.Generic;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.DTOs;
using Rebtel.Business.DTOs.User_DTOs.Mappings;
using Rebtel.Business.Services.ServiceContracts;

namespace Rebtel.Business.Services
{
    public class UserService : IUserService
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
            using (_dbContextScopeFactory.Create())
            {
                var result = _repositoryFactory.Get<IUserRepository>().GetAll();

                // Mapping Phase
                return result.ToListDTO();
            }
        }

        public UserDetailDTO Get(string id)
        {
            // Processing Phase
            using (_dbContextScopeFactory.Create())
            {
                var result = _repositoryFactory.Get<IUserRepository>().SingleOrDefault(a => a.Id == id);
                if (result == null)
                {
                    throw new NotFoundException("User with provided id was not found.");
                }
                
                // Mapping Phase
                return result.ToDetailsDTO();
            }
        }

        public string Create(UserCreateDTO user)
        {
            var result = user.ToDomainEntity();
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                _repositoryFactory.Get<IUserRepository>().Create(result);
                dbContextScope.SaveChanges();
            }

            return result.Id;
        }

        public bool Subscribe(string userId, string subscriptionId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            using (var dbContextScrope = _dbContextScopeFactory.Create())
            {
                var user = _repositoryFactory.Get<IUserRepository>().SingleOrDefault(a => a.Id == id);
                if (user == null)
                {
                    throw new NotFoundException("User with provided id was not found.");
                }

                _repositoryFactory.Get<IUserRepository>().Delete(user);

                dbContextScrope.SaveChanges();
            }
            return true;
        }
    }
}
