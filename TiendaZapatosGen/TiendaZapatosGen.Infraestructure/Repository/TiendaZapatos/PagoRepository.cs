
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
 * Clase Pago:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class PagoRepository : BasicRepository, IPagoRepository
{
public PagoRepository() : base ()
{
}


public PagoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PagoEN ReadOIDDefault (int idPago
                              )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoNH), idPago);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PagoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                        else
                                result = session.CreateCriteria (typeof(PagoNH)).List<PagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), pago.IdPago);

                pagoNH.Attribute = pago.Attribute;


                pagoNH.FechaPago = pago.FechaPago;


                pagoNH.Monto = pago.Monto;


                session.Update (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (PagoEN pago)
{
        PagoNH pagoNH = new PagoNH (pago);

        try
        {
                SessionInitializeTransaction ();
                if (pago.Pedido_0 != null) {
                        // Argumento OID y no colección.
                        pagoNH
                        .Pedido_0 = (TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN)session.Load (typeof(TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.PedidoEN), pago.Pedido_0.IdPedido);

                        pagoNH.Pedido_0.Pedido
                                = pagoNH;
                }

                session.Save (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pagoNH.IdPago;
}

public void Modificar (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), pago.IdPago);

                pagoNH.Attribute = pago.Attribute;


                pagoNH.FechaPago = pago.FechaPago;


                pagoNH.Monto = pago.Monto;

                session.Update (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idPago
                    )
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), idPago);
                session.Delete (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PagoEN
public PagoEN ReadOID (int idPago
                       )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoNH), idPago);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PagoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                else
                        result = session.CreateCriteria (typeof(PagoNH)).List<PagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
