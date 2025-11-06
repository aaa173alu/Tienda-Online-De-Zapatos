
using System;
// Definición clase PerfilEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class PerfilEN
{
/**
 *	Atributo idPerfin
 */
private int idPerfin;



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
private int telefono;



/**
 *	Atributo usuario_1
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_1;






public virtual int IdPerfin {
        get { return idPerfin; } set { idPerfin = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN Usuario_1 {
        get { return usuario_1; } set { usuario_1 = value;  }
}





public PerfilEN()
{
}



public PerfilEN(int idPerfin, string nombre, string email, string contrasenya, int telefono, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_1
                )
{
        this.init (IdPerfin, nombre, email, contrasenya, telefono, usuario_1);
}


public PerfilEN(PerfilEN perfil)
{
        this.init (perfil.IdPerfin, perfil.Nombre, perfil.Email, perfil.Contrasenya, perfil.Telefono, perfil.Usuario_1);
}

private void init (int idPerfin
                   , string nombre, string email, string contrasenya, int telefono, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_1)
{
        this.IdPerfin = idPerfin;


        this.Nombre = nombre;

        this.Email = email;

        this.Contrasenya = contrasenya;

        this.Telefono = telefono;

        this.Usuario_1 = usuario_1;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PerfilEN t = obj as PerfilEN;
        if (t == null)
                return false;
        if (IdPerfin.Equals (t.IdPerfin))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdPerfin.GetHashCode ();
        return hash;
}
}
}
