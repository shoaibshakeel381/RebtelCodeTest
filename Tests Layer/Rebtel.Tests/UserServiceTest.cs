using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rebtel.Business.DAL.DbInfrastructure;
using Rebtel.Business.DTOs;

namespace Rebtel.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void CreateUserTest()
        {
            var dbContext = new AppDbContext();
            var userService = Bootstraper.GetUserService(dbContext);

            var user = new UserCreateDTO
            {
                FirstName = "User FirstName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
            var result = userService.Create(user);
            
            dbContext = new AppDbContext();
            Assert.IsTrue(dbContext.Users.Any(a => a.Id == result));
        }

        [TestMethod]
        public void GetUserTest()
        {
            var dbContext = new AppDbContext();
            var userService = Bootstraper.GetUserService(dbContext);

            var user = new UserCreateDTO
            {
                FirstName = "User FirstName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
            var result = userService.Create(user);

            dbContext = new AppDbContext();
            userService = Bootstraper.GetUserService(dbContext);
            Assert.IsNotNull(userService.Get(result));
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var dbContext = new AppDbContext();
            var userService = Bootstraper.GetUserService(dbContext);

            var user = new UserCreateDTO
            {
                FirstName = "User FirstName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
            var result = userService.Create(user);

            dbContext = new AppDbContext();
            userService = Bootstraper.GetUserService(dbContext);
            Assert.IsNotNull(userService.Delete(result));
        }
    }
}
