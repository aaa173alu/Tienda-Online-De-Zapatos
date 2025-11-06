
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
 * Clase Sesion:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class SesionRepository : BasicRepository, ISesionRepository
{
public SesionRepository() : base ()
{
}


public SesionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public SesionEN ReadOIDDefault (int idSesion
                                )
{
        SesionEN sesionEN = null;

        try
        {
                SessionInitializeTransaction ();
                sesionEN = (SesionEN)session.Get (typeof(SesionNH), idSesion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return sesionEN;
}

public System.Collections.Generic.IList<SesionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SesionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SesionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<SesionEN>();
                        else
                                result = session.CreateCriteria (typeof(SesionNH)).List<SesionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in SesionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SesionEN sesion)
{
        try
        {
                SessionInitializeTransaction ();
                SesionNH sesionNH = (SesionNH)session.Load (typeof(SesionNH), sesion.IdSesion);

                sesionNH.FechaInicio = sesion.FechaInicio;


                sesionNH.FechaFin = sesion.FechaFin;


                sesionNH.Activa = sesion.Activa;


                session.Update (sesionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in SesionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (SesionEN sesion)
{
        SesionNH sesionNH = new SesionNH (sesion);

        try
        {
                SessionInitializeTransaction ();

                session.Save (sesionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in SesionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sesionNH.IdSesion;
}

public void Modificar (SesionEN sesion)
{
        try
        {
                SessionInitializeTransaction ();
                SesionNH sesionNH = (SesionNH)session.Load (typeof(SesionNH), sesion.IdSesion);

                sesionNH.FechaInicio = sesion.FechaInicio;


                sesionNH.FechaFin = sesion.FechaFin;


                sesionNH.Activa = sesion.Activa;

                session.Update (sesionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in SesionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idSesion
                    )
{
        try
        {
                SessionInitializeTransaction ();
                SesionNH sesionNH = (SesionNH)session.Load (typeof(SesionNH), idSesion);
                session.Delete (sesionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in SesionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: SesionEN
public SesionEN ReadOID (int idSesion
                         )
{
        SesionEN sesionEN = null;

        try
        {
                SessionInitializeTransaction ();
                sesionEN = (SesionEN)session.Get (typeof(SesionNH), idSesion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return sesionEN;
}

public System.Collections.Generic.IList<SesionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SesionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SesionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<SesionEN>();
                else
                        result = session.CreateCriteria (typeof(SesionNH)).List<SesionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in SesionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
