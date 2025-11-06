using ApplicationCore.Domain.CEN;
using ApplicationCore.Domain.CP;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Xunit;
using ApplicationCore.Domain.EN;
using System.Collections.Generic;

public class FinalizarCompraCPTests
{
    [Fact]
    public void FinalizarCompra_Succeeds_WhenStockSufficient()
    {
        var productoRepo = new InMemoryProductoRepository();
        var pedidoRepo = new InMemoryPedidoRepository();
        var uow = new InMemoryUnitOfWork();

        var productoCEN = new ApplicationCore.Domain.CEN.ProductoCEN(productoRepo, uow);
        var pedidoCEN = new ApplicationCore.Domain.CEN.PedidoCEN(pedidoRepo, productoRepo, uow);
        var finalizar = new FinalizarCompraCP(pedidoCEN, productoRepo, uow);

        var p = productoCEN.Crear("Prod1", 10m, 5, false);

        var pedido = finalizar.Execute(1, "Dir", new List<ItemPedido> { new ItemPedido { ProductoId = p.Id, Cantidad = 2 } });

        Assert.NotNull(pedido);
        Assert.Equal(1, pedido.Items.Count);
    }

    [Fact]
    public void FinalizarCompra_Fails_WhenStockInsufficient()
    {
        var productoRepo = new InMemoryProductoRepository();
        var pedidoRepo = new InMemoryPedidoRepository();
        var uow = new InMemoryUnitOfWork();

        var productoCEN = new ApplicationCore.Domain.CEN.ProductoCEN(productoRepo, uow);
        var pedidoCEN = new ApplicationCore.Domain.CEN.PedidoCEN(pedidoRepo, productoRepo, uow);
        var finalizar = new FinalizarCompraCP(pedidoCEN, productoRepo, uow);

        var p = productoCEN.Crear("Prod1", 10m, 1, false);

        Assert.Throws<System.Exception>(() =>
            finalizar.Execute(1, "Dir", new List<ItemPedido> { new ItemPedido { ProductoId = p.Id, Cantidad = 2 } })
        );
    }
}
