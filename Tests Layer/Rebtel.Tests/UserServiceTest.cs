using System;
using System.Linq;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rebtel.Business.DataEntities;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DAL.Specifications;
using Rebtel.Business.DTOs;

namespace Rebtel.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void Test_User_Creation()
        {
            // Setup
            var user = GetUserCreateDTOData();
            var dbContext = new AppDbContext();

            // Act
            var result = Bootstraper.GetUserService().Create(user);
            
            // Assert
            Assert.IsTrue(dbContext.Users.Any(a => a.Id == result));

            dbContext.Dispose();
        }

        [TestMethod]
        public void Test_User_Read_And_Delete()
        {
            // Setup
            var dbContext = new AppDbContext();
            var userToCreate = GetUserCreateDTOData();

            //Create Test
            var userId = Bootstraper.GetUserService().Create(userToCreate);
            Assert.IsTrue(dbContext.Users.Any(a => a.Id == userId));
            
            // Read Test
            var userReturneByService = Bootstraper.GetUserService().Get(userId);
            Assert.IsNotNull(userReturneByService);
            Assert.IsTrue(userId == userReturneByService.Id);

            // Delete Test
            Assert.IsTrue(Bootstraper.GetUserService().Delete(userId));
            Assert.IsNull(dbContext.Users.Find(userId));

            dbContext.Dispose();
        }

        [TestMethod]
        public void Test_Find_User_By_Id_Specification()
        {
            var user = GetUserEntityData();

            var spec = new FindUserByIdSepecification(user.Id);

            Assert.IsTrue(spec.IsSatisfiedBy(user));
        }

        [TestMethod]
        public void Test_Reading_NonExisting_User()
        {
            Assert.ThrowsException<FaultException<FaultResponseDTO>>(() => Bootstraper.GetUserService().Get("invalid id"));
        }

        private UserCreateDTO GetUserCreateDTOData()
        {
            return new UserCreateDTO
            {
                FirstName = "User FirstName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
        }

        private UserEntity GetUserEntityData()
        {
            return new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "User FirstName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
        }
    }
}
