

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class AyudaCEN
 *
 */
public partial class AyudaCEN
{
private IAyudaRepository _IAyudaRepository;

public AyudaCEN(IAyudaRepository _IAyudaRepository)
{
        this._IAyudaRepository = _IAyudaRepository;
}

public IAyudaRepository get_IAyudaRepository ()
{
        return this._IAyudaRepository;
}

public int Crear (int p_idAyuda, string p_pregunta, string p_respuesta)
{
        AyudaEN ayudaEN = null;
        int oid;

        //Initialized AyudaEN
        ayudaEN = new AyudaEN ();
        ayudaEN.IdAyuda = p_idAyuda;

        ayudaEN.Pregunta = p_pregunta;

        ayudaEN.Respuesta = p_respuesta;



        oid = _IAyudaRepository.Crear (ayudaEN);
        return oid;
}

public void Modificar (int p_Ayuda_OID, string p_pregunta, string p_respuesta)
{
        AyudaEN ayudaEN = null;

        //Initialized AyudaEN
        ayudaEN = new AyudaEN ();
        ayudaEN.IdAyuda = p_Ayuda_OID;
        ayudaEN.Pregunta = p_pregunta;
        ayudaEN.Respuesta = p_respuesta;
        //Call to AyudaRepository

        _IAyudaRepository.Modificar (ayudaEN);
}

public void Borrar (int idAyuda
                    )
{
        _IAyudaRepository.Borrar (idAyuda);
}

public AyudaEN ReadOID (int idAyuda
                        )
{
        AyudaEN ayudaEN = null;

        ayudaEN = _IAyudaRepository.ReadOID (idAyuda);
        return ayudaEN;
}

public System.Collections.Generic.IList<AyudaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AyudaEN> list = null;

        list = _IAyudaRepository.ReadAll (first, size);
        return list;
}
}
}
