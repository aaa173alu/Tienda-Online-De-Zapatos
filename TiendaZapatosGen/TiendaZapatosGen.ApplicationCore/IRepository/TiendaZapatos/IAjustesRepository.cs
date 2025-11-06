
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IAjustesRepository
{
void setSessionCP (GenericSessionCP session);

AjustesEN ReadOIDDefault (int id
                          );

void ModifyDefault (AjustesEN ajustes);

System.Collections.Generic.IList<AjustesEN> ReadAllDefault (int first, int size);








int Crear (AjustesEN ajustes);

void Modificar (AjustesEN ajustes);


void Borrar (int id
             );


AjustesEN ReadOID (int id
                   );


System.Collections.Generic.IList<AjustesEN> ReadAll (int first, int size);
}
}
