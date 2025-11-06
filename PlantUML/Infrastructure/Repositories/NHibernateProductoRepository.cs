using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using Infrastructure.UnitOfWork;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;

namespace Infrastructure.Repositories;

public class NHibernateProductoRepository : IProductoRepository
{
    private readonly NHibernateUnitOfWork _uow;

    public NHibernateProductoRepository(NHibernateUnitOfWork uow)
    {
        _uow = uow;
    }

    public Producto New(Producto entity)
    {
        _uow.Session.Save(entity);
        return entity;
    }

    public void Destroy(long id)
    {
        var e = _uow.Session.Get<Producto>(id);
        if (e != null) _uow.Session.Delete(e);
    }

    public IEnumerable<Producto> GetAll() => _uow.Session.Query<Producto>().ToList();

    public Producto? GetById(long id) => _uow.Session.Get<Producto>(id);

    public IEnumerable<Producto> GetDestacados() => _uow.Session.Query<Producto>().Where(p => p.Destacado).ToList();

    public void Modify(Producto entity) => _uow.Session.Update(entity);
}
