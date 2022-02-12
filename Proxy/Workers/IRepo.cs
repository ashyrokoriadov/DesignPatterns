using System.Collections.Generic;

namespace Proxy.Workers
{
    interface IRepo<TEntity, TIdentifier>
    {
        TEntity Get(TIdentifier id);
      
        IEnumerable<TEntity> GetAll();

        bool Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TIdentifier id);      
    }
}
