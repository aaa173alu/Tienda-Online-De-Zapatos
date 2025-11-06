
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IPedidoRepository
{
void setSessionCP (GenericSessionCP session);

PedidoEN ReadOIDDefault (int idPedido
                         );

void ModifyDefault (PedidoEN pedido);

System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size);



void CalcularTotal (int idPedido
                    );


int Crear (PedidoEN pedido);

void Modificar (PedidoEN pedido);


void Borrar (int idPedido
             );



PedidoEN ReadOID (int idPedido
                  );


System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size);
}
}
