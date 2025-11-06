

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class CarritoCEN
 *
 */
public partial class CarritoCEN
{
private ICarritoRepository _ICarritoRepository;

public CarritoCEN(ICarritoRepository _ICarritoRepository)
{
        this._ICarritoRepository = _ICarritoRepository;
}

public ICarritoRepository get_ICarritoRepository ()
{
        return this._ICarritoRepository;
}

public int AgregarProducto (int p_idCarrito, float p_total, Nullable<DateTime> p_fechaCreacion, string p_usuario_3)
{
        CarritoEN carritoEN = null;
        int oid;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.IdCarrito = p_idCarrito;

        carritoEN.Total = p_total;

        carritoEN.FechaCreacion = p_fechaCreacion;


        if (p_usuario_3 != null) {
                // El argumento p_usuario_3 -> Property usuario_3 es oid = false
                // Lista de oids idCarrito
                carritoEN.Usuario_3 = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN ();
                carritoEN.Usuario_3.Email = p_usuario_3;
        }



        oid = _ICarritoRepository.AgregarProducto (carritoEN);
        return oid;
}

public void ModificarCantidad (int p_Carrito_OID, float p_total, Nullable<DateTime> p_fechaCreacion)
{
        CarritoEN carritoEN = null;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.IdCarrito = p_Carrito_OID;
        carritoEN.Total = p_total;
        carritoEN.FechaCreacion = p_fechaCreacion;
        //Call to CarritoRepository

        _ICarritoRepository.ModificarCantidad (carritoEN);
}

public void Eliminarproducto (int idCarrito
                              )
{
        _ICarritoRepository.Eliminarproducto (idCarrito);
}

public int Crear (int p_idCarrito, float p_total, Nullable<DateTime> p_fechaCreacion, string p_usuario_3)
{
        CarritoEN carritoEN = null;
        int oid;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.IdCarrito = p_idCarrito;

        carritoEN.Total = p_total;

        carritoEN.FechaCreacion = p_fechaCreacion;


        if (p_usuario_3 != null) {
                // El argumento p_usuario_3 -> Property usuario_3 es oid = false
                // Lista de oids idCarrito
                carritoEN.Usuario_3 = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN ();
                carritoEN.Usuario_3.Email = p_usuario_3;
        }



        oid = _ICarritoRepository.Crear (carritoEN);
        return oid;
}

public void Modificar (int p_Carrito_OID, float p_total, Nullable<DateTime> p_fechaCreacion)
{
        CarritoEN carritoEN = null;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.IdCarrito = p_Carrito_OID;
        carritoEN.Total = p_total;
        carritoEN.FechaCreacion = p_fechaCreacion;
        //Call to CarritoRepository

        _ICarritoRepository.Modificar (carritoEN);
}

public void Borrar (int idCarrito
                    )
{
        _ICarritoRepository.Borrar (idCarrito);
}

public CarritoEN ReadOID (int idCarrito
                          )
{
        CarritoEN carritoEN = null;

        carritoEN = _ICarritoRepository.ReadOID (idCarrito);
        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> list = null;

        list = _ICarritoRepository.ReadAll (first, size);
        return list;
}
}
}
