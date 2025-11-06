
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IItemPedidoRepository
{
void setSessionCP (GenericSessionCP session);

ItemPedidoEN ReadOIDDefault (int id
                             );

void ModifyDefault (ItemPedidoEN itemPedido);

System.Collections.Generic.IList<ItemPedidoEN> ReadAllDefault (int first, int size);



int Crear (ItemPedidoEN itemPedido);

void Modificar (ItemPedidoEN itemPedido);


void Borrar (int id
             );



ItemPedidoEN ReadOID (int id
                      );


System.Collections.Generic.IList<ItemPedidoEN> ReadAll (int first, int size);
}
}
