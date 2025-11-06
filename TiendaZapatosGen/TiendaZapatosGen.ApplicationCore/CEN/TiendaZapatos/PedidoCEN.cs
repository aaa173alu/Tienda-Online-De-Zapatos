

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public void CalcularTotal (int idPedido
                           )
{
        _IPedidoRepository.CalcularTotal (idPedido);
}

public int Crear (int p_idPedido, Nullable<DateTime> p_fecha, float p_total, string p_direccionEnvio, int p_estado, int p_itemPedido, string p_usuario)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.IdPedido = p_idPedido;

        pedidoEN.Fecha = p_fecha;

        pedidoEN.Total = p_total;

        pedidoEN.DireccionEnvio = p_direccionEnvio;

        pedidoEN.Estado = p_estado;


        if (p_itemPedido != -1) {
                // El argumento p_itemPedido -> Property itemPedido es oid = false
                // Lista de oids idPedido
                pedidoEN.ItemPedido = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ItemPedidoEN ();
                pedidoEN.ItemPedido.Id = p_itemPedido;
        }


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids idPedido
                pedidoEN.Usuario = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN ();
                pedidoEN.Usuario.Email = p_usuario;
        }



        oid = _IPedidoRepository.Crear (pedidoEN);
        return oid;
}

public void Modificar (int p_Pedido_OID, Nullable<DateTime> p_fecha, float p_total, string p_direccionEnvio, int p_estado)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.IdPedido = p_Pedido_OID;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.Total = p_total;
        pedidoEN.DireccionEnvio = p_direccionEnvio;
        pedidoEN.Estado = p_estado;
        //Call to PedidoRepository

        _IPedidoRepository.Modificar (pedidoEN);
}

public void Borrar (int idPedido
                    )
{
        _IPedidoRepository.Borrar (idPedido);
}

public PedidoEN ReadOID (int idPedido
                         )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoRepository.ReadOID (idPedido);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoRepository.ReadAll (first, size);
        return list;
}
}
}
