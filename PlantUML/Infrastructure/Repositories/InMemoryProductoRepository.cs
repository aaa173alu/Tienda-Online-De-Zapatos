using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories;

public class InMemoryProductoRepository : IProductoRepository
{
    private readonly ConcurrentDictionary<long, Producto> _store = new();
    private long _seq = 1;

    public Producto New(Producto entity)
    {
        var id = System.Threading.Interlocked.Increment(ref _seq);
        entity.Id = id;
        _store[id] = entity;
        return entity;
    }

    public void Destroy(long id) => _store.TryRemove(id, out _);

    public IEnumerable<Producto> GetAll() => _store.Values.ToList();

    public Producto? GetById(long id) => _store.TryGetValue(id, out var p) ? p : null;

    public IEnumerable<Producto> GetDestacados() => _store.Values.Where(p => p.Destacado).ToList();

    public void Modify(Producto entity)
    {
        if (_store.ContainsKey(entity.Id)) _store[entity.Id] = entity;
    }
}
