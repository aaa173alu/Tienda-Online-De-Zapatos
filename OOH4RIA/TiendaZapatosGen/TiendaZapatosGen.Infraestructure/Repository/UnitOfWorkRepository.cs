

using TiendaZapatosGen.ApplicationCore.IRepository.TiendaZapatos;
using TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos;
using TiendaZapatosGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaZapatosGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IAdministradorRepository AdministradorRepository {
        get
        {
                this.administradorrepository = new AdministradorRepository ();
                this.administradorrepository.setSessionCP (session);
                return this.administradorrepository;
        }
}

public override IProductoRepository ProductoRepository {
        get
        {
                this.productorepository = new ProductoRepository ();
                this.productorepository.setSessionCP (session);
                return this.productorepository;
        }
}

public override IItemPedidoRepository ItemPedidoRepository {
        get
        {
                this.itempedidorepository = new ItemPedidoRepository ();
                this.itempedidorepository.setSessionCP (session);
                return this.itempedidorepository;
        }
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override IAjustesRepository AjustesRepository {
        get
        {
                this.ajustesrepository = new AjustesRepository ();
                this.ajustesrepository.setSessionCP (session);
                return this.ajustesrepository;
        }
}

public override IValoracionRepository ValoracionRepository {
        get
        {
                this.valoracionrepository = new ValoracionRepository ();
                this.valoracionrepository.setSessionCP (session);
                return this.valoracionrepository;
        }
}

public override IFavoritosRepository FavoritosRepository {
        get
        {
                this.favoritosrepository = new FavoritosRepository ();
                this.favoritosrepository.setSessionCP (session);
                return this.favoritosrepository;
        }
}

public override ISesionRepository SesionRepository {
        get
        {
                this.sesionrepository = new SesionRepository ();
                this.sesionrepository.setSessionCP (session);
                return this.sesionrepository;
        }
}

public override ICategoriaRepository CategoriaRepository {
        get
        {
                this.categoriarepository = new CategoriaRepository ();
                this.categoriarepository.setSessionCP (session);
                return this.categoriarepository;
        }
}

public override IPagoRepository PagoRepository {
        get
        {
                this.pagorepository = new PagoRepository ();
                this.pagorepository.setSessionCP (session);
                return this.pagorepository;
        }
}

public override IAyudaRepository AyudaRepository {
        get
        {
                this.ayudarepository = new AyudaRepository ();
                this.ayudarepository.setSessionCP (session);
                return this.ayudarepository;
        }
}

public override IPerfilRepository PerfilRepository {
        get
        {
                this.perfilrepository = new PerfilRepository ();
                this.perfilrepository.setSessionCP (session);
                return this.perfilrepository;
        }
}

public override ICarritoRepository CarritoRepository {
        get
        {
                this.carritorepository = new CarritoRepository ();
                this.carritorepository.setSessionCP (session);
                return this.carritorepository;
        }
}
}
}

