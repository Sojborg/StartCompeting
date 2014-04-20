using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetById(int id);

        TEntity GetLazyById(int id);

        IEnumerable<TEntity> GetAll();

        void Save(TEntity entity);

        void Delete(TEntity entity);

        void Save(IEnumerable<TEntity> list);
    }
}