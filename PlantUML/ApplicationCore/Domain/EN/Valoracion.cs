namespace ApplicationCore.Domain.EN;

public class Valoracion
{
    public long Id { get; set; }
    public int Valor { get; set; }
    public string? Comentario { get; set; }
    public long UsuarioId { get; set; }
    public long ProductoId { get; set; }
}
