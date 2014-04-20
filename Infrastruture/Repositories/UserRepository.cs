using System.Collections.Generic;
using System.Data.Entity;
using Core.Interfaces;
using Core.Models;

namespace Infrastruture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private StartCompetingContext _context;

        public UserRepository(StartCompetingContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public DbSet<User> Table()
        {
            return _context.Users;
        }
    }
}
