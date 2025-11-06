namespace ApplicationCore.Domain.EN;

public class ItemPedido
{
    public long Id { get; set; }
    public long ProductoId { get; set; }
    public int Cantidad { get; set; }
    public string? Talla { get; set; }
}
