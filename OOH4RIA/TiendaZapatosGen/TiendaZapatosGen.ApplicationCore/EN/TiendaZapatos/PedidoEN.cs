
using System;
// Definición clase PedidoEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class PedidoEN
{
/**
 *	Atributo idPedido
 */
private int idPedido;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo total
 */
private float total;



/**
 *	Atributo direccionEnvio
 */
private string direccionEnvio;



/**
 *	Atributo estado
 */
private int estado;



/**
 *	Atributo itemPedido
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN itemPedido;



/**
 *	Atributo usuario
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario;



/**
 *	Atributo pedido
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PagoEN pedido;






public virtual int IdPedido {
        get { return idPedido; } set { idPedido = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual float Total {
        get { return total; } set { total = value;  }
}



public virtual string DireccionEnvio {
        get { return direccionEnvio; } set { direccionEnvio = value;  }
}



public virtual int Estado {
        get { return estado; } set { estado = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN ItemPedido {
        get { return itemPedido; } set { itemPedido = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PagoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}





public PedidoEN()
{
}



public PedidoEN(int idPedido, Nullable<DateTime> fecha, float total, string direccionEnvio, int estado, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN itemPedido, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PagoEN pedido
                )
{
        this.init (IdPedido, fecha, total, direccionEnvio, estado, itemPedido, usuario, pedido);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.IdPedido, pedido.Fecha, pedido.Total, pedido.DireccionEnvio, pedido.Estado, pedido.ItemPedido, pedido.Usuario, pedido.Pedido);
}

private void init (int idPedido
                   , Nullable<DateTime> fecha, float total, string direccionEnvio, int estado, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN itemPedido, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PagoEN pedido)
{
        this.IdPedido = idPedido;


        this.Fecha = fecha;

        this.Total = total;

        this.DireccionEnvio = direccionEnvio;

        this.Estado = estado;

        this.ItemPedido = itemPedido;

        this.Usuario = usuario;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (IdPedido.Equals (t.IdPedido))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdPedido.GetHashCode ();
        return hash;
}
}
}
