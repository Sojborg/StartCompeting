using System.Collections.Generic;
using System.Data.Entity;
using Core.Interfaces;
using Core.Models;

namespace Infrastruture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IStartCompetingContext _context;

        public UserRepository(IStartCompetingContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.StartCompetingUsers.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.StartCompetingUsers;
        }

        public User GetUser(int id)
        {
            return _context.StartCompetingUsers.Find(id);
        }

        public DbSet<User> Table()
        {
            return _context.StartCompetingUsers;
        }
    }
}
