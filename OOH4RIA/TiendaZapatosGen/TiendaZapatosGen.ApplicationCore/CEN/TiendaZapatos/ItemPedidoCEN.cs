

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class ItemPedidoCEN
 *
 */
public partial class ItemPedidoCEN
{
private IItemPedidoRepository _IItemPedidoRepository;

public ItemPedidoCEN(IItemPedidoRepository _IItemPedidoRepository)
{
        this._IItemPedidoRepository = _IItemPedidoRepository;
}

public IItemPedidoRepository get_IItemPedidoRepository ()
{
        return this._IItemPedidoRepository;
}

public int Crear (int p_cantidad, string p_talla, string p_usuario)
{
        ItemPedidoEN itemPedidoEN = null;
        int oid;

        //Initialized ItemPedidoEN
        itemPedidoEN = new ItemPedidoEN ();
        itemPedidoEN.Cantidad = p_cantidad;

        itemPedidoEN.Talla = p_talla;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                itemPedidoEN.Usuario = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN ();
                itemPedidoEN.Usuario.Email = p_usuario;
        }



        oid = _IItemPedidoRepository.Crear (itemPedidoEN);
        return oid;
}

public void Modificar (int p_ItemPedido_OID, int p_cantidad, string p_talla)
{
        ItemPedidoEN itemPedidoEN = null;

        //Initialized ItemPedidoEN
        itemPedidoEN = new ItemPedidoEN ();
        itemPedidoEN.Id = p_ItemPedido_OID;
        itemPedidoEN.Cantidad = p_cantidad;
        itemPedidoEN.Talla = p_talla;
        //Call to ItemPedidoRepository

        _IItemPedidoRepository.Modificar (itemPedidoEN);
}

public void Borrar (int id
                    )
{
        _IItemPedidoRepository.Borrar (id);
}

public ItemPedidoEN ReadOID (int id
                             )
{
        ItemPedidoEN itemPedidoEN = null;

        itemPedidoEN = _IItemPedidoRepository.ReadOID (id);
        return itemPedidoEN;
}

public System.Collections.Generic.IList<ItemPedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ItemPedidoEN> list = null;

        list = _IItemPedidoRepository.ReadAll (first, size);
        return list;
}
}
}
