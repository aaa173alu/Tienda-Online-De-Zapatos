
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
 * Clase Carrito:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class CarritoRepository : BasicRepository, ICarritoRepository
{
public CarritoRepository() : base ()
{
}


public CarritoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CarritoEN ReadOIDDefault (int idCarrito
                                 )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoNH), idCarrito);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CarritoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CarritoEN>();
                        else
                                result = session.CreateCriteria (typeof(CarritoNH)).List<CarritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), carrito.IdCarrito);

                carritoNH.Total = carrito.Total;


                carritoNH.FechaCreacion = carrito.FechaCreacion;



                session.Update (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int AgregarProducto (CarritoEN carrito)
{
        CarritoNH carritoNH = new CarritoNH (carrito);

        try
        {
                SessionInitializeTransaction ();
                if (carrito.Usuario_3 != null) {
                        // Argumento OID y no colección.
                        carritoNH
                        .Usuario_3 = (TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN)session.Load (typeof(TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN), carrito.Usuario_3.Email);

                        carritoNH.Usuario_3.Usuario_2
                                = carritoNH;
                }

                session.Save (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carritoNH.IdCarrito;
}

public void ModificarCantidad (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), carrito.IdCarrito);

                carritoNH.Total = carrito.Total;


                carritoNH.FechaCreacion = carrito.FechaCreacion;

                session.Update (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminarproducto (int idCarrito
                              )
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), idCarrito);
                session.Delete (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int Crear (CarritoEN carrito)
{
        CarritoNH carritoNH = new CarritoNH (carrito);

        try
        {
                SessionInitializeTransaction ();
                if (carrito.Usuario_3 != null) {
                        // Argumento OID y no colección.
                        carritoNH
                        .Usuario_3 = (TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN)session.Load (typeof(TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN), carrito.Usuario_3.Email);

                        carritoNH.Usuario_3.Usuario_2
                                = carritoNH;
                }

                session.Save (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carritoNH.IdCarrito;
}

public void Modificar (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), carrito.IdCarrito);

                carritoNH.Total = carrito.Total;


                carritoNH.FechaCreacion = carrito.FechaCreacion;

                session.Update (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idCarrito
                    )
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), idCarrito);
                session.Delete (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CarritoEN
public CarritoEN ReadOID (int idCarrito
                          )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoNH), idCarrito);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CarritoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<CarritoEN>();
                else
                        result = session.CreateCriteria (typeof(CarritoNH)).List<CarritoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
