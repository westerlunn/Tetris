using System.Collections.Generic;

namespace TheGame.Infrastructure.Repositories
{
    public interface IRepository<TEntity>
    {
        void Update(TEntity entity);
        void Save(TEntity entity);
        void Seed(TEntity entity);
        TEntity GetById(int id);
        ICollection<TEntity> GetAll();
    }
}
