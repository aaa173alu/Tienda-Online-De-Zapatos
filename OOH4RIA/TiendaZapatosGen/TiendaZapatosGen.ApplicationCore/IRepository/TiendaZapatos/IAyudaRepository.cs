
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IAyudaRepository
{
void setSessionCP (GenericSessionCP session);

AyudaEN ReadOIDDefault (int idAyuda
                        );

void ModifyDefault (AyudaEN ayuda);

System.Collections.Generic.IList<AyudaEN> ReadAllDefault (int first, int size);





int Crear (AyudaEN ayuda);

void Modificar (AyudaEN ayuda);


void Borrar (int idAyuda
             );


AyudaEN ReadOID (int idAyuda
                 );


System.Collections.Generic.IList<AyudaEN> ReadAll (int first, int size);
}
}
