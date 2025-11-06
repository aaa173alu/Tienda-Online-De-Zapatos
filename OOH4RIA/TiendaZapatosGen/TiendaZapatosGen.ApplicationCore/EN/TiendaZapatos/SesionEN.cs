
using System;
// Definición clase SesionEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class SesionEN
{
/**
 *	Atributo idSesion
 */
private int idSesion;



/**
 *	Atributo fechaInicio
 */
private Nullable<DateTime> fechaInicio;



/**
 *	Atributo fechaFin
 */
private Nullable<DateTime> fechaFin;



/**
 *	Atributo activa
 */
private bool activa;



/**
 *	Atributo usuario
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario;






public virtual int IdSesion {
        get { return idSesion; } set { idSesion = value;  }
}



public virtual Nullable<DateTime> FechaInicio {
        get { return fechaInicio; } set { fechaInicio = value;  }
}



public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}



public virtual bool Activa {
        get { return activa; } set { activa = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public SesionEN()
{
}



public SesionEN(int idSesion, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, bool activa, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario
                )
{
        this.init (IdSesion, fechaInicio, fechaFin, activa, usuario);
}


public SesionEN(SesionEN sesion)
{
        this.init (sesion.IdSesion, sesion.FechaInicio, sesion.FechaFin, sesion.Activa, sesion.Usuario);
}

private void init (int idSesion
                   , Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, bool activa, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario)
{
        this.IdSesion = idSesion;


        this.FechaInicio = fechaInicio;

        this.FechaFin = fechaFin;

        this.Activa = activa;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SesionEN t = obj as SesionEN;
        if (t == null)
                return false;
        if (IdSesion.Equals (t.IdSesion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdSesion.GetHashCode ();
        return hash;
}
}
}
