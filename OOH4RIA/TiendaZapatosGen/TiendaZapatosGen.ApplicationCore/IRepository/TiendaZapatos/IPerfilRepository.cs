
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IPerfilRepository
{
void setSessionCP (GenericSessionCP session);

PerfilEN ReadOIDDefault (int idPerfin
                         );

void ModifyDefault (PerfilEN perfil);

System.Collections.Generic.IList<PerfilEN> ReadAllDefault (int first, int size);



void EditarNombre (PerfilEN perfil);


void EditarEmail (PerfilEN perfil);


void EditarContrasenya (PerfilEN perfil);


void EditarTelefono (PerfilEN perfil);


int Crear (PerfilEN perfil);

void Modificar (PerfilEN perfil);


void Borrar (int idPerfin
             );


PerfilEN ReadOID (int idPerfin
                  );


System.Collections.Generic.IList<PerfilEN> ReadAll (int first, int size);
}
}
