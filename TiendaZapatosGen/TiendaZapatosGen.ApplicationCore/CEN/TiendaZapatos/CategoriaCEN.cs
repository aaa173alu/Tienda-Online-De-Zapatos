

using System;
using System.Text;
using System.Collections.Generic;

using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;


namespace TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos
{
/*
 *      Definition of the class CategoriaCEN
 *
 */
public partial class CategoriaCEN
{
private ICategoriaRepository _ICategoriaRepository;

public CategoriaCEN(ICategoriaRepository _ICategoriaRepository)
{
        this._ICategoriaRepository = _ICategoriaRepository;
}

public ICategoriaRepository get_ICategoriaRepository ()
{
        return this._ICategoriaRepository;
}

public int Crear (int p_idCategoria, string p_attribute)
{
        CategoriaEN categoriaEN = null;
        int oid;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.IdCategoria = p_idCategoria;

        categoriaEN.Attribute = p_attribute;



        oid = _ICategoriaRepository.Crear (categoriaEN);
        return oid;
}

public void Modificar (int p_Categoria_OID, string p_attribute)
{
        CategoriaEN categoriaEN = null;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.IdCategoria = p_Categoria_OID;
        categoriaEN.Attribute = p_attribute;
        //Call to CategoriaRepository

        _ICategoriaRepository.Modificar (categoriaEN);
}

public void Borrar (int idCategoria
                    )
{
        _ICategoriaRepository.Borrar (idCategoria);
}

public CategoriaEN ReadOID (int idCategoria
                            )
{
        CategoriaEN categoriaEN = null;

        categoriaEN = _ICategoriaRepository.ReadOID (idCategoria);
        return categoriaEN;
}

public System.Collections.Generic.IList<CategoriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> list = null;

        list = _ICategoriaRepository.ReadAll (first, size);
        return list;
}
}
}
