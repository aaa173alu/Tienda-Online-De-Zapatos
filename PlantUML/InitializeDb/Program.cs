using ApplicationCore.Domain.CEN;
using ApplicationCore.Domain.CP;
using ApplicationCore.Domain.EN;
using ApplicationCore.Domain.Enums;
using ApplicationCore.Domain.Repositories;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using Infrastructure.NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;

class Program 
{
    static void Main() 
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     INICIALIZANDO BASE DE DATOS - NHIBERNATE                  ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════╝\n");

        Console.WriteLine("Configurando NHibernate...");
        
        // Crear base de datos si no existe
        try
        {
            using (var conn = new System.Data.SqlClient.SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;"))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ProjectDatabase') CREATE DATABASE ProjectDatabase";
                cmd.ExecuteNonQuery();
                Console.WriteLine("✓ Base de datos creada/verificada\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️  Error creando base de datos: {ex.Message}");
        }
        
        // Actualizar connection string para usar la base de datos
        Environment.SetEnvironmentVariable("NH_CONNECTION", "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjectDatabase;Integrated Security=True;");
        
        // Crear esquema de base de datos
        try
        {
            var cfg = NHibernateHelper.BuildConfiguration();
            var schemaExport = new SchemaExport(cfg);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);
            Console.WriteLine("✓ Esquema de base de datos creado\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️  Error creando esquema: {ex.Message}");
            Console.WriteLine("Continuando con esquema existente...\n");
        }

        // Configurar repositorios NHibernate y Unit of Work
        var uow = new NHibernateUnitOfWork();
        var productoRepo = new NHibernateProductoRepository(uow);
        var pedidoRepo = new NHibernatePedidoRepository(uow);
        var usuarioRepo = new NHibernateRepository<Usuario, long>(uow);
        var carritoRepo = new NHibernateRepository<Carrito, long>(uow);
        var categoriaRepo = new NHibernateRepository<Categoria, long>(uow);
        var valoracionRepo = new NHibernateRepository<Valoracion, long>(uow);
        var favoritosRepo = new NHibernateRepository<Favoritos, long>(uow);

        // Crear CENs
        var productoCEN = new ProductoCEN(productoRepo, uow);
        var pedidoCEN = new PedidoCEN(pedidoRepo, productoRepo, uow);
        var usuarioCEN = new UsuarioCEN(usuarioRepo, uow);
        var carritoCEN = new CarritoCEN(carritoRepo, productoRepo, uow);
        var categoriaCEN = new CategoriaCEN(categoriaRepo, uow);
        var valoracionCEN = new ValoracionCEN(valoracionRepo, uow);
        var favoritosCEN = new FavoritosCEN(favoritosRepo, uow);

        // Crear CPs (Custom Transactions)
        var agregarProductoCP = new AgregarProductoAlCarritoCP(carritoRepo, productoRepo, uow);
        var cancelarPedidoCP = new CancelarPedidoCP(pedidoRepo, productoRepo, uow);
        var procesarDevolucionCP = new ProcesarDevolucionCP(pedidoRepo, productoRepo, uow);
        var finalizarCompraCP = new FinalizarCompraCP(pedidoCEN, productoRepo, uow);

        try
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1. CREANDO CATEGORÍAS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var catDeportivo = categoriaCEN.Crear("Deportivo");
            var catCasual = categoriaCEN.Crear("Casual");
            var catFormal = categoriaCEN.Crear("Formal");
            Console.WriteLine($"✓ Categoría: {catDeportivo.Nombre} (ID: {catDeportivo.Id})");
            Console.WriteLine($"✓ Categoría: {catCasual.Nombre} (ID: {catCasual.Id})");
            Console.WriteLine($"✓ Categoría: {catFormal.Nombre} (ID: {catFormal.Id})");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  2. CREANDO ZAPATOS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var prod1 = productoCEN.Crear("Nike Air Max 2024", 129.99m, 15, true);
            prod1.Descripcion = "Zapatillas deportivas de última generación con tecnología Air";
            prod1.Color = "Negro/Blanco";
            prod1.TallasDisponibles.Add("38");
            prod1.TallasDisponibles.Add("39");
            prod1.TallasDisponibles.Add("40");
            prod1.TallasDisponibles.Add("41");
            prod1.TallasDisponibles.Add("42");
            productoRepo.Modify(prod1);
            
            var prod2 = productoCEN.Crear("Adidas Ultraboost", 159.99m, 12, true);
            prod2.Descripcion = "Zapatillas running con suela Boost para máxima amortiguación";
            prod2.Color = "Azul";
            prod2.TallasDisponibles.Add("39");
            prod2.TallasDisponibles.Add("40");
            prod2.TallasDisponibles.Add("41");
            prod2.TallasDisponibles.Add("42");
            prod2.TallasDisponibles.Add("43");
            productoRepo.Modify(prod2);
            
            var prod3 = productoCEN.Crear("Vans Old Skool", 65.00m, 25, false);
            prod3.Descripcion = "Zapatillas casuales clásicas con diseño atemporal";
            prod3.Color = "Negro";
            prod3.TallasDisponibles.Add("37");
            prod3.TallasDisponibles.Add("38");
            prod3.TallasDisponibles.Add("39");
            prod3.TallasDisponibles.Add("40");
            prod3.TallasDisponibles.Add("41");
            productoRepo.Modify(prod3);
            
            var prod4 = productoCEN.Crear("Clarks Desert Boot", 95.50m, 18, true);
            prod4.Descripcion = "Botas desert de cuero premium, perfectas para look casual elegante";
            prod4.Color = "Marrón";
            prod4.TallasDisponibles.Add("40");
            prod4.TallasDisponibles.Add("41");
            prod4.TallasDisponibles.Add("42");
            prod4.TallasDisponibles.Add("43");
            prod4.TallasDisponibles.Add("44");
            productoRepo.Modify(prod4);
            
            var prod5 = productoCEN.Crear("Converse Chuck Taylor", 55.00m, 30, false);
            prod5.Descripcion = "Zapatillas icónicas de lona, estilo urbano casual";
            prod5.Color = "Rojo";
            prod5.TallasDisponibles.Add("36");
            prod5.TallasDisponibles.Add("37");
            prod5.TallasDisponibles.Add("38");
            prod5.TallasDisponibles.Add("39");
            prod5.TallasDisponibles.Add("40");
            prod5.TallasDisponibles.Add("41");
            productoRepo.Modify(prod5);
            
            uow.SaveChanges();
            
            Console.WriteLine($"✓ {prod1.Nombre} - ${prod1.Precio} (Color: {prod1.Color}, Tallas: {string.Join(", ", prod1.TallasDisponibles)}, Destacado: ⭐)");
            Console.WriteLine($"✓ {prod2.Nombre} - ${prod2.Precio} (Color: {prod2.Color}, Tallas: {string.Join(", ", prod2.TallasDisponibles)}, Destacado: ⭐)");
            Console.WriteLine($"✓ {prod3.Nombre} - ${prod3.Precio} (Color: {prod3.Color}, Tallas: {string.Join(", ", prod3.TallasDisponibles)})");
            Console.WriteLine($"✓ {prod4.Nombre} - ${prod4.Precio} (Color: {prod4.Color}, Tallas: {string.Join(", ", prod4.TallasDisponibles)}, Destacado: ⭐)");
            Console.WriteLine($"✓ {prod5.Nombre} - ${prod5.Precio} (Color: {prod5.Color}, Tallas: {string.Join(", ", prod5.TallasDisponibles)})");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  3. REGISTRANDO USUARIOS + LOGIN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var usuario1 = usuarioCEN.Registrar("Juan Pérez", "juan@example.com", "password123");
            var usuario2 = usuarioCEN.Registrar("María García", "maria@example.com", "maria456");
            var usuario3 = usuarioCEN.Registrar("Carlos López", "carlos@example.com", "carlos789");
            Console.WriteLine($"✓ Usuario: {usuario1.Nombre} ({usuario1.Email})");
            Console.WriteLine($"✓ Usuario: {usuario2.Nombre} ({usuario2.Email})");
            Console.WriteLine($"✓ Usuario: {usuario3.Nombre} ({usuario3.Email})");
            
            var usuarioLogueado = usuarioCEN.Login("juan@example.com", "password123");
            Console.WriteLine($"\n✓ LOGIN EXITOSO: {usuarioLogueado.Nombre}");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  4. PROBANDO FILTROS (ReadFilter)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var productosDestacados = productoCEN.ReadFilter(destacado: true);
            Console.WriteLine($"✓ Zapatos destacados: {productosDestacados.Count}");
            foreach (var p in productosDestacados)
                Console.WriteLine($"  - {p.Nombre} (${p.Precio})");

            var zapatosPorPrecio = productoCEN.ReadFilter(precioMin: 50m, precioMax: 100m);
            Console.WriteLine($"\n✓ Zapatos entre $50 y $100: {zapatosPorPrecio.Count}");
            foreach (var p in zapatosPorPrecio)
                Console.WriteLine($"  - {p.Nombre}: ${p.Precio}");
                
            var zapatosBaratos = productoCEN.ReadFilter(precioMax: 70m);
            Console.WriteLine($"\n✓ Zapatos económicos (menos de $70): {zapatosBaratos.Count}");
            foreach (var p in zapatosBaratos)
                Console.WriteLine($"  - {p.Nombre}: ${p.Precio}");
            
            var zapatosNegros = productoCEN.ReadFilter(color: "Negro");
            Console.WriteLine($"\n✓ Zapatos negros: {zapatosNegros.Count}");
            foreach (var p in zapatosNegros)
                Console.WriteLine($"  - {p.Nombre} (Color: {p.Color})");
            
            var zapatosConBlanco = productoCEN.ReadFilter(color: "Blanco");
            Console.WriteLine($"\n✓ Zapatos con blanco: {zapatosConBlanco.Count}");
            foreach (var p in zapatosConBlanco)
                Console.WriteLine($"  - {p.Nombre} (Color: {p.Color})");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  5. CREANDO CARRITO Y AGREGANDO ZAPATOS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var carrito1 = carritoCEN.Crear(usuario1.Id);
            Console.WriteLine($"✓ Carrito creado para {usuario1.Nombre}");

            agregarProductoCP.Ejecutar(carrito1.Id, prod1.Id, 2);
            Console.WriteLine($"✓ Agregados 2x {prod1.Nombre} al carrito");
            
            agregarProductoCP.Ejecutar(carrito1.Id, prod2.Id, 3);
            Console.WriteLine($"✓ Agregados 3x {prod2.Nombre} al carrito");
            
            var totalCarrito = carritoCEN.CalcularTotal(carrito1.Id);
            Console.WriteLine($"\n✓ Total del carrito: ${totalCarrito:F2}");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  6. FINALIZANDO COMPRA (CustomTransaction)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var itemsCompra = new List<ItemPedido>
            {
                new ItemPedido { ProductoId = prod1.Id, Cantidad = 2 },
                new ItemPedido { ProductoId = prod2.Id, Cantidad = 3 }
            };
            var pedido1 = finalizarCompraCP.Execute(usuario1.Id, "Calle Principal 123", itemsCompra);
            Console.WriteLine($"✓ Pedido #{pedido1.Id} creado");
            Console.WriteLine($"  Estado: {pedido1.Estado}");
            Console.WriteLine($"  Total: ${pedido1.Total:F2}");
            Console.WriteLine($"  Items: {pedido1.Items.Count}");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  7. CREANDO VALORACIONES");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var val1 = valoracionCEN.Crear(usuario1.Id, prod1.Id, 5, "Excelente laptop");
            var val2 = valoracionCEN.Crear(usuario2.Id, prod1.Id, 4, "Muy buena calidad");
            var val3 = valoracionCEN.Crear(usuario3.Id, prod2.Id, 5, "Perfecto mouse");
            Console.WriteLine($"✓ Valoración de {usuario1.Nombre}: {val1.Valor}⭐");
            Console.WriteLine($"✓ Valoración de {usuario2.Nombre}: {val2.Valor}⭐");
            Console.WriteLine($"✓ Valoración de {usuario3.Nombre}: {val3.Valor}⭐");
            
            var promedio = valoracionCEN.CalcularPromedioProducto(prod1.Id);
            Console.WriteLine($"\n✓ Promedio de {prod1.Nombre}: {promedio:F2}⭐");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  8. AGREGANDO FAVORITOS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var fav1 = favoritosCEN.Crear(usuario1.Id, prod3.Id);
            var fav2 = favoritosCEN.Crear(usuario1.Id, prod4.Id);
            var fav3 = favoritosCEN.Crear(usuario2.Id, prod1.Id);
            Console.WriteLine($"✓ {usuario1.Nombre} agregó {prod3.Nombre} a favoritos");
            Console.WriteLine($"✓ {usuario1.Nombre} agregó {prod4.Nombre} a favoritos");
            Console.WriteLine($"✓ {usuario2.Nombre} agregó {prod1.Nombre} a favoritos");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  9. CANCELANDO PEDIDO (CustomTransaction)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            var carrito2 = carritoCEN.Crear(usuario2.Id);
            agregarProductoCP.Ejecutar(carrito2.Id, prod4.Id, 2);
            var itemsPedido2 = new List<ItemPedido> { new ItemPedido { ProductoId = prod4.Id, Cantidad = 2 } };
            var pedido2 = finalizarCompraCP.Execute(usuario2.Id, "Avenida Libertad 456", itemsPedido2);
            Console.WriteLine($"✓ Pedido #{pedido2.Id} creado (2x {prod4.Nombre})");
            
            var stockAntes = productoRepo.GetById(prod4.Id).Stock;
            Console.WriteLine($"  Stock de {prod4.Nombre} ANTES: {stockAntes}");
            
            cancelarPedidoCP.Ejecutar(pedido2.Id);
            var stockDespues = productoRepo.GetById(prod4.Id).Stock;
            Console.WriteLine($"\n✓ Pedido #{pedido2.Id} CANCELADO");
            Console.WriteLine($"  Stock de {prod4.Nombre} DESPUÉS: {stockDespues}");
            Console.WriteLine($"  Stock restaurado: +{stockDespues - stockAntes} unidades");

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  10. PROCESANDO DEVOLUCIÓN (CustomTransaction)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            pedidoCEN.CambiarEstado(pedido1.Id, EstadoPedido.recibido);
            Console.WriteLine($"✓ Pedido #{pedido1.Id} marcado como RECIBIDO");
            
            var stockAntesDev = productoRepo.GetById(prod1.Id).Stock;
            Console.WriteLine($"  Stock de {prod1.Nombre} ANTES: {stockAntesDev}");
            
            procesarDevolucionCP.Ejecutar(pedido1.Id, prod1.Id, 1, "Producto con defecto");
            var stockDespuesDev = productoRepo.GetById(prod1.Id).Stock;
            Console.WriteLine($"\n✓ DEVOLUCIÓN PROCESADA");
            Console.WriteLine($"  Stock de {prod1.Nombre} DESPUÉS: {stockDespuesDev}");
            Console.WriteLine($"  Stock restaurado: +{stockDespuesDev - stockAntesDev} unidad");

            Console.WriteLine("\n╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    RESUMEN FINAL                               ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"  Usuarios:     {usuarioCEN.ReadAll().Count}");
            Console.WriteLine($"  Productos:    {productoCEN.ListarTodos().Count}");
            Console.WriteLine($"  Categorías:   {categoriaCEN.ReadAll().Count}");
            Console.WriteLine($"  Pedidos:      {pedidoCEN.ReadAll().Count}");
            Console.WriteLine($"  Valoraciones: {valoracionCEN.ReadAll().Count}");
            Console.WriteLine($"  Favoritos:    {favoritosCEN.ReadAll().Count}");

            Console.WriteLine("\n╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     ✅ BASE DE DATOS INICIALIZADA EXITOSAMENTE                 ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n✅ Implementación completa del backend:");
            Console.WriteLine("  • CRUD: 7 entidades completas");
            Console.WriteLine("  • Login: Implementado y probado");
            Console.WriteLine("  • ReadFilter: 7 filtros implementados");
            Console.WriteLine("  • Custom Operations: 24+ operaciones");
            Console.WriteLine("  • CustomTransactions: 4 CPs transaccionales");
            Console.WriteLine("  • Base de datos: NHibernate + SQL Server LocalDB");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ ERROR: {ex.Message}");
            Console.WriteLine($"\nStack trace:\n{ex.StackTrace}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"\nInner Exception: {ex.InnerException.Message}");
            }
        }
        finally
        {
            // Cerrar sesión de NHibernate
            if (uow.Session != null && uow.Session.IsOpen)
            {
                uow.Session.Close();
            }
        }

        Console.WriteLine("\n\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
