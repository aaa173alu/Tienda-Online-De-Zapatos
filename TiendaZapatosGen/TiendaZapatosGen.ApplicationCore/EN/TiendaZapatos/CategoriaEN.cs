
using System;
// Definición clase CategoriaEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class CategoriaEN
{
/**
 *	Atributo idCategoria
 */
private int idCategoria;



/**
 *	Atributo attribute
 */
private string attribute;



/**
 *	Atributo categoria
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN categoria;






public virtual int IdCategoria {
        get { return idCategoria; } set { idCategoria = value;  }
}



public virtual string Attribute {
        get { return attribute; } set { attribute = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN Categoria {
        get { return categoria; } set { categoria = value;  }
}





public CategoriaEN()
{
}



public CategoriaEN(int idCategoria, string attribute, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN categoria
                   )
{
        this.init (IdCategoria, attribute, categoria);
}


public CategoriaEN(CategoriaEN categoria)
{
        this.init (categoria.IdCategoria, categoria.Attribute, categoria.Categoria);
}

private void init (int idCategoria
                   , string attribute, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN categoria)
{
        this.IdCategoria = idCategoria;


        this.Attribute = attribute;

        this.Categoria = categoria;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaEN t = obj as CategoriaEN;
        if (t == null)
                return false;
        if (IdCategoria.Equals (t.IdCategoria))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdCategoria.GetHashCode ();
        return hash;
}
}
}
