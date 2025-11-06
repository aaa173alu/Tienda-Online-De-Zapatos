

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}

public string Crear (string p_nombre, string p_email, string p_contrasenya, string p_telefono, string p_direccion, string p_rol, int p_sesion, int p_usuario_0, int p_usuario_1)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Email = p_email;

        usuarioEN.Contrasenya = p_contrasenya;

        usuarioEN.Telefono = p_telefono;

        usuarioEN.Direccion = p_direccion;

        usuarioEN.Rol = p_rol;


        if (p_sesion != -1) {
                // El argumento p_sesion -> Property sesion es oid = false
                // Lista de oids email
                usuarioEN.Sesion = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.SesionEN ();
                usuarioEN.Sesion.IdSesion = p_sesion;
        }


        if (p_usuario_0 != -1) {
                // El argumento p_usuario_0 -> Property usuario_0 es oid = false
                // Lista de oids email
                usuarioEN.Usuario_0 = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PerfilEN ();
                usuarioEN.Usuario_0.IdPerfin = p_usuario_0;
        }


        if (p_usuario_1 != -1) {
                // El argumento p_usuario_1 -> Property usuario_1 es oid = false
                // Lista de oids email
                usuarioEN.Usuario_1 = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.AyudaEN ();
                usuarioEN.Usuario_1.IdAyuda = p_usuario_1;
        }



        oid = _IUsuarioRepository.Crear (usuarioEN);
        return oid;
}

public void Modificar (string p_Usuario_OID, string p_nombre, string p_contrasenya, string p_telefono, string p_direccion, string p_rol)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Contrasenya = p_contrasenya;
        usuarioEN.Telefono = p_telefono;
        usuarioEN.Direccion = p_direccion;
        usuarioEN.Rol = p_rol;
        //Call to UsuarioRepository

        _IUsuarioRepository.Modificar (usuarioEN);
}

public void Borrar (string email
                    )
{
        _IUsuarioRepository.Borrar (email);
}

public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioRepository.ReadOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioRepository.ReadAll (first, size);
        return list;
}
}
}
