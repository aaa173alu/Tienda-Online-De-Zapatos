using ApplicationCore.Domain.CEN;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Xunit;

public class ProductoCENTests
{
    [Fact]
    public void CrearYListarProductos_Works()
    {
        var repo = new InMemoryProductoRepository();
        var uow = new InMemoryUnitOfWork();
        var cen = new ProductoCEN(repo, uow);

        var p = cen.Crear("TestProd", 10m, 5, false);
        var list = cen.ListarTodos();

        Assert.Single(list);
        Assert.Equal("TestProd", p.Nombre);
    }
}
