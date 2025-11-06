

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class PerfilCEN
 *
 */
public partial class PerfilCEN
{
private IPerfilRepository _IPerfilRepository;

public PerfilCEN(IPerfilRepository _IPerfilRepository)
{
        this._IPerfilRepository = _IPerfilRepository;
}

public IPerfilRepository get_IPerfilRepository ()
{
        return this._IPerfilRepository;
}

public void EditarNombre (int p_Perfil_OID, string p_nombre, string p_email, string p_contrasenya, int p_telefono)
{
        PerfilEN perfilEN = null;

        //Initialized PerfilEN
        perfilEN = new PerfilEN ();
        perfilEN.IdPerfin = p_Perfil_OID;
        perfilEN.Nombre = p_nombre;
        perfilEN.Email = p_email;
        perfilEN.Contrasenya = p_contrasenya;
        perfilEN.Telefono = p_telefono;
        //Call to PerfilRepository

        _IPerfilRepository.EditarNombre (perfilEN);
}

public void EditarEmail (int p_Perfil_OID, string p_nombre, string p_email, string p_contrasenya, int p_telefono)
{
        PerfilEN perfilEN = null;

        //Initialized PerfilEN
        perfilEN = new PerfilEN ();
        perfilEN.IdPerfin = p_Perfil_OID;
        perfilEN.Nombre = p_nombre;
        perfilEN.Email = p_email;
        perfilEN.Contrasenya = p_contrasenya;
        perfilEN.Telefono = p_telefono;
        //Call to PerfilRepository

        _IPerfilRepository.EditarEmail (perfilEN);
}

public void EditarContrasenya (int p_Perfil_OID, string p_nombre, string p_email, string p_contrasenya, int p_telefono)
{
        PerfilEN perfilEN = null;

        //Initialized PerfilEN
        perfilEN = new PerfilEN ();
        perfilEN.IdPerfin = p_Perfil_OID;
        perfilEN.Nombre = p_nombre;
        perfilEN.Email = p_email;
        perfilEN.Contrasenya = p_contrasenya;
        perfilEN.Telefono = p_telefono;
        //Call to PerfilRepository

        _IPerfilRepository.EditarContrasenya (perfilEN);
}

public void EditarTelefono (int p_Perfil_OID, string p_nombre, string p_email, string p_contrasenya, int p_telefono)
{
        PerfilEN perfilEN = null;

        //Initialized PerfilEN
        perfilEN = new PerfilEN ();
        perfilEN.IdPerfin = p_Perfil_OID;
        perfilEN.Nombre = p_nombre;
        perfilEN.Email = p_email;
        perfilEN.Contrasenya = p_contrasenya;
        perfilEN.Telefono = p_telefono;
        //Call to PerfilRepository

        _IPerfilRepository.EditarTelefono (perfilEN);
}

public int Crear (int p_idPerfin, string p_nombre, string p_email, string p_contrasenya, int p_telefono)
{
        PerfilEN perfilEN = null;
        int oid;

        //Initialized PerfilEN
        perfilEN = new PerfilEN ();
        perfilEN.IdPerfin = p_idPerfin;

        perfilEN.Nombre = p_nombre;

        perfilEN.Email = p_email;

        perfilEN.Contrasenya = p_contrasenya;

        perfilEN.Telefono = p_telefono;



        oid = _IPerfilRepository.Crear (perfilEN);
        return oid;
}

public void Modificar (int p_Perfil_OID, string p_nombre, string p_email, string p_contrasenya, int p_telefono)
{
        PerfilEN perfilEN = null;

        //Initialized PerfilEN
        perfilEN = new PerfilEN ();
        perfilEN.IdPerfin = p_Perfil_OID;
        perfilEN.Nombre = p_nombre;
        perfilEN.Email = p_email;
        perfilEN.Contrasenya = p_contrasenya;
        perfilEN.Telefono = p_telefono;
        //Call to PerfilRepository

        _IPerfilRepository.Modificar (perfilEN);
}

public void Borrar (int idPerfin
                    )
{
        _IPerfilRepository.Borrar (idPerfin);
}

public PerfilEN ReadOID (int idPerfin
                         )
{
        PerfilEN perfilEN = null;

        perfilEN = _IPerfilRepository.ReadOID (idPerfin);
        return perfilEN;
}

public System.Collections.Generic.IList<PerfilEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PerfilEN> list = null;

        list = _IPerfilRepository.ReadAll (first, size);
        return list;
}
}
}
