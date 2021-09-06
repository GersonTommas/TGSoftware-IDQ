using IDQ.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.EntityFramework
{

    public class IDQDbContext : DbContext
    {
        public IDQDbContext(DbContextOptions options) : base(options) { }

        public DbSet<abiertoProductoModel> abiertoProductos { get; set; }
        public DbSet<cajaConteoModel> cajaConteos { get; set; }
        public DbSet<cajaModel> caja { get; set; }
        public DbSet<consumoProductoModel> consumosProductos { get; set; }
        public DbSet<deudorModel> deudores { get; set; }
        public DbSet<fechaModel> fechas { get; set; }
        public DbSet<ingresoProductoModel> ingresoProductos { get; set; }
        public DbSet<ingresoModel> ingresos { get; set; }
        //public DbSet<jornadaModel> jornadas { get; set; }
        public DbSet<medidaModel> medidas { get; set; }
        public DbSet<modificadoProductoModel> modificadoProductos { get; set; }
        public DbSet<motivoRetiroModel> retiroMotivos { get; set; }
        public DbSet<productoModel> productos { get; set; }
        public DbSet<proveedorModel> proveedores { get; set; }
        //public DbSet<puestoModel> puestos { get; set; }
        public DbSet<retiroCajaModel> retiros { get; set; }
        public DbSet<sacadoProductoModel> sacadoProductos { get; set; }
        public DbSet<tagModel> tags { get; set; }
        public DbSet<usuarioModel> usuarios { get; set; }
        public DbSet<ventaProductoModel> ventaProductos { get; set; }
        public DbSet<ventaModel> ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class context
    {
        public static IDQDbContext globalDb = new IDQDbContextFactory().CreateDbContext();
        public static cajaModel globalCajaActual;


        public static void InitializeDatabase()
        {
            IDQDbContextFactory _contextFactory;
            _contextFactory = new IDQDbContextFactory();

            globalDb = _contextFactory.CreateDbContext();

            globalDb.abiertoProductos.LoadAsync();
            globalDb.caja.LoadAsync();
            globalDb.cajaConteos.LoadAsync();
            globalDb.consumosProductos.LoadAsync();
            globalDb.deudores.LoadAsync();
            globalDb.fechas.LoadAsync();
            globalDb.ingresos.LoadAsync();
            globalDb.ingresoProductos.LoadAsync();
            globalDb.medidas.LoadAsync();
            globalDb.modificadoProductos.LoadAsync();
            globalDb.productos.LoadAsync();
            globalDb.proveedores.LoadAsync();
            globalDb.retiros.LoadAsync();
            globalDb.retiroMotivos.LoadAsync();
            globalDb.sacadoProductos.LoadAsync();
            globalDb.tags.LoadAsync();
            globalDb.usuarios.LoadAsync();
            globalDb.ventaProductos.LoadAsync();
            globalDb.ventas.LoadAsync();

            globalCajaActual = globalDb.caja.Local.Single(x => x.Id == 1);
        }
    }
}
