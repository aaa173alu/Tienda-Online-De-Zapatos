using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Domain.CEN;

public class FavoritosCEN
{
    private readonly IRepository<Favoritos, long> _favoritosRepo;
    private readonly IUnitOfWork _uow;

    public FavoritosCEN(IRepository<Favoritos, long> favoritosRepo, IUnitOfWork uow)
    {
        _favoritosRepo = favoritosRepo;
        _uow = uow;
    }

    // CRUD Básico

    public Favoritos Crear(long usuarioId, long productoId)
    {
        // Verificar si ya existe
        var existente = _favoritosRepo.GetAll()
            .FirstOrDefault(f => f.UsuarioId == usuarioId && f.ProductoId == productoId);

        if (existente != null)
            throw new Exception("El producto ya está en favoritos");

        var favorito = new Favoritos
        {
            UsuarioId = usuarioId,
            ProductoId = productoId
        };

        var created = _favoritosRepo.New(favorito);
        _uow.SaveChanges();
        return created;
    }

    public void Destroy(long id)
    {
        _favoritosRepo.Destroy(id);
        _uow.SaveChanges();
    }

    public Favoritos ReadOID(long id)
    {
        return _favoritosRepo.GetById(id);
    }

    public IList<Favoritos> ReadAll()
    {
        return _favoritosRepo.GetAll().ToList();
    }

    // Operaciones Custom

    public IList<Favoritos> ObtenerPorUsuario(long usuarioId)
    {
        return _favoritosRepo.GetAll()
            .Where(f => f.UsuarioId == usuarioId)
            .ToList();
    }

    public void EliminarPorUsuarioYProducto(long usuarioId, long productoId)
    {
        var favorito = _favoritosRepo.GetAll()
            .FirstOrDefault(f => f.UsuarioId == usuarioId && f.ProductoId == productoId);

        if (favorito != null)
        {
            _favoritosRepo.Destroy(favorito.Id);
            _uow.SaveChanges();
        }
    }

    public bool EstaEnFavoritos(long usuarioId, long productoId)
    {
        return _favoritosRepo.GetAll()
            .Any(f => f.UsuarioId == usuarioId && f.ProductoId == productoId);
    }

    // ReadFilter

    public IList<Favoritos> ReadFilter(long? usuarioId = null, long? productoId = null)
    {
        var query = _favoritosRepo.GetAll();

        if (usuarioId.HasValue)
            query = query.Where(f => f.UsuarioId == usuarioId.Value);

        if (productoId.HasValue)
            query = query.Where(f => f.ProductoId == productoId.Value);

        return query.ToList();
    }
}
