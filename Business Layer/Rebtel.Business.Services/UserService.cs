using System;
using System.Collections.Generic;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Repositories;
using Rebtel.Business.DTOs;
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

        public IEnumerable<UserDetailDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDetailDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }

        public bool Subscribe(int userId, int subscriptionId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
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
