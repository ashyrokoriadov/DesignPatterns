using Observer.Interfaces;
using System.Collections.Generic;

namespace Observer.Repos
{
    public interface IRepo<TEntity> : IEnumerable<TEntity> where TEntity : IIdentifiable
    {
        bool Add(TEntity entity);

        bool Remove(TEntity entity);

        bool Exist(TEntity entity);
    }
}
