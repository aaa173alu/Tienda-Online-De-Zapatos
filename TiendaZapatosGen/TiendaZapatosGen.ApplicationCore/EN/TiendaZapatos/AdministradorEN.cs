
using System;
// Definición clase AdministradorEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class AdministradorEN
{
/**
 *	Atributo nombreUsuario
 */
private string nombreUsuario;



/**
 *	Atributo contrasenya
 */
private string contrasenya;






public virtual string NombreUsuario {
        get { return nombreUsuario; } set { nombreUsuario = value;  }
}



public virtual string Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}





public AdministradorEN()
{
}



public AdministradorEN(string nombreUsuario, string contrasenya
                       )
{
        this.init (NombreUsuario, contrasenya);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.NombreUsuario, administrador.Contrasenya);
}

private void init (string nombreUsuario
                   , string contrasenya)
{
        this.NombreUsuario = nombreUsuario;


        this.Contrasenya = contrasenya;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (NombreUsuario.Equals (t.NombreUsuario))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.NombreUsuario.GetHashCode ();
        return hash;
}
}
}
