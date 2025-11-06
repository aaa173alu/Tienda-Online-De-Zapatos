
using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IAdministradorRepository administradorrepository;
protected IProductoRepository productorepository;
protected IItemPedidoRepository itempedidorepository;
protected IPedidoRepository pedidorepository;
protected IAjustesRepository ajustesrepository;
protected IValoracionRepository valoracionrepository;
protected IFavoritosRepository favoritosrepository;
protected ISesionRepository sesionrepository;
protected ICategoriaRepository categoriarepository;
protected IPagoRepository pagorepository;
protected IAyudaRepository ayudarepository;
protected IPerfilRepository perfilrepository;
protected ICarritoRepository carritorepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IAdministradorRepository AdministradorRepository {
        get;
}
public abstract IProductoRepository ProductoRepository {
        get;
}
public abstract IItemPedidoRepository ItemPedidoRepository {
        get;
}
public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract IAjustesRepository AjustesRepository {
        get;
}
public abstract IValoracionRepository ValoracionRepository {
        get;
}
public abstract IFavoritosRepository FavoritosRepository {
        get;
}
public abstract ISesionRepository SesionRepository {
        get;
}
public abstract ICategoriaRepository CategoriaRepository {
        get;
}
public abstract IPagoRepository PagoRepository {
        get;
}
public abstract IAyudaRepository AyudaRepository {
        get;
}
public abstract IPerfilRepository PerfilRepository {
        get;
}
public abstract ICarritoRepository CarritoRepository {
        get;
}
}
}
