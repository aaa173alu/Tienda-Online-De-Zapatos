using ApplicationCore.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Domain.EN;

public class Pedido
{
    public long Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public string DireccionEnvio { get; set; } = string.Empty;
    public EstadoPedido Estado { get; set; }
    public long UsuarioId { get; set; }
    public IList<ItemPedido> Items { get; set; } = new List<ItemPedido>();
}
