
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
 * Clase Ayuda:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class AyudaRepository : BasicRepository, IAyudaRepository
{
public AyudaRepository() : base ()
{
}


public AyudaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public AyudaEN ReadOIDDefault (int idAyuda
                               )
{
        AyudaEN ayudaEN = null;

        try
        {
                SessionInitializeTransaction ();
                ayudaEN = (AyudaEN)session.Get (typeof(AyudaNH), idAyuda);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return ayudaEN;
}

public System.Collections.Generic.IList<AyudaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AyudaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AyudaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<AyudaEN>();
                        else
                                result = session.CreateCriteria (typeof(AyudaNH)).List<AyudaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AyudaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AyudaEN ayuda)
{
        try
        {
                SessionInitializeTransaction ();
                AyudaNH ayudaNH = (AyudaNH)session.Load (typeof(AyudaNH), ayuda.IdAyuda);

                ayudaNH.Pregunta = ayuda.Pregunta;


                ayudaNH.Respuesta = ayuda.Respuesta;


                session.Update (ayudaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AyudaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (AyudaEN ayuda)
{
        AyudaNH ayudaNH = new AyudaNH (ayuda);

        try
        {
                SessionInitializeTransaction ();

                session.Save (ayudaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AyudaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ayudaNH.IdAyuda;
}

public void Modificar (AyudaEN ayuda)
{
        try
        {
                SessionInitializeTransaction ();
                AyudaNH ayudaNH = (AyudaNH)session.Load (typeof(AyudaNH), ayuda.IdAyuda);

                ayudaNH.Pregunta = ayuda.Pregunta;


                ayudaNH.Respuesta = ayuda.Respuesta;

                session.Update (ayudaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AyudaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idAyuda
                    )
{
        try
        {
                SessionInitializeTransaction ();
                AyudaNH ayudaNH = (AyudaNH)session.Load (typeof(AyudaNH), idAyuda);
                session.Delete (ayudaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AyudaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AyudaEN
public AyudaEN ReadOID (int idAyuda
                        )
{
        AyudaEN ayudaEN = null;

        try
        {
                SessionInitializeTransaction ();
                ayudaEN = (AyudaEN)session.Get (typeof(AyudaNH), idAyuda);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return ayudaEN;
}

public System.Collections.Generic.IList<AyudaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AyudaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AyudaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<AyudaEN>();
                else
                        result = session.CreateCriteria (typeof(AyudaNH)).List<AyudaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in AyudaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
