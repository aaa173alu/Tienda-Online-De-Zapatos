

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class AjustesCEN
 *
 */
public partial class AjustesCEN
{
private IAjustesRepository _IAjustesRepository;

public AjustesCEN(IAjustesRepository _IAjustesRepository)
{
        this._IAjustesRepository = _IAjustesRepository;
}

public IAjustesRepository get_IAjustesRepository ()
{
        return this._IAjustesRepository;
}

public int Crear ()
{
        AjustesEN ajustesEN = null;
        int oid;

        //Initialized AjustesEN
        ajustesEN = new AjustesEN ();


        oid = _IAjustesRepository.Crear (ajustesEN);
        return oid;
}

public void Modificar (int p_Ajustes_OID)
{
        AjustesEN ajustesEN = null;

        //Initialized AjustesEN
        ajustesEN = new AjustesEN ();
        ajustesEN.Id = p_Ajustes_OID;
        //Call to AjustesRepository

        _IAjustesRepository.Modificar (ajustesEN);
}

public void Borrar (int id
                    )
{
        _IAjustesRepository.Borrar (id);
}

public AjustesEN ReadOID (int id
                          )
{
        AjustesEN ajustesEN = null;

        ajustesEN = _IAjustesRepository.ReadOID (id);
        return ajustesEN;
}

public System.Collections.Generic.IList<AjustesEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AjustesEN> list = null;

        list = _IAjustesRepository.ReadAll (first, size);
        return list;
}
}
}
