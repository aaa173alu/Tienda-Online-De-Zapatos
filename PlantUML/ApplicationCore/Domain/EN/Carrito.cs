using System;
using System.Collections.Generic;

namespace ApplicationCore.Domain.EN;

public class Carrito
{
    public long Id { get; set; }
    public decimal Total { get; set; }
    public DateTime FechaCreacion { get; set; }
    public long UsuarioId { get; set; }
    public IList<ItemPedido> Items { get; set; } = new List<ItemPedido>();
}
