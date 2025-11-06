
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface IProductoRepository
{
void setSessionCP (GenericSessionCP session);

ProductoEN ReadOIDDefault (int idProducto
                           );

void ModifyDefault (ProductoEN producto);

System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size);



ProductoEN ObtenerDetalles (int idProducto
                            );


int Crear (ProductoEN producto);

void Modificar (ProductoEN producto);


void Borrar (int idProducto
             );


ProductoEN ReadOID (int idProducto
                    );


System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameEconomico ();


System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameDestacados ();


System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DamePorPrecio ();


System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameColor ();
}
}
