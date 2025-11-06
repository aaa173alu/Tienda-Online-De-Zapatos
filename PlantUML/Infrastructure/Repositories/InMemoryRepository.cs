using ApplicationCore.Domain.Repositories;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementación genérica de repositorio en memoria
    /// Útil para testing y demos sin base de datos
    /// </summary>
    public class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly ConcurrentDictionary<TKey, TEntity> _storage = new();
        private long _nextId = 1;

        public TEntity New(TEntity entity)
        {
            // Asignar ID usando reflexión si la entidad tiene propiedad Id
            var idProp = typeof(TEntity).GetProperty("Id");
            if (idProp != null && idProp.PropertyType == typeof(long))
            {
                var currentId = (long)idProp.GetValue(entity);
                if (currentId == 0)
                {
                    var newId = Interlocked.Increment(ref _nextId) - 1;
                    idProp.SetValue(entity, newId);
                }
            }

            var key = (TKey)idProp?.GetValue(entity);
            if (key != null)
            {
                _storage[key] = entity;
            }

            return entity;
        }

        public void Modify(TEntity entity)
        {
            var idProp = typeof(TEntity).GetProperty("Id");
            if (idProp != null)
            {
                var key = (TKey)idProp.GetValue(entity);
                if (key != null && _storage.ContainsKey(key))
                {
                    _storage[key] = entity;
                }
            }
        }

        public void Destroy(TKey id)
        {
            _storage.TryRemove(id, out _);
        }

        public TEntity GetById(TKey id)
        {
            _storage.TryGetValue(id, out var entity);
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _storage.Values.AsEnumerable();
        }
    }
}
