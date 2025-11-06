
using System;
using System.Text;
using TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.Exceptions;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;
using TiendaZapatosGen.Infraestructure.EN.TiendaZapatos;


/*
 * Clase Producto:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class ProductoRepository : BasicRepository, IProductoRepository
{
public ProductoRepository() : base ()
{
}


public ProductoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ProductoEN ReadOIDDefault (int idProducto
                                  )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), idProducto);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.IdProducto);

                productoNH.Nombre = producto.Nombre;


                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.TallasDisponibles = producto.TallasDisponibles;


                productoNH.Fotos = producto.Fotos;


                productoNH.Stock = producto.Stock;


                productoNH.Destacado = producto.Destacado;



                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


//Sin e: ObtenerDetalles
//Con e: ProductoEN
public ProductoEN ObtenerDetalles (int idProducto
                                   )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), idProducto);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public int Crear (ProductoEN producto)
{
        ProductoNH productoNH = new ProductoNH (producto);

        try
        {
                SessionInitializeTransaction ();
                if (producto.Categoria_0 != null) {
                        for (int i = 0; i < producto.Categoria_0.Count; i++) {
                                producto.Categoria_0 [i] = (TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN)session.Load (typeof(TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.CategoriaEN), producto.Categoria_0 [i].IdCategoria);
                                producto.Categoria_0 [i].Categoria = producto;
                        }
                }

                session.Save (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoNH.IdProducto;
}

public void Modificar (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.IdProducto);

                productoNH.Nombre = producto.Nombre;


                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.TallasDisponibles = producto.TallasDisponibles;


                productoNH.Fotos = producto.Fotos;


                productoNH.Stock = producto.Stock;


                productoNH.Destacado = producto.Destacado;

                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idProducto
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), idProducto);
                session.Delete (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ProductoEN
public ProductoEN ReadOID (int idProducto
                           )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), idProducto);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameEconomico ()
{
        System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where FROM ProductoNH pro where pro.Precio < 70";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHdameEconomicoHQL");

                result = query.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameDestacados ()
{
        System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where FROM ProductoNH pro WHERE pro.Destacado = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHdameDestacadosHQL");

                result = query.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DamePorPrecio ()
{
        System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where FROM ProductoNH p WHERE p.Precio >= 50 AND p.Precio <= 100";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHdamePorPrecioHQL");

                result = query.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> DameColor ()
{
        System.Collections.Generic.IList<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where FROM ProductoNH pro WHERE pro.Color = :color";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHdameColorHQL");

                result = query.List<TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
