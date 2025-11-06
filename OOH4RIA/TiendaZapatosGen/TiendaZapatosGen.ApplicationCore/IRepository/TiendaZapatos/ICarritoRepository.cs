
using System;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public partial interface ICarritoRepository
{
void setSessionCP (GenericSessionCP session);

CarritoEN ReadOIDDefault (int idCarrito
                          );

void ModifyDefault (CarritoEN carrito);

System.Collections.Generic.IList<CarritoEN> ReadAllDefault (int first, int size);



int AgregarProducto (CarritoEN carrito);

void ModificarCantidad (CarritoEN carrito);


void Eliminarproducto (int idCarrito
                       );




int Crear (CarritoEN carrito);

void Modificar (CarritoEN carrito);


void Borrar (int idCarrito
             );


CarritoEN ReadOID (int idCarrito
                   );


System.Collections.Generic.IList<CarritoEN> ReadAll (int first, int size);
}
}
