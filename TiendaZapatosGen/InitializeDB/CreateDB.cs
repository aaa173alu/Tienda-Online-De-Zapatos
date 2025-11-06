/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TiendaZapatosGen.ApplicationCore.EN.TiendaZapatos;
using TiendaZapatosGen.ApplicationCore.CEN.TiendaZapatos;
using TiendaZapatosGen.Infraestructure.Repository.TiendaZapatos;
using TiendaZapatosGen.Infraestructure.CP;
using TiendaZapatosGen.ApplicationCore.Exceptions;

using TiendaZapatosGen.ApplicationCore.CP.TiendaZapatos;
using TiendaZapatosGen.Infraestructure.Repository;
/*PROTECTED REGION END*/

namespace InitializeDB
{
    public class CreateDB
    {
        public static void Create (string databaseArg, string userArg, string passArg)
        {
            String database = databaseArg;
            String user = userArg;
            String pass = passArg;

            // Conex DB
            SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

            // Order T-SQL create user
            String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
                BEGIN
                    CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
                END";

            //Order delete user if exist
            String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";

            //Order create database
            string createBD = "CREATE DATABASE " + database;

            //Order associate user with database
            String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
            SqlCommand cmd = null;

            try
            {
                // Open conex
                cnn.Open ();
                
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open) {
                    cnn.Close ();
                }
            }
        }

        public static void InitializeData ()
        {
            try
            {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                AdministradorRepository administradorrepository = new AdministradorRepository ();
                AdministradorCEN administradorcen = new AdministradorCEN (administradorrepository);
                ProductoRepository productorepository = new ProductoRepository ();
                ProductoCEN productocen = new ProductoCEN (productorepository);
                ItemPedidoRepository itempedidorepository = new ItemPedidoRepository ();
                ItemPedidoCEN itempedidocen = new ItemPedidoCEN (itempedidorepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                AjustesRepository ajustesrepository = new AjustesRepository ();
                AjustesCEN ajustescen = new AjustesCEN (ajustesrepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository ();
                ValoracionCEN valoracioncen = new ValoracionCEN (valoracionrepository);
                FavoritosRepository favoritosrepository = new FavoritosRepository ();
                FavoritosCEN favoritoscen = new FavoritosCEN (favoritosrepository);
                SesionRepository sesionrepository = new SesionRepository ();
                SesionCEN sesioncen = new SesionCEN (sesionrepository);
                CategoriaRepository categoriarepository = new CategoriaRepository ();
                CategoriaCEN categoriacen = new CategoriaCEN (categoriarepository);
                PagoRepository pagorepository = new PagoRepository ();
                PagoCEN pagocen = new PagoCEN (pagorepository);
                AyudaRepository ayudarepository = new AyudaRepository ();
                AyudaCEN ayudacen = new AyudaCEN (ayudarepository);
                PerfilRepository perfilrepository = new PerfilRepository ();
                PerfilCEN perfilcen = new PerfilCEN (perfilrepository);
                CarritoRepository carritorepository = new CarritoRepository ();
                CarritoCEN carritocen = new CarritoCEN (carritorepository);

                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                // 1. CREAR CATEGORÍAS
                int idNike = categoriacen.Crear("NIKE", "Deportivas Nike");
                int idAdidas = categoriacen.Crear("ADIDAS", "Deportivas Adidas");

                // 2. CREAR PRODUCTOS
                int idProd1 = productocen.Crear("Nike Air Max", 120.0, "airmax.jpg", "Zapatillas running", 10, idNike);
                int idProd2 = productocen.Crear("Adidas Campus", 65.0, "campus.jpg", "Clásicas", 5, idAdidas);
                int idProd3 = productocen.Crear("Nike OldSchool", 40.0, "old.jpg", "Retro", 15, idNike);

                // 3. PROBAR FILTRO CUSTOM: DameEconomico (precio < 70)
                var baratos = productorepository.DameEconomico();
                Console.WriteLine("=== Productos Económicos (<70€) ===");
                foreach (var p in baratos)
                    Console.WriteLine($"{p.Nombre} - {p.Precio}");

                // 4. CREAR USUARIO
                int idUser = usuariocen.Crear("pepe", "pepe@mail.com", "1234");

                // 5. PROBAR CUSTOM TRANSACTION DEL CP (Añadir producto al carrito)
                CarritoCP carritoCP = new CarritoCP();
                Console.WriteLine("Añadiendo productos a carrito con transacción...");
                carritoCP.AñadirProducto(idUser, idProd1, 1);
                carritoCP.AñadirProducto(idUser, idProd3, 2);

                Console.WriteLine("Transacción completada");

                // 6. MOSTRAR PRODUCTOS DEL CARRITO
                var carritoUser = carritorepository.GetCarritoDeUsuario(idUser);
                Console.WriteLine("=== Carrito del usuario ===");
                foreach (var item in carritoUser.Items)
                    Console.WriteLine(item.Producto.Nombre + " x" + item.Cantidad);

                // 7. OTRO FILTRO: productos por categoría
                var nike = productorepository.DamePorCategoria(idNike);
                Console.WriteLine("=== Productos Nike ===");
                foreach (var p in nike)
                    Console.WriteLine(p.Nombre);

                /*PROTECTED REGION END*/
            }
            catch (Exception ex)
            {
                System.Console.WriteLine (ex.InnerException);
                throw;
            }
        }
    }
}
