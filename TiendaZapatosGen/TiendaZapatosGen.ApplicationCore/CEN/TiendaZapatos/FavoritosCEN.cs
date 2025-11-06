

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class FavoritosCEN
 *
 */
public partial class FavoritosCEN
{
private IFavoritosRepository _IFavoritosRepository;

public FavoritosCEN(IFavoritosRepository _IFavoritosRepository)
{
        this._IFavoritosRepository = _IFavoritosRepository;
}

public IFavoritosRepository get_IFavoritosRepository ()
{
        return this._IFavoritosRepository;
}

public int AgregarAFavoritos (int p_idFavoritos, Nullable<DateTime> p_fechaCreacion)
{
        FavoritosEN favoritosEN = null;
        int oid;

        //Initialized FavoritosEN
        favoritosEN = new FavoritosEN ();
        favoritosEN.IdFavoritos = p_idFavoritos;

        favoritosEN.FechaCreacion = p_fechaCreacion;



        oid = _IFavoritosRepository.AgregarAFavoritos (favoritosEN);
        return oid;
}

public void EliminarFavoritos (int idFavoritos
                               )
{
        _IFavoritosRepository.EliminarFavoritos (idFavoritos);
}

public void VaciarFavoritos (int idFavoritos
                             )
{
        _IFavoritosRepository.VaciarFavoritos (idFavoritos);
}

public int Crear (int p_idFavoritos, Nullable<DateTime> p_fechaCreacion)
{
        FavoritosEN favoritosEN = null;
        int oid;

        //Initialized FavoritosEN
        favoritosEN = new FavoritosEN ();
        favoritosEN.IdFavoritos = p_idFavoritos;

        favoritosEN.FechaCreacion = p_fechaCreacion;



        oid = _IFavoritosRepository.Crear (favoritosEN);
        return oid;
}

public void Modificar (int p_Favoritos_OID, Nullable<DateTime> p_fechaCreacion)
{
        FavoritosEN favoritosEN = null;

        //Initialized FavoritosEN
        favoritosEN = new FavoritosEN ();
        favoritosEN.IdFavoritos = p_Favoritos_OID;
        favoritosEN.FechaCreacion = p_fechaCreacion;
        //Call to FavoritosRepository

        _IFavoritosRepository.Modificar (favoritosEN);
}

public void Borrar (int idFavoritos
                    )
{
        _IFavoritosRepository.Borrar (idFavoritos);
}

public FavoritosEN ReadOID (int idFavoritos
                            )
{
        FavoritosEN favoritosEN = null;

        favoritosEN = _IFavoritosRepository.ReadOID (idFavoritos);
        return favoritosEN;
}

public System.Collections.Generic.IList<FavoritosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<FavoritosEN> list = null;

        list = _IFavoritosRepository.ReadAll (first, size);
        return list;
}
}
}
