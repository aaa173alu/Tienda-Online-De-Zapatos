
using System;
// Definición clase AyudaEN
namespace TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos
{
public partial class AyudaEN
{
/**
 *	Atributo idAyuda
 */
private int idAyuda;



/**
 *	Atributo pregunta
 */
private string pregunta;



/**
 *	Atributo respuesta
 */
private string respuesta;



/**
 *	Atributo usuario_2
 */
private TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_2;






public virtual int IdAyuda {
        get { return idAyuda; } set { idAyuda = value;  }
}



public virtual string Pregunta {
        get { return pregunta; } set { pregunta = value;  }
}



public virtual string Respuesta {
        get { return respuesta; } set { respuesta = value;  }
}



public virtual TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN Usuario_2 {
        get { return usuario_2; } set { usuario_2 = value;  }
}





public AyudaEN()
{
}



public AyudaEN(int idAyuda, string pregunta, string respuesta, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_2
               )
{
        this.init (IdAyuda, pregunta, respuesta, usuario_2);
}


public AyudaEN(AyudaEN ayuda)
{
        this.init (ayuda.IdAyuda, ayuda.Pregunta, ayuda.Respuesta, ayuda.Usuario_2);
}

private void init (int idAyuda
                   , string pregunta, string respuesta, TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN usuario_2)
{
        this.IdAyuda = idAyuda;


        this.Pregunta = pregunta;

        this.Respuesta = respuesta;

        this.Usuario_2 = usuario_2;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AyudaEN t = obj as AyudaEN;
        if (t == null)
                return false;
        if (IdAyuda.Equals (t.IdAyuda))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdAyuda.GetHashCode ();
        return hash;
}
}
}
