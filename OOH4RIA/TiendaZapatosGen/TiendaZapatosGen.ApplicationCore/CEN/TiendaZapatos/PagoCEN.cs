

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class PagoCEN
 *
 */
public partial class PagoCEN
{
private IPagoRepository _IPagoRepository;

public PagoCEN(IPagoRepository _IPagoRepository)
{
        this._IPagoRepository = _IPagoRepository;
}

public IPagoRepository get_IPagoRepository ()
{
        return this._IPagoRepository;
}

public int Crear (int p_idPago, string p_attribute, Nullable<DateTime> p_fechaPago, float p_monto, int p_pedido_0)
{
        PagoEN pagoEN = null;
        int oid;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.IdPago = p_idPago;

        pagoEN.Attribute = p_attribute;

        pagoEN.FechaPago = p_fechaPago;

        pagoEN.Monto = p_monto;


        if (p_pedido_0 != -1) {
                // El argumento p_pedido_0 -> Property pedido_0 es oid = false
                // Lista de oids idPago
                pagoEN.Pedido_0 = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN ();
                pagoEN.Pedido_0.IdPedido = p_pedido_0;
        }



        oid = _IPagoRepository.Crear (pagoEN);
        return oid;
}

public void Modificar (int p_Pago_OID, string p_attribute, Nullable<DateTime> p_fechaPago, float p_monto)
{
        PagoEN pagoEN = null;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.IdPago = p_Pago_OID;
        pagoEN.Attribute = p_attribute;
        pagoEN.FechaPago = p_fechaPago;
        pagoEN.Monto = p_monto;
        //Call to PagoRepository

        _IPagoRepository.Modificar (pagoEN);
}

public void Borrar (int idPago
                    )
{
        _IPagoRepository.Borrar (idPago);
}

public PagoEN ReadOID (int idPago
                       )
{
        PagoEN pagoEN = null;

        pagoEN = _IPagoRepository.ReadOID (idPago);
        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> list = null;

        list = _IPagoRepository.ReadAll (first, size);
        return list;
}
}
}
