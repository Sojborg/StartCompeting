using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Infrastruture.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Core.Interfaces;

namespace StartCompeting.UnitTests
{
    [TestClass]
    public class AddNewUserShould
    {
        [TestMethod]
        public void Check_that_user_does_not_exsists()
        {
            var userRepo = new Mock<IUserRepository>();
            var userService = new UserService(userRepo.Object);
            var newUser = new User() {Id = 1, Username = "Jesper"};
            var allUsers = new List<User>
            {
                new User
                {
                    Id = 2,
                    Username = "Hans"
                },
                new User
                {
                    Id = 4,
                    Username = "Lene"
                }
            };

            userRepo.Setup(ur => ur.GetAll()).Returns(allUsers);

            var userExsists = userService.CheckIfUserAllreadyExsists(newUser);

            Assert.AreEqual(userExsists, false);
            userRepo.Verify();
        }

        [TestMethod]
        public void If_not_exsists_then_create_user()
        {
            var userRepo = new Mock<IUserRepository>();
            var userService = new UserService(userRepo.Object);
            var newUser = new User() {Id = 5};
            var allUsers = new List<User> {new User {Id = 1}, new User {Id=4}};

            userRepo.Setup(ur => ur.GetAll()).Returns(allUsers);
            userRepo.Setup(ur => ur.Create(It.IsAny<User>())).Callback(() => allUsers.Add(newUser));

            IEnumerable<User> allCurrentUsers = userService.GetAll();
            var allCurrentUsersCount = allCurrentUsers.Count();

            userService.CreateUser(newUser);

            IEnumerable<User> newCurrentUsers = userService.GetAll();

            Assert.AreNotEqual(allCurrentUsersCount, newCurrentUsers.Count());
        }
    }
}
