
using System;
// Definición clase CarritoEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class CarritoEN
{
/**
 *	Atributo idCarrito
 */
private int idCarrito;



/**
 *	Atributo total
 */
private float total;



/**
 *	Atributo fechaCreacion
 */
private Nullable<DateTime> fechaCreacion;



/**
 *	Atributo usuario_3
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_3;



/**
 *	Atributo carrito_0
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN> carrito_0;






public virtual int IdCarrito {
        get { return idCarrito; } set { idCarrito = value;  }
}



public virtual float Total {
        get { return total; } set { total = value;  }
}



public virtual Nullable<DateTime> FechaCreacion {
        get { return fechaCreacion; } set { fechaCreacion = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN Usuario_3 {
        get { return usuario_3; } set { usuario_3 = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN> Carrito_0 {
        get { return carrito_0; } set { carrito_0 = value;  }
}





public CarritoEN()
{
        carrito_0 = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN>();
}



public CarritoEN(int idCarrito, float total, Nullable<DateTime> fechaCreacion, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_3, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN> carrito_0
                 )
{
        this.init (IdCarrito, total, fechaCreacion, usuario_3, carrito_0);
}


public CarritoEN(CarritoEN carrito)
{
        this.init (carrito.IdCarrito, carrito.Total, carrito.FechaCreacion, carrito.Usuario_3, carrito.Carrito_0);
}

private void init (int idCarrito
                   , float total, Nullable<DateTime> fechaCreacion, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_3, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN> carrito_0)
{
        this.IdCarrito = idCarrito;


        this.Total = total;

        this.FechaCreacion = fechaCreacion;

        this.Usuario_3 = usuario_3;

        this.Carrito_0 = carrito_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CarritoEN t = obj as CarritoEN;
        if (t == null)
                return false;
        if (IdCarrito.Equals (t.IdCarrito))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdCarrito.GetHashCode ();
        return hash;
}
}
}
