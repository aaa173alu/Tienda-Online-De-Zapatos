using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Domain.CEN;

public class CategoriaCEN
{
    private readonly IRepository<Categoria, long> _categoriaRepo;
    private readonly IUnitOfWork _uow;

    public CategoriaCEN(IRepository<Categoria, long> categoriaRepo, IUnitOfWork uow)
    {
        _categoriaRepo = categoriaRepo;
        _uow = uow;
    }

    // CRUD Básico

    public Categoria Crear(string nombre)
    {
        // Verificar nombre único
        var existente = _categoriaRepo.GetAll().FirstOrDefault(c => c.Nombre == nombre);
        if (existente != null)
            throw new Exception("Ya existe una categoría con ese nombre");

        var categoria = new Categoria { Nombre = nombre };
        var created = _categoriaRepo.New(categoria);
        _uow.SaveChanges();
        return created;
    }

    public void Modify(long id, string nombre)
    {
        var categoria = _categoriaRepo.GetById(id);
        if (categoria == null)
            throw new Exception($"Categoría con ID {id} no encontrada");

        categoria.Nombre = nombre;
        _categoriaRepo.Modify(categoria);
        _uow.SaveChanges();
    }

    public void Destroy(long id)
    {
        _categoriaRepo.Destroy(id);
        _uow.SaveChanges();
    }

    public Categoria ReadOID(long id)
    {
        return _categoriaRepo.GetById(id);
    }

    public IList<Categoria> ReadAll()
    {
        return _categoriaRepo.GetAll().ToList();
    }

    // Operaciones Custom

    public Categoria BuscarPorNombre(string nombre)
    {
        return _categoriaRepo.GetAll().FirstOrDefault(c => c.Nombre == nombre);
    }

    // ReadFilter

    public IList<Categoria> ReadFilter(string nombre = null)
    {
        var query = _categoriaRepo.GetAll();

        if (!string.IsNullOrEmpty(nombre))
            query = query.Where(c => c.Nombre.Contains(nombre));

        return query.ToList();
    }
}
