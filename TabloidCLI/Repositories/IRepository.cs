using System.Collections.Generic;

namespace TabloidCLI
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity entry);
        void Update(TEntity entry);
        void Delete(int id);
    }
}