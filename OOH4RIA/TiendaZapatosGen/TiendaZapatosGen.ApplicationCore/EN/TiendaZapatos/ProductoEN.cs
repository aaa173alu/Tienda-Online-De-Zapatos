
using System;
// Definición clase ProductoEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class ProductoEN
{
/**
 *	Atributo idProducto
 */
private int idProducto;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo tallasDisponibles
 */
private string tallasDisponibles;



/**
 *	Atributo fotos
 */
private string fotos;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo destacado
 */
private bool destacado;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN> valoracion;



/**
 *	Atributo categoria_0
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN> categoria_0;






public virtual int IdProducto {
        get { return idProducto; } set { idProducto = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual string TallasDisponibles {
        get { return tallasDisponibles; } set { tallasDisponibles = value;  }
}



public virtual string Fotos {
        get { return fotos; } set { fotos = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual bool Destacado {
        get { return destacado; } set { destacado = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN> Categoria_0 {
        get { return categoria_0; } set { categoria_0 = value;  }
}





public ProductoEN()
{
        valoracion = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN>();
        categoria_0 = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN>();
}



public ProductoEN(int idProducto, string nombre, string descripcion, float precio, string tallasDisponibles, string fotos, int stock, bool destacado, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN> valoracion, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN> categoria_0
                  )
{
        this.init (IdProducto, nombre, descripcion, precio, tallasDisponibles, fotos, stock, destacado, valoracion, categoria_0);
}


public ProductoEN(ProductoEN producto)
{
        this.init (producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio, producto.TallasDisponibles, producto.Fotos, producto.Stock, producto.Destacado, producto.Valoracion, producto.Categoria_0);
}

private void init (int idProducto
                   , string nombre, string descripcion, float precio, string tallasDisponibles, string fotos, int stock, bool destacado, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ValoracionEN> valoracion, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN> categoria_0)
{
        this.IdProducto = idProducto;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Precio = precio;

        this.TallasDisponibles = tallasDisponibles;

        this.Fotos = fotos;

        this.Stock = stock;

        this.Destacado = destacado;

        this.Valoracion = valoracion;

        this.Categoria_0 = categoria_0;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
        if (t == null)
                return false;
        if (IdProducto.Equals (t.IdProducto))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdProducto.GetHashCode ();
        return hash;
}
}
}
