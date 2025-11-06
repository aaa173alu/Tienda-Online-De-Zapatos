
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);





string Crear (UsuarioEN usuario);

void Modificar (UsuarioEN usuario);


void Borrar (string email
             );




UsuarioEN ReadOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);
}
}
