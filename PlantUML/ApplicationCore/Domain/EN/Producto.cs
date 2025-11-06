using System.Collections.Generic;

namespace ApplicationCore.Domain.EN;

public class Producto
{
    public long Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public IList<string> TallasDisponibles { get; set; } = new List<string>();
    public IList<string>? Fotos { get; set; }
    public int Stock { get; set; }
    public bool Destacado { get; set; }
    public string? Color { get; set; }
}
