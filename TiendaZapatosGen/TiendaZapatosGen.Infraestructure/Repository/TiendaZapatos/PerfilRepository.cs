
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
 * Clase Perfil:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class PerfilRepository : BasicRepository, IPerfilRepository
{
public PerfilRepository() : base ()
{
}


public PerfilRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PerfilEN ReadOIDDefault (int idPerfin
                                )
{
        PerfilEN perfilEN = null;

        try
        {
                SessionInitializeTransaction ();
                perfilEN = (PerfilEN)session.Get (typeof(PerfilNH), idPerfin);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return perfilEN;
}

public System.Collections.Generic.IList<PerfilEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PerfilEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PerfilNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PerfilEN>();
                        else
                                result = session.CreateCriteria (typeof(PerfilNH)).List<PerfilEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PerfilEN perfil)
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), perfil.IdPerfin);

                perfilNH.Nombre = perfil.Nombre;


                perfilNH.Email = perfil.Email;


                perfilNH.Contrasenya = perfil.Contrasenya;


                perfilNH.Telefono = perfil.Telefono;


                session.Update (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void EditarNombre (PerfilEN perfil)
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), perfil.IdPerfin);

                perfilNH.Nombre = perfil.Nombre;


                perfilNH.Email = perfil.Email;


                perfilNH.Contrasenya = perfil.Contrasenya;


                perfilNH.Telefono = perfil.Telefono;

                session.Update (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EditarEmail (PerfilEN perfil)
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), perfil.IdPerfin);

                perfilNH.Nombre = perfil.Nombre;


                perfilNH.Email = perfil.Email;


                perfilNH.Contrasenya = perfil.Contrasenya;


                perfilNH.Telefono = perfil.Telefono;

                session.Update (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EditarContrasenya (PerfilEN perfil)
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), perfil.IdPerfin);

                perfilNH.Nombre = perfil.Nombre;


                perfilNH.Email = perfil.Email;


                perfilNH.Contrasenya = perfil.Contrasenya;


                perfilNH.Telefono = perfil.Telefono;

                session.Update (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EditarTelefono (PerfilEN perfil)
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), perfil.IdPerfin);

                perfilNH.Nombre = perfil.Nombre;


                perfilNH.Email = perfil.Email;


                perfilNH.Contrasenya = perfil.Contrasenya;


                perfilNH.Telefono = perfil.Telefono;

                session.Update (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public int Crear (PerfilEN perfil)
{
        PerfilNH perfilNH = new PerfilNH (perfil);

        try
        {
                SessionInitializeTransaction ();

                session.Save (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return perfilNH.IdPerfin;
}

public void Modificar (PerfilEN perfil)
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), perfil.IdPerfin);

                perfilNH.Nombre = perfil.Nombre;


                perfilNH.Email = perfil.Email;


                perfilNH.Contrasenya = perfil.Contrasenya;


                perfilNH.Telefono = perfil.Telefono;

                session.Update (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idPerfin
                    )
{
        try
        {
                SessionInitializeTransaction ();
                PerfilNH perfilNH = (PerfilNH)session.Load (typeof(PerfilNH), idPerfin);
                session.Delete (perfilNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PerfilEN
public PerfilEN ReadOID (int idPerfin
                         )
{
        PerfilEN perfilEN = null;

        try
        {
                SessionInitializeTransaction ();
                perfilEN = (PerfilEN)session.Get (typeof(PerfilNH), idPerfin);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return perfilEN;
}

public System.Collections.Generic.IList<PerfilEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PerfilEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PerfilNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PerfilEN>();
                else
                        result = session.CreateCriteria (typeof(PerfilNH)).List<PerfilEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in PerfilRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
