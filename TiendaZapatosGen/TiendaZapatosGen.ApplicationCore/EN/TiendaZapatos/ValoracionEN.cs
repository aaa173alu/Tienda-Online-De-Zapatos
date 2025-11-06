
using System;
// Definición clase ValoracionEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class ValoracionEN
{
/**
 *	Atributo idValoracion
 */
private int idValoracion;



/**
 *	Atributo valoracion
 */
private int valoracion;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo valoracion_1
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN valoracion_1;



/**
 *	Atributo producto
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN producto;






public virtual int IdValoracion {
        get { return idValoracion; } set { idValoracion = value;  }
}



public virtual int Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN Valoracion_1 {
        get { return valoracion_1; } set { valoracion_1 = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int idValoracion, int valoracion, string comentario, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN valoracion_1, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN producto
                    )
{
        this.init (IdValoracion, valoracion, comentario, valoracion_1, producto);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.IdValoracion, valoracion.Valoracion, valoracion.Comentario, valoracion.Valoracion_1, valoracion.Producto);
}

private void init (int idValoracion
                   , int valoracion, string comentario, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN valoracion_1, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN producto)
{
        this.IdValoracion = idValoracion;


        this.Valoracion = valoracion;

        this.Comentario = comentario;

        this.Valoracion_1 = valoracion_1;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
        if (t == null)
                return false;
        if (IdValoracion.Equals (t.IdValoracion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdValoracion.GetHashCode ();
        return hash;
}
}
}
