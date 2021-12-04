using Observer.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Observer.Repos
{
    public class GenericRepo<TEntity> : IRepo<TEntity> where TEntity : IIdentifiable
    {
        private List<TEntity> _data = new List<TEntity>();

        public bool Add(TEntity entity)
        {
            if (Exist(entity))
            {
                return false;
            }

            _data.Add(entity);
            return true;
        }

        public bool Remove(TEntity entity)
        {
            if (!Exist(entity))
            {
                return false;
            }

            _data.Remove(entity);
            return true;
        }

        public bool Exist(TEntity entity) => _data.Any(u => u.Id == entity.Id);

        public IEnumerator<TEntity> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
