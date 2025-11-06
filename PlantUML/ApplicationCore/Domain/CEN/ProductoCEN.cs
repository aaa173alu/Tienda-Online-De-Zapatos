using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Domain.CEN;

public class ProductoCEN
{
    private readonly IProductoRepository _productoRepo;
    private readonly IUnitOfWork _uow;

    public ProductoCEN(IProductoRepository productoRepo, IUnitOfWork uow)
    {
        _productoRepo = productoRepo;
        _uow = uow;
    }

    // CRUD Básico

    public Producto Crear(string nombre, decimal precio, int stock, bool destacado)
    {
        var p = new Producto { Nombre = nombre, Precio = precio, Stock = stock, Destacado = destacado };
        var created = _productoRepo.New(p);
        _uow.SaveChanges();
        return created;
    }

    public void Modify(long id, string nombre = null, decimal? precio = null, int? stock = null, bool? destacado = null, string descripcion = null)
    {
        var producto = _productoRepo.GetById(id);
        if (producto == null)
            throw new Exception($"Producto con ID {id} no encontrado");

        if (!string.IsNullOrEmpty(nombre))
            producto.Nombre = nombre;
        if (precio.HasValue)
            producto.Precio = precio.Value;
        if (stock.HasValue)
            producto.Stock = stock.Value;
        if (destacado.HasValue)
            producto.Destacado = destacado.Value;
        if (descripcion != null)
            producto.Descripcion = descripcion;

        _productoRepo.Modify(producto);
        _uow.SaveChanges();
    }

    public void Destroy(long id)
    {
        _productoRepo.Destroy(id);
        _uow.SaveChanges();
    }

    public Producto ReadOID(long id)
    {
        return _productoRepo.GetById(id);
    }

    public IEnumerable<Producto> ReadAll() => _productoRepo.GetAll();

    public IList<Producto> ListarTodos() => _productoRepo.GetAll().ToList();

    // Operaciones Custom

    public IList<Producto> BuscarPorRangoPrecio(decimal precioMin, decimal precioMax)
    {
        return _productoRepo.GetAll()
            .Where(p => p.Precio >= precioMin && p.Precio <= precioMax)
            .ToList();
    }

    public IList<Producto> ObtenerDestacados()
    {
        return _productoRepo.GetAll()
            .Where(p => p.Destacado)
            .ToList();
    }

    public void IncrementarStock(long id, int cantidad)
    {
        var producto = _productoRepo.GetById(id);
        if (producto == null)
            throw new Exception($"Producto con ID {id} no encontrado");

        producto.Stock += cantidad;
        _productoRepo.Modify(producto);
        _uow.SaveChanges();
    }

    public void DecrementarStock(long id, int cantidad)
    {
        var producto = _productoRepo.GetById(id);
        if (producto == null)
            throw new Exception($"Producto con ID {id} no encontrado");

        if (producto.Stock < cantidad)
            throw new Exception("Stock insuficiente");

        producto.Stock -= cantidad;
        _productoRepo.Modify(producto);
        _uow.SaveChanges();
    }

    // ReadFilter
    public IList<Producto> ReadFilter(
        decimal? precioMin = null,
        decimal? precioMax = null,
        int? stockMin = null,
        bool? destacado = null,
        string nombre = null,
        string color = null)
    {
        var query = _productoRepo.GetAll();

        if (precioMin.HasValue)
            query = query.Where(p => p.Precio >= precioMin.Value);

        if (precioMax.HasValue)
            query = query.Where(p => p.Precio <= precioMax.Value);

        if (stockMin.HasValue)
            query = query.Where(p => p.Stock >= stockMin.Value);

        if (destacado.HasValue)
            query = query.Where(p => p.Destacado == destacado.Value);

        if (!string.IsNullOrEmpty(nombre))
            query = query.Where(p => p.Nombre.Contains(nombre));
            
        if (!string.IsNullOrEmpty(color))
            query = query.Where(p => p.Color != null && p.Color.ToLower().Contains(color.ToLower()));

        return query.ToList();
    }
}
