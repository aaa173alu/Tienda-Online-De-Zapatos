
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface ISesionRepository
{
void setSessionCP (GenericSessionCP session);

SesionEN ReadOIDDefault (int idSesion
                         );

void ModifyDefault (SesionEN sesion);

System.Collections.Generic.IList<SesionEN> ReadAllDefault (int first, int size);






int Crear (SesionEN sesion);

void Modificar (SesionEN sesion);


void Borrar (int idSesion
             );


SesionEN ReadOID (int idSesion
                  );


System.Collections.Generic.IList<SesionEN> ReadAll (int first, int size);
}
}
