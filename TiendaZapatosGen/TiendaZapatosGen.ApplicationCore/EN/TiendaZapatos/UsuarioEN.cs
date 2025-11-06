
using System;
// Definición clase UsuarioEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class UsuarioEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo contrasenya
 */
private string contrasenya;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo rol
 */
private string rol;



/**
 *	Atributo valora
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN> valora;



/**
 *	Atributo itemPedido
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN> itemPedido;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN> pedido;



/**
 *	Atributo sesion
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.SesionEN sesion;



/**
 *	Atributo usuario_0
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PerfilEN usuario_0;



/**
 *	Atributo usuario_1
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AyudaEN usuario_1;



/**
 *	Atributo usuario_2
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN usuario_2;



/**
 *	Atributo favoritos
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.FavoritosEN> favoritos;



/**
 *	Atributo ajustes
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AjustesEN> ajustes;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Rol {
        get { return rol; } set { rol = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN> Valora {
        get { return valora; } set { valora = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN> ItemPedido {
        get { return itemPedido; } set { itemPedido = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.SesionEN Sesion {
        get { return sesion; } set { sesion = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PerfilEN Usuario_0 {
        get { return usuario_0; } set { usuario_0 = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AyudaEN Usuario_1 {
        get { return usuario_1; } set { usuario_1 = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN Usuario_2 {
        get { return usuario_2; } set { usuario_2 = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.FavoritosEN> Favoritos {
        get { return favoritos; } set { favoritos = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AjustesEN> Ajustes {
        get { return ajustes; } set { ajustes = value;  }
}





public UsuarioEN()
{
        valora = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN>();
        itemPedido = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN>();
        pedido = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN>();
        favoritos = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.FavoritosEN>();
        ajustes = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AjustesEN>();
}



public UsuarioEN(string email, string nombre, string contrasenya, string telefono, string direccion, string rol, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN> valora, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN> itemPedido, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN> pedido, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.SesionEN sesion, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PerfilEN usuario_0, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AyudaEN usuario_1, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN usuario_2, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.FavoritosEN> favoritos, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AjustesEN> ajustes
                 )
{
        this.init (Email, nombre, contrasenya, telefono, direccion, rol, valora, itemPedido, pedido, sesion, usuario_0, usuario_1, usuario_2, favoritos, ajustes);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Email, usuario.Nombre, usuario.Contrasenya, usuario.Telefono, usuario.Direccion, usuario.Rol, usuario.Valora, usuario.ItemPedido, usuario.Pedido, usuario.Sesion, usuario.Usuario_0, usuario.Usuario_1, usuario.Usuario_2, usuario.Favoritos, usuario.Ajustes);
}

private void init (string email
                   , string nombre, string contrasenya, string telefono, string direccion, string rol, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN> valora, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN> itemPedido, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN> pedido, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.SesionEN sesion, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PerfilEN usuario_0, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AyudaEN usuario_1, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CarritoEN usuario_2, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.FavoritosEN> favoritos, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AjustesEN> ajustes)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Contrasenya = contrasenya;

        this.Telefono = telefono;

        this.Direccion = direccion;

        this.Rol = rol;

        this.Valora = valora;

        this.ItemPedido = itemPedido;

        this.Pedido = pedido;

        this.Sesion = sesion;

        this.Usuario_0 = usuario_0;

        this.Usuario_1 = usuario_1;

        this.Usuario_2 = usuario_2;

        this.Favoritos = favoritos;

        this.Ajustes = ajustes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
