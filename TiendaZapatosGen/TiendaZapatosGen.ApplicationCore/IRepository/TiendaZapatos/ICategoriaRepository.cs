
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface ICategoriaRepository
{
void setSessionCP (GenericSessionCP session);

CategoriaEN ReadOIDDefault (int idCategoria
                            );

void ModifyDefault (CategoriaEN categoria);

System.Collections.Generic.IList<CategoriaEN> ReadAllDefault (int first, int size);



int Crear (CategoriaEN categoria);

void Modificar (CategoriaEN categoria);


void Borrar (int idCategoria
             );



CategoriaEN ReadOID (int idCategoria
                     );


System.Collections.Generic.IList<CategoriaEN> ReadAll (int first, int size);
}
}
