using ApplicationCore.Domain.EN;
using System.Collections.Generic;

namespace ApplicationCore.Domain.Repositories;

public interface IPedidoRepository : IRepository<Pedido, long>
{
    IEnumerable<Pedido> GetByUsuario(long usuarioId);
}
