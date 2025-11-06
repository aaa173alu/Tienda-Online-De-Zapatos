
using System;
// Definición clase ItemPedidoEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class ItemPedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo talla
 */
private string talla;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN> pedido;



/**
 *	Atributo usuario
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario;



/**
 *	Atributo carrito
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN> carrito;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual string Talla {
        get { return talla; } set { talla = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN> Carrito {
        get { return carrito; } set { carrito = value;  }
}





public ItemPedidoEN()
{
        pedido = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN>();
        carrito = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN>();
}



public ItemPedidoEN(int id, int cantidad, string talla, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN> pedido, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN> carrito
                    )
{
        this.init (Id, cantidad, talla, pedido, usuario, carrito);
}


public ItemPedidoEN(ItemPedidoEN itemPedido)
{
        this.init (itemPedido.Id, itemPedido.Cantidad, itemPedido.Talla, itemPedido.Pedido, itemPedido.Usuario, itemPedido.Carrito);
}

private void init (int id
                   , int cantidad, string talla, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN> pedido, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN> carrito)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Talla = talla;

        this.Pedido = pedido;

        this.Usuario = usuario;

        this.Carrito = carrito;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ItemPedidoEN t = obj as ItemPedidoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
