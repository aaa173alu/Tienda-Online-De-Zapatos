
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IAdministradorRepository
{
void setSessionCP (GenericSessionCP session);

AdministradorEN ReadOIDDefault (string nombreUsuario
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



string CrearProducto (AdministradorEN administrador);

void EditarProducto (AdministradorEN administrador);


void EliminarProducto (string nombreUsuario
                       );






AdministradorEN ReadOID (string nombreUsuario
                         );


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);
}
}
