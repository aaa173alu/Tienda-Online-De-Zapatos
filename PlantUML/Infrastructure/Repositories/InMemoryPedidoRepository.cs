using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories;

public class InMemoryPedidoRepository : IPedidoRepository
{
    private readonly ConcurrentDictionary<long, Pedido> _store = new();
    private long _seq = 1;

    public Pedido New(Pedido entity)
    {
        var id = System.Threading.Interlocked.Increment(ref _seq);
        entity.Id = id;
        _store[id] = entity;
        return entity;
    }

    public void Destroy(long id) => _store.TryRemove(id, out _);

    public IEnumerable<Pedido> GetAll() => _store.Values.ToList();

    public Pedido? GetById(long id) => _store.TryGetValue(id, out var p) ? p : null;

    public IEnumerable<Pedido> GetByUsuario(long usuarioId) => _store.Values.Where(x => x.UsuarioId == usuarioId).ToList();

    public void Modify(Pedido entity)
    {
        if (_store.ContainsKey(entity.Id)) _store[entity.Id] = entity;
    }
}
