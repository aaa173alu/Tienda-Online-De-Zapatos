
using System;
// Definición clase FavoritosEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class FavoritosEN
{
/**
 *	Atributo idFavoritos
 */
private int idFavoritos;



/**
 *	Atributo fechaCreacion
 */
private Nullable<DateTime> fechaCreacion;



/**
 *	Atributo usuario
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario;






public virtual int IdFavoritos {
        get { return idFavoritos; } set { idFavoritos = value;  }
}



public virtual Nullable<DateTime> FechaCreacion {
        get { return fechaCreacion; } set { fechaCreacion = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public FavoritosEN()
{
}



public FavoritosEN(int idFavoritos, Nullable<DateTime> fechaCreacion, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario
                   )
{
        this.init (IdFavoritos, fechaCreacion, usuario);
}


public FavoritosEN(FavoritosEN favoritos)
{
        this.init (favoritos.IdFavoritos, favoritos.FechaCreacion, favoritos.Usuario);
}

private void init (int idFavoritos
                   , Nullable<DateTime> fechaCreacion, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario)
{
        this.IdFavoritos = idFavoritos;


        this.FechaCreacion = fechaCreacion;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritosEN t = obj as FavoritosEN;
        if (t == null)
                return false;
        if (IdFavoritos.Equals (t.IdFavoritos))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdFavoritos.GetHashCode ();
        return hash;
}
}
}
