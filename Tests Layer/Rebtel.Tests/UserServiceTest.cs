﻿using System.Linq;
using System.ServiceModel;
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
            var userService = Bootstraper.GetUserService();

            var user = new UserCreateDTO
            {
                FirstName = "TestUserName",
                LastName = "User LastName",
                Email = "user@email.com"
            };
            var result = userService.Create(user);
            
            var dbContext = new AppDbContext();
            Assert.IsTrue(dbContext.Users.Any(a => a.Id == result));
        }

        [TestMethod]
        public void GetUserTest()
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
            Assert.IsNotNull(userService.Get(result));
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