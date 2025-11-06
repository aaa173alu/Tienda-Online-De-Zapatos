using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Enums;
using ApplicationCore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Domain.CEN;

public class PedidoCEN
{
    private readonly IPedidoRepository _pedidoRepo;
    private readonly IProductoRepository _productoRepo;
    private readonly IUnitOfWork _uow;

    public PedidoCEN(IPedidoRepository pedidoRepo, IProductoRepository productoRepo, IUnitOfWork uow)
    {
        _pedidoRepo = pedidoRepo;
        _productoRepo = productoRepo;
        _uow = uow;
    }

    // CRUD Básico

    public Pedido CrearPedido(long usuarioId, string direccion, List<ItemPedido> items)
    {
        var total = 0m;
        foreach (var it in items)
        {
            var prod = _productoRepo.GetById(it.ProductoId);
            if (prod == null) throw new System.Exception("Producto no encontrado");
            total += prod.Precio * it.Cantidad;
        }

        var pedido = new Pedido { Fecha = System.DateTime.UtcNow, Total = total, DireccionEnvio = direccion, Estado = EstadoPedido.realizado, UsuarioId = usuarioId };
        foreach (var item in items)
        {
            pedido.Items.Add(item);
        }
        _pedidoRepo.New(pedido);
        return pedido;
    }

    public void Modify(long id, string direccionEnvio = null, EstadoPedido? estado = null)
    {
        var pedido = _pedidoRepo.GetById(id);
        if (pedido == null)
            throw new Exception($"Pedido con ID {id} no encontrado");

        if (!string.IsNullOrEmpty(direccionEnvio))
            pedido.DireccionEnvio = direccionEnvio;

        if (estado.HasValue)
            pedido.Estado = estado.Value;

        _pedidoRepo.Modify(pedido);
        _uow.SaveChanges();
    }

    public void Destroy(long id)
    {
        _pedidoRepo.Destroy(id);
        _uow.SaveChanges();
    }

    public Pedido ReadOID(long id)
    {
        return _pedidoRepo.GetById(id);
    }

    public IList<Pedido> ReadAll()
    {
        return _pedidoRepo.GetAll().ToList();
    }

    // Operaciones Custom

    public IList<Pedido> ObtenerPorUsuario(long usuarioId)
    {
        return _pedidoRepo.GetAll()
            .Where(p => p.UsuarioId == usuarioId)
            .OrderByDescending(p => p.Fecha)
            .ToList();
    }

    public IList<Pedido> ObtenerPorEstado(EstadoPedido estado)
    {
        return _pedidoRepo.GetAll()
            .Where(p => p.Estado == estado)
            .OrderByDescending(p => p.Fecha)
            .ToList();
    }

    public decimal CalcularTotalPedido(long pedidoId)
    {
        var pedido = _pedidoRepo.GetById(pedidoId);
        if (pedido == null)
            throw new Exception($"Pedido con ID {pedidoId} no encontrado");

        return pedido.Total;
    }

    public void CambiarEstado(long pedidoId, EstadoPedido nuevoEstado)
    {
        var pedido = _pedidoRepo.GetById(pedidoId);
        if (pedido == null)
            throw new Exception($"Pedido con ID {pedidoId} no encontrado");

        pedido.Estado = nuevoEstado;
        _pedidoRepo.Modify(pedido);
        _uow.SaveChanges();
    }

    // ReadFilter
    public IList<Pedido> ReadFilter(
        long? usuarioId = null,
        EstadoPedido? estado = null,
        DateTime? fechaDesde = null,
        DateTime? fechaHasta = null,
        decimal? totalMin = null,
        decimal? totalMax = null)
    {
        var query = _pedidoRepo.GetAll();

        if (usuarioId.HasValue)
            query = query.Where(p => p.UsuarioId == usuarioId.Value);

        if (estado.HasValue)
            query = query.Where(p => p.Estado == estado.Value);

        if (fechaDesde.HasValue)
            query = query.Where(p => p.Fecha >= fechaDesde.Value);

        if (fechaHasta.HasValue)
            query = query.Where(p => p.Fecha <= fechaHasta.Value);

        if (totalMin.HasValue)
            query = query.Where(p => p.Total >= totalMin.Value);

        if (totalMax.HasValue)
            query = query.Where(p => p.Total <= totalMax.Value);

        return query.OrderByDescending(p => p.Fecha).ToList();
    }
}
