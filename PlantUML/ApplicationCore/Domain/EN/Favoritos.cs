using System;

namespace ApplicationCore.Domain.EN;

public class Favoritos
{
    public long Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public long UsuarioId { get; set; }
    public long ProductoId { get; set; }
}
