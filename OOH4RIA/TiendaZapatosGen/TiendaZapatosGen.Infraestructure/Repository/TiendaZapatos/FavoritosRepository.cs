
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
 * Clase Favoritos:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class FavoritosRepository : BasicRepository, IFavoritosRepository
{
public FavoritosRepository() : base ()
{
}


public FavoritosRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FavoritosEN ReadOIDDefault (int idFavoritos
                                   )
{
        FavoritosEN favoritosEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Get (typeof(FavoritosNH), idFavoritos);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritosEN;
}

public System.Collections.Generic.IList<FavoritosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritosNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritosEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritosNH)).List<FavoritosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FavoritosEN favoritos)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritosNH favoritosNH = (FavoritosNH)session.Load (typeof(FavoritosNH), favoritos.IdFavoritos);

                favoritosNH.FechaCreacion = favoritos.FechaCreacion;


                session.Update (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int AgregarAFavoritos (FavoritosEN favoritos)
{
        FavoritosNH favoritosNH = new FavoritosNH (favoritos);

        try
        {
                SessionInitializeTransaction ();

                session.Save (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritosNH.IdFavoritos;
}

public void EliminarFavoritos (int idFavoritos
                               )
{
        try
        {
                SessionInitializeTransaction ();
                FavoritosNH favoritosNH = (FavoritosNH)session.Load (typeof(FavoritosNH), idFavoritos);
                session.Delete (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void VaciarFavoritos (int idFavoritos
                             )
{
        try
        {
                SessionInitializeTransaction ();
                FavoritosNH favoritosNH = (FavoritosNH)session.Load (typeof(FavoritosNH), idFavoritos);
                session.Delete (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int Crear (FavoritosEN favoritos)
{
        FavoritosNH favoritosNH = new FavoritosNH (favoritos);

        try
        {
                SessionInitializeTransaction ();

                session.Save (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritosNH.IdFavoritos;
}

public void Modificar (FavoritosEN favoritos)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritosNH favoritosNH = (FavoritosNH)session.Load (typeof(FavoritosNH), favoritos.IdFavoritos);

                favoritosNH.FechaCreacion = favoritos.FechaCreacion;

                session.Update (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idFavoritos
                    )
{
        try
        {
                SessionInitializeTransaction ();
                FavoritosNH favoritosNH = (FavoritosNH)session.Load (typeof(FavoritosNH), idFavoritos);
                session.Delete (favoritosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: FavoritosEN
public FavoritosEN ReadOID (int idFavoritos
                            )
{
        FavoritosEN favoritosEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritosEN = (FavoritosEN)session.Get (typeof(FavoritosNH), idFavoritos);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritosEN;
}

public System.Collections.Generic.IList<FavoritosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritosNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritosEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritosNH)).List<FavoritosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
