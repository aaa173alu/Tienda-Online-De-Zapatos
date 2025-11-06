using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Domain.CEN;

public class CarritoCEN
{
    private readonly IRepository<Carrito, long> _carritoRepo;
    private readonly IProductoRepository _productoRepo;
    private readonly IUnitOfWork _uow;

    public CarritoCEN(IRepository<Carrito, long> carritoRepo, IProductoRepository productoRepo, IUnitOfWork uow)
    {
        _carritoRepo = carritoRepo;
        _productoRepo = productoRepo;
        _uow = uow;
    }

    // CRUD Básico

    public Carrito Crear(long usuarioId)
    {
        var carrito = new Carrito
        {
            UsuarioId = usuarioId,
            Items = new List<ItemPedido>()
        };

        var created = _carritoRepo.New(carrito);
        _uow.SaveChanges();
        return created;
    }

    public void Destroy(long id)
    {
        _carritoRepo.Destroy(id);
        _uow.SaveChanges();
    }

    public Carrito ReadOID(long id)
    {
        return _carritoRepo.GetById(id);
    }

    public IList<Carrito> ReadAll()
    {
        return _carritoRepo.GetAll().ToList();
    }

    // Operaciones Custom

    public Carrito ObtenerPorUsuario(long usuarioId)
    {
        return _carritoRepo.GetAll().FirstOrDefault(c => c.UsuarioId == usuarioId);
    }

    public void AgregarItem(long carritoId, long productoId, int cantidad)
    {
        var carrito = _carritoRepo.GetById(carritoId);
        if (carrito == null)
            throw new Exception($"Carrito con ID {carritoId} no encontrado");

        var producto = _productoRepo.GetById(productoId);
        if (producto == null)
            throw new Exception($"Producto con ID {productoId} no encontrado");

        if (producto.Stock < cantidad)
            throw new Exception("Stock insuficiente");

        // Buscar si ya existe el item
        var itemExistente = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);
        if (itemExistente != null)
        {
            itemExistente.Cantidad += cantidad;
        }
        else
        {
            carrito.Items.Add(new ItemPedido
            {
                ProductoId = productoId,
                Cantidad = cantidad
            });
        }

        _carritoRepo.Modify(carrito);
        _uow.SaveChanges();
    }

    public void EliminarItem(long carritoId, long productoId)
    {
        var carrito = _carritoRepo.GetById(carritoId);
        if (carrito == null)
            throw new Exception($"Carrito con ID {carritoId} no encontrado");

        var item = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);
        if (item != null)
        {
            carrito.Items.Remove(item);
            _carritoRepo.Modify(carrito);
            _uow.SaveChanges();
        }
    }

    public void ActualizarCantidad(long carritoId, long productoId, int nuevaCantidad)
    {
        var carrito = _carritoRepo.GetById(carritoId);
        if (carrito == null)
            throw new Exception($"Carrito con ID {carritoId} no encontrado");

        var item = carrito.Items.FirstOrDefault(i => i.ProductoId == productoId);
        if (item == null)
            throw new Exception("Producto no encontrado en el carrito");

        var producto = _productoRepo.GetById(productoId);
        if (producto.Stock < nuevaCantidad)
            throw new Exception("Stock insuficiente");

        item.Cantidad = nuevaCantidad;
        _carritoRepo.Modify(carrito);
        _uow.SaveChanges();
    }

    public void Vaciar(long carritoId)
    {
        var carrito = _carritoRepo.GetById(carritoId);
        if (carrito == null)
            throw new Exception($"Carrito con ID {carritoId} no encontrado");

        carrito.Items.Clear();
        _carritoRepo.Modify(carrito);
        _uow.SaveChanges();
    }

    public decimal CalcularTotal(long carritoId)
    {
        var carrito = _carritoRepo.GetById(carritoId);
        if (carrito == null)
            throw new Exception($"Carrito con ID {carritoId} no encontrado");

        decimal total = 0;
        foreach (var item in carrito.Items)
        {
            var producto = _productoRepo.GetById(item.ProductoId);
            if (producto != null)
                total += producto.Precio * item.Cantidad;
        }

        return total;
    }

    // ReadFilter

    public IList<Carrito> ReadFilter(long? usuarioId = null, bool? conItems = null)
    {
        var query = _carritoRepo.GetAll();

        if (usuarioId.HasValue)
            query = query.Where(c => c.UsuarioId == usuarioId.Value);

        if (conItems.HasValue && conItems.Value)
            query = query.Where(c => c.Items.Any());
        else if (conItems.HasValue && !conItems.Value)
            query = query.Where(c => !c.Items.Any());

        return query.ToList();
    }
}
