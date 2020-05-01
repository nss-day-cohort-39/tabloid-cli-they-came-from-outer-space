using System.Collections.Generic;

namespace TabloidCLI
{
    public interface IRepository<TEntity>
    {
        void Delete(int id);
        List<TEntity> GetAll();
        void Insert(TEntity entry);
    }
}