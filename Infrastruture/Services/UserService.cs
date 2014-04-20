using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Models;

namespace Infrastruture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            _userRepository.Create(user);
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetUser(userId);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetAllUsersByUserName(string userName)
        {
            var users = _userRepository.GetAll()
                .Where(x => x.Password == userName);
            return users;
        }

        public bool CheckIfUserAllreadyExsists(User user)
        {
            return _userRepository.GetAll().Select(x => x.Username == user.Username).FirstOrDefault();
        }
    }
}
