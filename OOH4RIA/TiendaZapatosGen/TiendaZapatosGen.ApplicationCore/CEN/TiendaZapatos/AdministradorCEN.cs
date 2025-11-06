

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorRepository _IAdministradorRepository;

public AdministradorCEN(IAdministradorRepository _IAdministradorRepository)
{
        this._IAdministradorRepository = _IAdministradorRepository;
}

public IAdministradorRepository get_IAdministradorRepository ()
{
        return this._IAdministradorRepository;
}

public string CrearProducto (string p_nombreUsuario, string p_contrasenya)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.NombreUsuario = p_nombreUsuario;

        administradorEN.Contrasenya = p_contrasenya;



        oid = _IAdministradorRepository.CrearProducto (administradorEN);
        return oid;
}

public void EditarProducto (string p_Administrador_OID, string p_contrasenya)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.NombreUsuario = p_Administrador_OID;
        administradorEN.Contrasenya = p_contrasenya;
        //Call to AdministradorRepository

        _IAdministradorRepository.EditarProducto (administradorEN);
}

public void EliminarProducto (string nombreUsuario
                              )
{
        _IAdministradorRepository.EliminarProducto (nombreUsuario);
}

public AdministradorEN ReadOID (string nombreUsuario
                                )
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorRepository.ReadOID (nombreUsuario);
        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorRepository.ReadAll (first, size);
        return list;
}
}
}
