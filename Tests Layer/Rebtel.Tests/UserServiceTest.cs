using System.Linq;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rebtel.Business.DAL.Infrastructure;
using Rebtel.Business.DTOs;

namespace Rebtel.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void CreateUserTest()
        {
            // Setup
            var userService = Bootstraper.GetUserService();

            // Act
            var user = new UserCreateDTO
            {
                FirstName = "TestUserName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
            var result = userService.Create(user);
            
            // Assert
            var dbContext = new AppDbContext();
            Assert.IsTrue(dbContext.Users.Any(a => a.Id == result));
        }

        [TestMethod]
        public void GetUserTest()
        {
            // Setup
            // We First need at least one user in database
            var userService = Bootstraper.GetUserService();
            var userToCreate = new UserCreateDTO
            {
                FirstName = "TestUserName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
            var result = userService.Create(userToCreate);

            // Act
            var dbContext = new AppDbContext();
            var addedUser = dbContext.Users.Single(a => a.Id == result);

            userService = Bootstraper.GetUserService();
            var userReturneByService = userService.Get(result);
            
            // Assert
            Assert.IsTrue(addedUser.Id == userReturneByService.Id);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var userService = Bootstraper.GetUserService();

            var user = new UserCreateDTO
            {
                FirstName = "User FirstName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
            var result = userService.Create(user);
            
            userService = Bootstraper.GetUserService();
            Assert.IsNotNull(userService.Delete(result));
        }

        [TestMethod]
        public void GetNonExistingUser()
        {
            var userService = Bootstraper.GetUserService();
            Assert.ThrowsException<FaultException<FaultResponseDTO>>(() => userService.Get("invalid id"));
        }
    }
}
