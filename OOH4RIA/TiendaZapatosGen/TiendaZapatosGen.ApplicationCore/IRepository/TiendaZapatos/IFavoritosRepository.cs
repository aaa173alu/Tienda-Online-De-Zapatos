
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IFavoritosRepository
{
void setSessionCP (GenericSessionCP session);

FavoritosEN ReadOIDDefault (int idFavoritos
                            );

void ModifyDefault (FavoritosEN favoritos);

System.Collections.Generic.IList<FavoritosEN> ReadAllDefault (int first, int size);



int AgregarAFavoritos (FavoritosEN favoritos);

void EliminarFavoritos (int idFavoritos
                        );


void VaciarFavoritos (int idFavoritos
                      );



int Crear (FavoritosEN favoritos);

void Modificar (FavoritosEN favoritos);


void Borrar (int idFavoritos
             );


FavoritosEN ReadOID (int idFavoritos
                     );


System.Collections.Generic.IList<FavoritosEN> ReadAll (int first, int size);
}
}
