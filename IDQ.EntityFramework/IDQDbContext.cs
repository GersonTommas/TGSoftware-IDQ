using IDQ.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public DbSet<conteoModel> conteos { get; set; }
        public DbSet<deudaModel> deudas { get; set; }
        public DbSet<deudaProductoModel> deudaProductos { get; set; }
        public DbSet<deudorModel> deudores { get; set; }
        public DbSet<deudorPagoModel> deudorPagos { get; set; }
        public DbSet<fechaModel> fechas { get; set; }
        public DbSet<ingresoProductoModel> ingresoProductos { get; set; }
        public DbSet<ingresoModel> ingresos { get; set; }
        //public DbSet<jornadaModel> jornadas { get; set; }
        public DbSet<medidaModel> medidas { get; set; }
        public DbSet<modificadoProductoModel> modificadoProductos { get; set; }
        public DbSet<motivoRetiroModel> retiroMotivos { get; set; }
        public DbSet<productoModel> productos { get; set; }
        public DbSet<proveedorModel> proveedores { get; set; }
        public DbSet<pseudoCajaModel> pseudoCajas { get; set; }
        //public DbSet<puestoModel> puestos { get; set; }
        public DbSet<retiroCajaModel> retiros { get; set; }
        public DbSet<sacadoProductoModel> sacadoProductos { get; set; }
        public DbSet<tagModel> tags { get; set; }
        public DbSet<usuarioModel> usuarios { get; set; }
        public DbSet<ventaProductoModel> ventaProductos { get; set; }
        public DbSet<ventaModel> ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set default precision to decimal property
            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableProperty property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            { property.SetColumnType("decimal(14, 2)"); }

            //_ = modelBuilder.Entity<tagModel>().Property(x => x.fullTag).HasComputedColumnSql("[Tag] + ' ' + [Minimo]", false);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class context
    {
        public static IDQDbContext globalDb = new IDQDbContextFactory().CreateDbContext();
        public static cajaModel globalCajaActual;
        public static ObservableCollection<usuarioModel> globalAllUsuarios;
        public static ObservableCollection<productoModel> globalAllProductos;
        public static ObservableCollection<tagModel> globalAllTags;
        public static ObservableCollection<medidaModel> globalAllMedidas;
        public static ObservableCollection<fechaModel> globalAllFechas;
        public static ObservableCollection<deudorModel> globalAllDeudores;


        public static fechaModel returnFecha(string sentFecha = null)
        {
            if (sentFecha == null)
            {
                try { return globalDb.fechas.Local.Single(x => x.Fecha == DateTime.Today.ToString(@"yyyy/MM/dd")); }
                catch { return new fechaModel() { Fecha = DateTime.Today.ToString(@"yyyy/MM/dd") }; }
            }
            else
            {
                try { return globalDb.fechas.Local.Single(x => x.Fecha == sentFecha); }
                catch { return new fechaModel() { Fecha = sentFecha }; }
            }
        }

        public context()
        {
            /*
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
            globalAllUsuarios = globalDb.usuarios.Local.ToObservableCollection();
            globalAllProductos = globalDb.productos.Local.ToObservableCollection();
            globalAllTags = globalDb.tags.Local.ToObservableCollection();
            globalAllMedidas = globalDb.medidas.Local.ToObservableCollection();
            globalAllFechas = globalDb.fechas.Local.ToObservableCollection();
            globalAllDeudores = globalDb.deudores.Local.ToObservableCollection();
            */
        }

        public static void InitializeDatabase()
        {
            IDQDbContextFactory _contextFactory;
            _contextFactory = new IDQDbContextFactory();

            globalDb = _contextFactory.CreateDbContext();

            globalDb.abiertoProductos.LoadAsync();
            globalDb.caja.LoadAsync();
            globalDb.cajaConteos.LoadAsync();
            globalDb.consumosProductos.LoadAsync();
            globalDb.conteos.LoadAsync();
            globalDb.deudas.LoadAsync();
            globalDb.deudaProductos.LoadAsync();
            globalDb.deudores.LoadAsync();
            globalDb.deudorPagos.LoadAsync();
            globalDb.fechas.LoadAsync();
            globalDb.ingresos.LoadAsync();
            globalDb.ingresoProductos.LoadAsync();
            globalDb.medidas.LoadAsync();
            globalDb.modificadoProductos.LoadAsync();
            globalDb.productos.LoadAsync();
            globalDb.proveedores.LoadAsync();
            globalDb.pseudoCajas.LoadAsync();
            globalDb.retiros.LoadAsync();
            globalDb.retiroMotivos.LoadAsync();
            globalDb.sacadoProductos.LoadAsync();
            globalDb.tags.LoadAsync();
            globalDb.usuarios.LoadAsync();
            globalDb.ventaProductos.LoadAsync();
            globalDb.ventas.LoadAsync();

            globalCajaActual = globalDb.caja.Local.Single(x => x.Id == 1);
            globalAllUsuarios = globalDb.usuarios.Local.ToObservableCollection();
            globalAllProductos = globalDb.productos.Local.ToObservableCollection();
            globalAllTags = globalDb.tags.Local.ToObservableCollection();
            globalAllMedidas = globalDb.medidas.Local.ToObservableCollection();
            globalAllFechas = globalDb.fechas.Local.ToObservableCollection();
            globalAllDeudores = globalDb.deudores.Local.ToObservableCollection();
        }
    }
}
