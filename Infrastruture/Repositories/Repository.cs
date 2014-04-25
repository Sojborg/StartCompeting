using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Interfaces;

namespace Infrastruture.Repositories 
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly StartCompetingContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(StartCompetingContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.SingleOrDefault(x => x.Id == id);
            return entity;
        }

        public TEntity GetLazyById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Save(TEntity entity)
        {
            dynamic obj = _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save(IEnumerable<TEntity> list)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ModelAccessBase
    {
        public ISessionManager SessionManager { get; set; }

        private ISession _overwritingSession;

        protected virtual internal ISession Session
        {
            get { return _overwritingSession ?? SessionManager.Session; }
            set { _overwritingSession = value; }
        }
    }

    public interface ISessionManager
    {
        ISession Session { get; }
    }

    public interface ISession
    {
    }
}