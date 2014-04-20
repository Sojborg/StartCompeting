using System.Data.Entity;
using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);

        void Create(User user);
        
        IEnumerable<User> GetAll();

        DbSet<User> Table();
    }
}
