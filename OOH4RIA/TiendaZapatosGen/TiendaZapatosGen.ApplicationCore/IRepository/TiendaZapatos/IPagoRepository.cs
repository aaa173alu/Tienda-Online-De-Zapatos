
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IPagoRepository
{
void setSessionCP (GenericSessionCP session);

PagoEN ReadOIDDefault (int idPago
                       );

void ModifyDefault (PagoEN pago);

System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size);





int Crear (PagoEN pago);

void Modificar (PagoEN pago);


void Borrar (int idPago
             );


PagoEN ReadOID (int idPago
                );


System.Collections.Generic.IList<PagoEN> ReadAll (int first, int size);
}
}
