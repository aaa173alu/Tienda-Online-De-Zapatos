
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
 * Clase ItemPedido:
 *
 */

namespace TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos
{
public partial class ItemPedidoRepository : BasicRepository, IItemPedidoRepository
{
public ItemPedidoRepository() : base ()
{
}


public ItemPedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ItemPedidoEN ReadOIDDefault (int id
                                    )
{
        ItemPedidoEN itemPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                itemPedidoEN = (ItemPedidoEN)session.Get (typeof(ItemPedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return itemPedidoEN;
}

public System.Collections.Generic.IList<ItemPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ItemPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ItemPedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ItemPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(ItemPedidoNH)).List<ItemPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemPedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ItemPedidoEN itemPedido)
{
        try
        {
                SessionInitializeTransaction ();
                ItemPedidoNH itemPedidoNH = (ItemPedidoNH)session.Load (typeof(ItemPedidoNH), itemPedido.Id);

                itemPedidoNH.Cantidad = itemPedido.Cantidad;


                itemPedidoNH.Talla = itemPedido.Talla;




                session.Update (itemPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (ItemPedidoEN itemPedido)
{
        ItemPedidoNH itemPedidoNH = new ItemPedidoNH (itemPedido);

        try
        {
                SessionInitializeTransaction ();
                if (itemPedido.Usuario != null) {
                        // Argumento OID y no colección.
                        itemPedidoNH
                        .Usuario = (TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN)session.Load (typeof(TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos.UsuarioEN), itemPedido.Usuario.Email);

                        itemPedidoNH.Usuario.ItemPedido
                        .Add (itemPedidoNH);
                }

                session.Save (itemPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return itemPedidoNH.Id;
}

public void Modificar (ItemPedidoEN itemPedido)
{
        try
        {
                SessionInitializeTransaction ();
                ItemPedidoNH itemPedidoNH = (ItemPedidoNH)session.Load (typeof(ItemPedidoNH), itemPedido.Id);

                itemPedidoNH.Cantidad = itemPedido.Cantidad;


                itemPedidoNH.Talla = itemPedido.Talla;

                session.Update (itemPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemPedidoRepository.", ex);
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
                ItemPedidoNH itemPedidoNH = (ItemPedidoNH)session.Load (typeof(ItemPedidoNH), id);
                session.Delete (itemPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ItemPedidoEN
public ItemPedidoEN ReadOID (int id
                             )
{
        ItemPedidoEN itemPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                itemPedidoEN = (ItemPedidoEN)session.Get (typeof(ItemPedidoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return itemPedidoEN;
}

public System.Collections.Generic.IList<ItemPedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ItemPedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ItemPedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ItemPedidoEN>();
                else
                        result = session.CreateCriteria (typeof(ItemPedidoNH)).List<ItemPedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TiendaZapatosGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TiendaZapatosGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
