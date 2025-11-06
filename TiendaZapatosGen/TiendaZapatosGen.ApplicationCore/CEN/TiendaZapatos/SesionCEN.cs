

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class SesionCEN
 *
 */
public partial class SesionCEN
{
private ISesionRepository _ISesionRepository;

public SesionCEN(ISesionRepository _ISesionRepository)
{
        this._ISesionRepository = _ISesionRepository;
}

public ISesionRepository get_ISesionRepository ()
{
        return this._ISesionRepository;
}

public int Crear (int p_idSesion, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, bool p_activa)
{
        SesionEN sesionEN = null;
        int oid;

        //Initialized SesionEN
        sesionEN = new SesionEN ();
        sesionEN.IdSesion = p_idSesion;

        sesionEN.FechaInicio = p_fechaInicio;

        sesionEN.FechaFin = p_fechaFin;

        sesionEN.Activa = p_activa;



        oid = _ISesionRepository.Crear (sesionEN);
        return oid;
}

public void Modificar (int p_Sesion_OID, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, bool p_activa)
{
        SesionEN sesionEN = null;

        //Initialized SesionEN
        sesionEN = new SesionEN ();
        sesionEN.IdSesion = p_Sesion_OID;
        sesionEN.FechaInicio = p_fechaInicio;
        sesionEN.FechaFin = p_fechaFin;
        sesionEN.Activa = p_activa;
        //Call to SesionRepository

        _ISesionRepository.Modificar (sesionEN);
}

public void Borrar (int idSesion
                    )
{
        _ISesionRepository.Borrar (idSesion);
}

public SesionEN ReadOID (int idSesion
                         )
{
        SesionEN sesionEN = null;

        sesionEN = _ISesionRepository.ReadOID (idSesion);
        return sesionEN;
}

public System.Collections.Generic.IList<SesionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SesionEN> list = null;

        list = _ISesionRepository.ReadAll (first, size);
        return list;
}
}
}
