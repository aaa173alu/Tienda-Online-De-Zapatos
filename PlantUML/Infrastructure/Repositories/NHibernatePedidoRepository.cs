using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using Infrastructure.UnitOfWork;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories;

public class NHibernatePedidoRepository : IPedidoRepository
{
    private readonly NHibernateUnitOfWork _uow;

    public NHibernatePedidoRepository(NHibernateUnitOfWork uow)
    {
        _uow = uow;
    }

    public Pedido New(Pedido entity)
    {
        _uow.Session.Save(entity);
        return entity;
    }

    public void Destroy(long id)
    {
        var e = _uow.Session.Get<Pedido>(id);
        if (e != null) _uow.Session.Delete(e);
    }

    public IEnumerable<Pedido> GetAll() => _uow.Session.Query<Pedido>().ToList();

    public Pedido? GetById(long id) => _uow.Session.Get<Pedido>(id);

    public IEnumerable<Pedido> GetByUsuario(long usuarioId) => _uow.Session.Query<Pedido>().Where(p => p.UsuarioId == usuarioId).ToList();

    public void Modify(Pedido entity) => _uow.Session.Update(entity);
}
