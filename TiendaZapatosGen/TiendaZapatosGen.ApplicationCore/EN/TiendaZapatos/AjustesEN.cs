
using System;
// Definición clase AjustesEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class AjustesEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN> usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public AjustesEN()
{
        usuario = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN>();
}



public AjustesEN(int id, System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN> usuario
                 )
{
        this.init (Id, usuario);
}


public AjustesEN(AjustesEN ajustes)
{
        this.init (ajustes.Id, ajustes.Usuario);
}

private void init (int id
                   , System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN> usuario)
{
        this.Id = id;


        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AjustesEN t = obj as AjustesEN;
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
