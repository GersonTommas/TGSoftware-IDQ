﻿// <auto-generated />
using System;
using IDQ.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IDQ.EntityFramework.Migrations
{
    [DbContext(typeof(IDQDbContext))]
    partial class IDQDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("IDQ.Domain.Models.abiertoProductosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadAgregado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadSacado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FechaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoAgregadoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoSacadoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FechaID");

                    b.HasIndex("ProductoAgregadoID");

                    b.HasIndex("ProductoSacadoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("abiertoProductos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.cajaConteosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CajaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Detalle")
                        .HasColumnType("TEXT");

                    b.Property<double>("Diferencia")
                        .HasColumnType("REAL");

                    b.Property<bool>("Salida")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CajaID")
                        .IsUnique();

                    b.HasIndex("UsuarioID");

                    b.ToTable("cajaConteos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.cajaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CajaActual")
                        .HasColumnType("REAL");

                    b.Property<int>("FechaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<double>("MercadoPago")
                        .HasColumnType("REAL");

                    b.Property<double>("Vuelto")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FechaID");

                    b.ToTable("caja");
                });

            modelBuilder.Entity("IDQ.Domain.Models.consumoProductoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FechaID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FechaID");

                    b.HasIndex("ProductoID");

                    b.ToTable("consumosProductos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.deudoresModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Detalles")
                        .HasColumnType("TEXT");

                    b.Property<int>("Nivel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<double>("Resto")
                        .HasColumnType("REAL");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioID");

                    b.ToTable("deudores");
                });

            modelBuilder.Entity("IDQ.Domain.Models.fechasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("fechas");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ingresoProductosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngresoID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrecioActual")
                        .HasColumnType("REAL");

                    b.Property<double>("PrecioPagado")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IngresoID");

                    b.HasIndex("ProductoID");

                    b.ToTable("ingresoProductos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ingresosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Detalle")
                        .HasColumnType("TEXT");

                    b.Property<int>("FechaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<double>("PagadoMP")
                        .HasColumnType("REAL");

                    b.Property<double>("PagadoPesos")
                        .HasColumnType("REAL");

                    b.Property<int>("ProveedorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FechaID");

                    b.HasIndex("ProveedorID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("ingresos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.medidasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Medida")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("medidas");
                });

            modelBuilder.Entity("IDQ.Domain.Models.modificadoProductoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FechaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FechaID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("modificadoProductos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.motivoRetirosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Motivo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("retiroMotivos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.productosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FechaModificadoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedidaID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrecioActual")
                        .HasColumnType("REAL");

                    b.Property<double>("PrecioIngreso")
                        .HasColumnType("REAL");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StockInicial")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FechaModificadoID");

                    b.HasIndex("MedidaID");

                    b.HasIndex("TagID");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.proveedoresModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Celular")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Detalles")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroDeCliente")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Telefono")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("proveedores");
                });

            modelBuilder.Entity("IDQ.Domain.Models.retirosCajaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CajaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Detalle")
                        .HasColumnType("TEXT");

                    b.Property<int>("FechaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<int>("MotivoID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Pendiente")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProveedorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioAutorizaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioRetiraID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CajaID");

                    b.HasIndex("FechaID");

                    b.HasIndex("MotivoID");

                    b.HasIndex("ProveedorID");

                    b.HasIndex("UsuarioAutorizaID");

                    b.HasIndex("UsuarioRetiraID");

                    b.ToTable("retiros");
                });

            modelBuilder.Entity("IDQ.Domain.Models.sacadoProductosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FechaPagadoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FechaSacadoID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FechaPagadoID");

                    b.HasIndex("FechaSacadoID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("sacadoProductos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.tagsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Minimo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("IDQ.Domain.Models.usuariosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contraseña")
                        .HasColumnType("TEXT");

                    b.Property<string>("Detalle")
                        .HasColumnType("TEXT");

                    b.Property<string>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("FechaSalida")
                        .HasColumnType("TEXT");

                    b.Property<int>("Nivel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<double>("Resto")
                        .HasColumnType("REAL");

                    b.Property<string>("Usuario")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ventaProductosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadDeuda")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadFaltante")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DeudorID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FechaPagadoID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<double>("PrecioPagado")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VentaID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeudorID");

                    b.HasIndex("FechaPagadoID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("VentaID");

                    b.ToTable("ventaProductos");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ventasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CajaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DeudorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FechaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CajaId")
                        .IsUnique();

                    b.HasIndex("DeudorID");

                    b.HasIndex("FechaID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("ventas");
                });

            modelBuilder.Entity("cajaModelventaProductosModel", b =>
                {
                    b.Property<int>("CajasPerVentaProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VentaProductosPerCajaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CajasPerVentaProductoId", "VentaProductosPerCajaId");

                    b.HasIndex("VentaProductosPerCajaId");

                    b.ToTable("cajaModelventaProductosModel");
                });

            modelBuilder.Entity("IDQ.Domain.Models.abiertoProductosModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.fechasModel", "Fecha")
                        .WithMany("AbiertoProductosPerFecha")
                        .HasForeignKey("FechaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.productosModel", "ProductoAgregado")
                        .WithMany("AbiertoAgregadoPerProducto")
                        .HasForeignKey("ProductoAgregadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.productosModel", "ProductoSacado")
                        .WithMany("AbiertoSacadoPerProducto")
                        .HasForeignKey("ProductoSacadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.usuariosModel", "Usuario")
                        .WithMany("AbiertoProductosPerUsuario")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fecha");

                    b.Navigation("ProductoAgregado");

                    b.Navigation("ProductoSacado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDQ.Domain.Models.cajaConteosModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.cajaModel", "Caja")
                        .WithOne("CajaConteoForCaja")
                        .HasForeignKey("IDQ.Domain.Models.cajaConteosModel", "CajaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.usuariosModel", "Usuario")
                        .WithMany("CajaConteosPerUsuario")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caja");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDQ.Domain.Models.cajaModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.fechasModel", "Fecha")
                        .WithMany("CajasPerFecha")
                        .HasForeignKey("FechaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fecha");
                });

            modelBuilder.Entity("IDQ.Domain.Models.consumoProductoModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.fechasModel", "Fecha")
                        .WithMany("ConsumosProductosPerFecha")
                        .HasForeignKey("FechaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.productosModel", "Producto")
                        .WithMany("ConsumoProductosPerProducto")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fecha");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("IDQ.Domain.Models.deudoresModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.usuariosModel", "Usuario")
                        .WithMany("DeudoresPerUsuario")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ingresoProductosModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.ingresosModel", "Ingreso")
                        .WithMany("IngresoProductosPerIngreso")
                        .HasForeignKey("IngresoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.productosModel", "Producto")
                        .WithMany("IngresoProductosPerProducto")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingreso");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ingresosModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.fechasModel", "Fecha")
                        .WithMany("IngresosPerFecha")
                        .HasForeignKey("FechaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.proveedoresModel", "Proveedor")
                        .WithMany("IngresosPerProveedor")
                        .HasForeignKey("ProveedorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.usuariosModel", "Usuario")
                        .WithMany("IngresosPerUsuario")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fecha");

                    b.Navigation("Proveedor");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDQ.Domain.Models.modificadoProductoModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.fechasModel", "Fecha")
                        .WithMany("ModificadosProductosPerFecha")
                        .HasForeignKey("FechaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.productosModel", "Producto")
                        .WithMany("ModificadoProductosPerProducto")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.usuariosModel", "Usuario")
                        .WithMany("ModificadoProductosPerUsuario")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fecha");

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDQ.Domain.Models.productosModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.fechasModel", "FechaModificado")
                        .WithMany("ProductosModificadosPerFecha")
                        .HasForeignKey("FechaModificadoID");

                    b.HasOne("IDQ.Domain.Models.medidasModel", "Medida")
                        .WithMany("ProductosPerMedida")
                        .HasForeignKey("MedidaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.tagsModel", "Tag")
                        .WithMany("ProductosPerTag")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FechaModificado");

                    b.Navigation("Medida");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("IDQ.Domain.Models.retirosCajaModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.cajaModel", "Caja")
                        .WithMany("RetirosCajaPerCaja")
                        .HasForeignKey("CajaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.fechasModel", "Fecha")
                        .WithMany("RetirosPerFecha")
                        .HasForeignKey("FechaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.motivoRetirosModel", "Motivo")
                        .WithMany("Retiros")
                        .HasForeignKey("MotivoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.proveedoresModel", "Proveedor")
                        .WithMany("RetirosCajaPerProveedor")
                        .HasForeignKey("ProveedorID");

                    b.HasOne("IDQ.Domain.Models.usuariosModel", "UsuarioAutoriza")
                        .WithMany("RetirosAutorizaPerUsuario")
                        .HasForeignKey("UsuarioAutorizaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.usuariosModel", "UsuarioRetira")
                        .WithMany("RetirosRetiraPerUsuario")
                        .HasForeignKey("UsuarioRetiraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caja");

                    b.Navigation("Fecha");

                    b.Navigation("Motivo");

                    b.Navigation("Proveedor");

                    b.Navigation("UsuarioAutoriza");

                    b.Navigation("UsuarioRetira");
                });

            modelBuilder.Entity("IDQ.Domain.Models.sacadoProductosModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.fechasModel", "FechaPagado")
                        .WithMany("SacadoProductosPagadosPerFecha")
                        .HasForeignKey("FechaPagadoID");

                    b.HasOne("IDQ.Domain.Models.fechasModel", "FechaSacado")
                        .WithMany("SacadoProductosSacadosPerFecha")
                        .HasForeignKey("FechaSacadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.productosModel", "Producto")
                        .WithMany("SacadoProductosPerProducto")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.usuariosModel", "Usuario")
                        .WithMany("SacadoProductosPerUsuario")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FechaPagado");

                    b.Navigation("FechaSacado");

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ventaProductosModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.deudoresModel", "Deudor")
                        .WithMany("VentaProductosPerDeudor")
                        .HasForeignKey("DeudorID");

                    b.HasOne("IDQ.Domain.Models.fechasModel", "FechaPagado")
                        .WithMany("VentaProductosPagadosPerFecha")
                        .HasForeignKey("FechaPagadoID");

                    b.HasOne("IDQ.Domain.Models.productosModel", "Producto")
                        .WithMany("VentaProductosPerProducto")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.ventasModel", "Venta")
                        .WithMany("VentaProductosPerVenta")
                        .HasForeignKey("VentaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudor");

                    b.Navigation("FechaPagado");

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ventasModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.cajaModel", "Caja")
                        .WithOne("VentaForCaja")
                        .HasForeignKey("IDQ.Domain.Models.ventasModel", "CajaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.deudoresModel", "Deudor")
                        .WithMany("VentasPerDeudor")
                        .HasForeignKey("DeudorID");

                    b.HasOne("IDQ.Domain.Models.fechasModel", "Fecha")
                        .WithMany("VentasPerFecha")
                        .HasForeignKey("FechaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.usuariosModel", "Usuario")
                        .WithMany("VentasPerUsuario")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caja");

                    b.Navigation("Deudor");

                    b.Navigation("Fecha");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("cajaModelventaProductosModel", b =>
                {
                    b.HasOne("IDQ.Domain.Models.cajaModel", null)
                        .WithMany()
                        .HasForeignKey("CajasPerVentaProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IDQ.Domain.Models.ventaProductosModel", null)
                        .WithMany()
                        .HasForeignKey("VentaProductosPerCajaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IDQ.Domain.Models.cajaModel", b =>
                {
                    b.Navigation("CajaConteoForCaja");

                    b.Navigation("RetirosCajaPerCaja");

                    b.Navigation("VentaForCaja");
                });

            modelBuilder.Entity("IDQ.Domain.Models.deudoresModel", b =>
                {
                    b.Navigation("VentaProductosPerDeudor");

                    b.Navigation("VentasPerDeudor");
                });

            modelBuilder.Entity("IDQ.Domain.Models.fechasModel", b =>
                {
                    b.Navigation("AbiertoProductosPerFecha");

                    b.Navigation("CajasPerFecha");

                    b.Navigation("ConsumosProductosPerFecha");

                    b.Navigation("IngresosPerFecha");

                    b.Navigation("ModificadosProductosPerFecha");

                    b.Navigation("ProductosModificadosPerFecha");

                    b.Navigation("RetirosPerFecha");

                    b.Navigation("SacadoProductosPagadosPerFecha");

                    b.Navigation("SacadoProductosSacadosPerFecha");

                    b.Navigation("VentaProductosPagadosPerFecha");

                    b.Navigation("VentasPerFecha");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ingresosModel", b =>
                {
                    b.Navigation("IngresoProductosPerIngreso");
                });

            modelBuilder.Entity("IDQ.Domain.Models.medidasModel", b =>
                {
                    b.Navigation("ProductosPerMedida");
                });

            modelBuilder.Entity("IDQ.Domain.Models.motivoRetirosModel", b =>
                {
                    b.Navigation("Retiros");
                });

            modelBuilder.Entity("IDQ.Domain.Models.productosModel", b =>
                {
                    b.Navigation("AbiertoAgregadoPerProducto");

                    b.Navigation("AbiertoSacadoPerProducto");

                    b.Navigation("ConsumoProductosPerProducto");

                    b.Navigation("IngresoProductosPerProducto");

                    b.Navigation("ModificadoProductosPerProducto");

                    b.Navigation("SacadoProductosPerProducto");

                    b.Navigation("VentaProductosPerProducto");
                });

            modelBuilder.Entity("IDQ.Domain.Models.proveedoresModel", b =>
                {
                    b.Navigation("IngresosPerProveedor");

                    b.Navigation("RetirosCajaPerProveedor");
                });

            modelBuilder.Entity("IDQ.Domain.Models.tagsModel", b =>
                {
                    b.Navigation("ProductosPerTag");
                });

            modelBuilder.Entity("IDQ.Domain.Models.usuariosModel", b =>
                {
                    b.Navigation("AbiertoProductosPerUsuario");

                    b.Navigation("CajaConteosPerUsuario");

                    b.Navigation("DeudoresPerUsuario");

                    b.Navigation("IngresosPerUsuario");

                    b.Navigation("ModificadoProductosPerUsuario");

                    b.Navigation("RetirosAutorizaPerUsuario");

                    b.Navigation("RetirosRetiraPerUsuario");

                    b.Navigation("SacadoProductosPerUsuario");

                    b.Navigation("VentasPerUsuario");
                });

            modelBuilder.Entity("IDQ.Domain.Models.ventasModel", b =>
                {
                    b.Navigation("VentaProductosPerVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
