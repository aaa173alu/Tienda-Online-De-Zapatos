

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoRepository _IProductoRepository;

public ProductoCEN(IProductoRepository _IProductoRepository)
{
        this._IProductoRepository = _IProductoRepository;
}

public IProductoRepository get_IProductoRepository ()
{
        return this._IProductoRepository;
}

public ProductoEN ObtenerDetalles (int idProducto
                                   )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoRepository.ObtenerDetalles (idProducto);
        return productoEN;
}

public int Crear (int p_idProducto, string p_nombre, string p_descripcion, float p_precio, string p_tallasDisponibles, string p_fotos, int p_stock, bool p_destacado, System.Collections.Generic.IList<int> p_categoria_0)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.IdProducto = p_idProducto;

        productoEN.Nombre = p_nombre;

        productoEN.Descripcion = p_descripcion;

        productoEN.Precio = p_precio;

        productoEN.TallasDisponibles = p_tallasDisponibles;

        productoEN.Fotos = p_fotos;

        productoEN.Stock = p_stock;

        productoEN.Destacado = p_destacado;


        productoEN.Categoria_0 = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN>();
        if (p_categoria_0 != null) {
                foreach (int item in p_categoria_0) {
                        TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN en = new TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN ();
                        en.IdCategoria = item;
                        productoEN.Categoria_0.Add (en);
                }
        }

        else{
                productoEN.Categoria_0 = new System.Collections.Generic.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN>();
        }



        oid = _IProductoRepository.Crear (productoEN);
        return oid;
}

public void Modificar (int p_Producto_OID, string p_nombre, string p_descripcion, float p_precio, string p_tallasDisponibles, string p_fotos, int p_stock, bool p_destacado)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.IdProducto = p_Producto_OID;
        productoEN.Nombre = p_nombre;
        productoEN.Descripcion = p_descripcion;
        productoEN.Precio = p_precio;
        productoEN.TallasDisponibles = p_tallasDisponibles;
        productoEN.Fotos = p_fotos;
        productoEN.Stock = p_stock;
        productoEN.Destacado = p_destacado;
        //Call to ProductoRepository

        _IProductoRepository.Modificar (productoEN);
}

public void Borrar (int idProducto
                    )
{
        _IProductoRepository.Borrar (idProducto);
}

public ProductoEN ReadOID (int idProducto
                           )
{
        ProductoEN productoEN = null;

        productoEN = _IProductoRepository.ReadOID (idProducto);
        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameEconomico ()
{
        return _IProductoRepository.DameEconomico ();
}
public System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameDestacados ()
{
        return _IProductoRepository.DameDestacados ();
}
public System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DamePorPrecio ()
{
        return _IProductoRepository.DamePorPrecio ();
}
public System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameColor ()
{
        return _IProductoRepository.DameColor ();
}
}
}
