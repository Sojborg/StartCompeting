using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);

        User GetUser(int userId);

        IEnumerable<User> GetAll();

        IEnumerable<User> GetAllUsersByUserName(string userName);
    }
}
