
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
 * Clase Ajustes:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class AjustesRepository : BasicRepository, IAjustesRepository
{
public AjustesRepository() : base ()
{
}


public AjustesRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public AjustesEN ReadOIDDefault (int id
                                 )
{
        AjustesEN ajustesEN = null;

        try
        {
                SessionInitializeTransaction ();
                ajustesEN = (AjustesEN)session.Get (typeof(AjustesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return ajustesEN;
}

public System.Collections.Generic.IList<AjustesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AjustesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AjustesNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<AjustesEN>();
                        else
                                result = session.CreateCriteria (typeof(AjustesNH)).List<AjustesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AjustesRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AjustesEN ajustes)
{
        try
        {
                SessionInitializeTransaction ();
                AjustesNH ajustesNH = (AjustesNH)session.Load (typeof(AjustesNH), ajustes.Id);

                session.Update (ajustesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AjustesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (AjustesEN ajustes)
{
        AjustesNH ajustesNH = new AjustesNH (ajustes);

        try
        {
                SessionInitializeTransaction ();

                session.Save (ajustesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AjustesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ajustesNH.Id;
}

public void Modificar (AjustesEN ajustes)
{
        try
        {
                SessionInitializeTransaction ();
                AjustesNH ajustesNH = (AjustesNH)session.Load (typeof(AjustesNH), ajustes.Id);
                session.Update (ajustesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AjustesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int id
                    )
{
        try
        {
                SessionInitializeTransaction ();
                AjustesNH ajustesNH = (AjustesNH)session.Load (typeof(AjustesNH), id);
                session.Delete (ajustesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AjustesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AjustesEN
public AjustesEN ReadOID (int id
                          )
{
        AjustesEN ajustesEN = null;

        try
        {
                SessionInitializeTransaction ();
                ajustesEN = (AjustesEN)session.Get (typeof(AjustesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return ajustesEN;
}

public System.Collections.Generic.IList<AjustesEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AjustesEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AjustesNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<AjustesEN>();
                else
                        result = session.CreateCriteria (typeof(AjustesNH)).List<AjustesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AjustesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
