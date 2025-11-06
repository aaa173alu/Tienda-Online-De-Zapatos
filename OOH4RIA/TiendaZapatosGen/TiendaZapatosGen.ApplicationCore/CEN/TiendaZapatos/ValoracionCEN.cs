

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionRepository _IValoracionRepository;

public ValoracionCEN(IValoracionRepository _IValoracionRepository)
{
        this._IValoracionRepository = _IValoracionRepository;
}

public IValoracionRepository get_IValoracionRepository ()
{
        return this._IValoracionRepository;
}

public int CrearValoracion (int p_idValoracion, int p_valoracion, string p_comentario, string p_valoracion_1, int p_producto)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.IdValoracion = p_idValoracion;

        valoracionEN.Valoracion = p_valoracion;

        valoracionEN.Comentario = p_comentario;


        if (p_valoracion_1 != null) {
                // El argumento p_valoracion_1 -> Property valoracion_1 es oid = false
                // Lista de oids idValoracion
                valoracionEN.Valoracion_1 = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN ();
                valoracionEN.Valoracion_1.Email = p_valoracion_1;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids idValoracion
                valoracionEN.Producto = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN ();
                valoracionEN.Producto.IdProducto = p_producto;
        }



        oid = _IValoracionRepository.CrearValoracion (valoracionEN);
        return oid;
}

public void EditarValoracion (int p_Valoracion_OID, int p_valoracion, string p_comentario)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.IdValoracion = p_Valoracion_OID;
        valoracionEN.Valoracion = p_valoracion;
        valoracionEN.Comentario = p_comentario;
        //Call to ValoracionRepository

        _IValoracionRepository.EditarValoracion (valoracionEN);
}

public void EliminarValoracion (int idValoracion
                                )
{
        _IValoracionRepository.EliminarValoracion (idValoracion);
}

public ValoracionEN ReadOID (int idValoracion
                             )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionRepository.ReadOID (idValoracion);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionRepository.ReadAll (first, size);
        return list;
}
}
}
