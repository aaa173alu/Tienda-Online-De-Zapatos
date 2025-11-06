
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IValoracionRepository
{
void setSessionCP (GenericSessionCP session);

ValoracionEN ReadOIDDefault (int idValoracion
                             );

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);



int CrearValoracion (ValoracionEN valoracion);

void EditarValoracion (ValoracionEN valoracion);


void EliminarValoracion (int idValoracion
                         );


ValoracionEN ReadOID (int idValoracion
                      );


System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size);
}
}
