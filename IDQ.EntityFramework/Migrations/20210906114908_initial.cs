using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.CreateTable(
                name: "fechas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fechas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Medida = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroDeCliente = table.Column<string>(type: "TEXT", nullable: true),
                    Detalles = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<int>(type: "INTEGER", nullable: true),
                    Celular = table.Column<int>(type: "INTEGER", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "retiroMotivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Motivo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retiroMotivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Minimo = table.Column<int>(type: "INTEGER", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false),
                    Resto = table.Column<double>(type: "REAL", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: true),
                    Usuario = table.Column<string>(type: "TEXT", nullable: true),
                    Detalle = table.Column<string>(type: "TEXT", nullable: true),
                    Contraseña = table.Column<string>(type: "TEXT", nullable: true),
                    FechaIngreso = table.Column<string>(type: "TEXT", nullable: true),
                    FechaSalida = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "caja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CajaActual = table.Column<double>(type: "REAL", nullable: false),
                    MercadoPago = table.Column<double>(type: "REAL", nullable: false),
                    Vuelto = table.Column<double>(type: "REAL", nullable: false),
                    Hora = table.Column<string>(type: "TEXT", nullable: true),
                    FechaID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_caja_fechas_FechaID",
                        column: x => x.FechaID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StockInicial = table.Column<int>(type: "INTEGER", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioIngreso = table.Column<double>(type: "REAL", nullable: false),
                    PrecioActual = table.Column<double>(type: "REAL", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaModificadoID = table.Column<int>(type: "INTEGER", nullable: true),
                    TagID = table.Column<int>(type: "INTEGER", nullable: false),
                    MedidaID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_fechas_FechaModificadoID",
                        column: x => x.FechaModificadoID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productos_medidas_MedidaID",
                        column: x => x.MedidaID,
                        principalTable: "medidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_tags_TagID",
                        column: x => x.TagID,
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deudores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false),
                    Resto = table.Column<double>(type: "REAL", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Detalles = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deudores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deudores_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PagadoPesos = table.Column<double>(type: "REAL", nullable: false),
                    PagadoMP = table.Column<double>(type: "REAL", nullable: false),
                    Hora = table.Column<string>(type: "TEXT", nullable: true),
                    Detalle = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProveedorID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingresos_fechas_FechaID",
                        column: x => x.FechaID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingresos_proveedores_ProveedorID",
                        column: x => x.ProveedorID,
                        principalTable: "proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingresos_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cajaConteos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Diferencia = table.Column<double>(type: "REAL", nullable: false),
                    Detalle = table.Column<string>(type: "TEXT", nullable: true),
                    Abierto = table.Column<bool>(type: "INTEGER", nullable: false),
                    CajaID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cajaConteos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cajaConteos_caja_CajaID",
                        column: x => x.CajaID,
                        principalTable: "caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cajaConteos_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CajaID = table.Column<int>(type: "INTEGER", nullable: false),
                    Hora = table.Column<string>(type: "TEXT", nullable: true),
                    Detalle = table.Column<string>(type: "TEXT", nullable: true),
                    Pendiente = table.Column<bool>(type: "INTEGER", nullable: false),
                    MotivoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProveedorID = table.Column<int>(type: "INTEGER", nullable: true),
                    UsuarioAutorizaID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioRetiraID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_retiros_caja_CajaID",
                        column: x => x.CajaID,
                        principalTable: "caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_retiros_fechas_FechaID",
                        column: x => x.FechaID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_retiros_proveedores_ProveedorID",
                        column: x => x.ProveedorID,
                        principalTable: "proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_retiros_retiroMotivos_MotivoID",
                        column: x => x.MotivoID,
                        principalTable: "retiroMotivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_retiros_usuarios_UsuarioAutorizaID",
                        column: x => x.UsuarioAutorizaID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_retiros_usuarios_UsuarioRetiraID",
                        column: x => x.UsuarioRetiraID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abiertoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CantidadSacado = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadAgregado = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoSacadoID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoAgregadoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abiertoProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_abiertoProductos_fechas_FechaID",
                        column: x => x.FechaID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abiertoProductos_productos_ProductoAgregadoID",
                        column: x => x.ProductoAgregadoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abiertoProductos_productos_ProductoSacadoID",
                        column: x => x.ProductoSacadoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_abiertoProductos_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "consumosProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    FechaID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumosProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_consumosProductos_fechas_FechaID",
                        column: x => x.FechaID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consumosProductos_productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modificadoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modificadoProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modificadoProductos_fechas_FechaID",
                        column: x => x.FechaID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modificadoProductos_productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modificadoProductos_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sacadoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaSacadoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaPagadoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sacadoProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sacadoProductos_fechas_FechaPagadoID",
                        column: x => x.FechaPagadoID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sacadoProductos_fechas_FechaSacadoID",
                        column: x => x.FechaSacadoID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sacadoProductos_productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sacadoProductos_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CajaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Hora = table.Column<string>(type: "TEXT", nullable: true),
                    FechaID = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    DeudorID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ventas_caja_CajaId",
                        column: x => x.CajaId,
                        principalTable: "caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ventas_deudores_DeudorID",
                        column: x => x.DeudorID,
                        principalTable: "deudores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_fechas_FechaID",
                        column: x => x.FechaID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ventas_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingresoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioPagado = table.Column<double>(type: "REAL", nullable: false),
                    PrecioActual = table.Column<double>(type: "REAL", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    IngresoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingresoProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingresoProductos_ingresos_IngresoID",
                        column: x => x.IngresoID,
                        principalTable: "ingresos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingresoProductos_productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ventaProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadDeuda = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadFaltante = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    PrecioPagado = table.Column<double>(type: "REAL", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    VentaID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaPagadoID = table.Column<int>(type: "INTEGER", nullable: true),
                    DeudorID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventaProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ventaProductos_deudores_DeudorID",
                        column: x => x.DeudorID,
                        principalTable: "deudores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventaProductos_fechas_FechaPagadoID",
                        column: x => x.FechaPagadoID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventaProductos_productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ventaProductos_ventas_VentaID",
                        column: x => x.VentaID,
                        principalTable: "ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cajaModelventaProductosModel",
                columns: table => new
                {
                    CajasPerVentaProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    VentaProductosPerCajaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cajaModelventaProductosModel", x => new { x.CajasPerVentaProductoId, x.VentaProductosPerCajaId });
                    table.ForeignKey(
                        name: "FK_cajaModelventaProductosModel_caja_CajasPerVentaProductoId",
                        column: x => x.CajasPerVentaProductoId,
                        principalTable: "caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cajaModelventaProductosModel_ventaProductos_VentaProductosPerCajaId",
                        column: x => x.VentaProductosPerCajaId,
                        principalTable: "ventaProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_abiertoProductos_FechaID",
                table: "abiertoProductos",
                column: "FechaID");

            migrationBuilder.CreateIndex(
                name: "IX_abiertoProductos_ProductoAgregadoID",
                table: "abiertoProductos",
                column: "ProductoAgregadoID");

            migrationBuilder.CreateIndex(
                name: "IX_abiertoProductos_ProductoSacadoID",
                table: "abiertoProductos",
                column: "ProductoSacadoID");

            migrationBuilder.CreateIndex(
                name: "IX_abiertoProductos_UsuarioID",
                table: "abiertoProductos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_caja_FechaID",
                table: "caja",
                column: "FechaID");

            migrationBuilder.CreateIndex(
                name: "IX_cajaConteos_CajaID",
                table: "cajaConteos",
                column: "CajaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cajaConteos_UsuarioID",
                table: "cajaConteos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_cajaModelventaProductosModel_VentaProductosPerCajaId",
                table: "cajaModelventaProductosModel",
                column: "VentaProductosPerCajaId");

            migrationBuilder.CreateIndex(
                name: "IX_consumosProductos_FechaID",
                table: "consumosProductos",
                column: "FechaID");

            migrationBuilder.CreateIndex(
                name: "IX_consumosProductos_ProductoID",
                table: "consumosProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_deudores_UsuarioID",
                table: "deudores",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ingresoProductos_IngresoID",
                table: "ingresoProductos",
                column: "IngresoID");

            migrationBuilder.CreateIndex(
                name: "IX_ingresoProductos_ProductoID",
                table: "ingresoProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ingresos_FechaID",
                table: "ingresos",
                column: "FechaID");

            migrationBuilder.CreateIndex(
                name: "IX_ingresos_ProveedorID",
                table: "ingresos",
                column: "ProveedorID");

            migrationBuilder.CreateIndex(
                name: "IX_ingresos_UsuarioID",
                table: "ingresos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_modificadoProductos_FechaID",
                table: "modificadoProductos",
                column: "FechaID");

            migrationBuilder.CreateIndex(
                name: "IX_modificadoProductos_ProductoID",
                table: "modificadoProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_modificadoProductos_UsuarioID",
                table: "modificadoProductos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_productos_FechaModificadoID",
                table: "productos",
                column: "FechaModificadoID");

            migrationBuilder.CreateIndex(
                name: "IX_productos_MedidaID",
                table: "productos",
                column: "MedidaID");

            migrationBuilder.CreateIndex(
                name: "IX_productos_TagID",
                table: "productos",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_retiros_CajaID",
                table: "retiros",
                column: "CajaID");

            migrationBuilder.CreateIndex(
                name: "IX_retiros_FechaID",
                table: "retiros",
                column: "FechaID");

            migrationBuilder.CreateIndex(
                name: "IX_retiros_MotivoID",
                table: "retiros",
                column: "MotivoID");

            migrationBuilder.CreateIndex(
                name: "IX_retiros_ProveedorID",
                table: "retiros",
                column: "ProveedorID");

            migrationBuilder.CreateIndex(
                name: "IX_retiros_UsuarioAutorizaID",
                table: "retiros",
                column: "UsuarioAutorizaID");

            migrationBuilder.CreateIndex(
                name: "IX_retiros_UsuarioRetiraID",
                table: "retiros",
                column: "UsuarioRetiraID");

            migrationBuilder.CreateIndex(
                name: "IX_sacadoProductos_FechaPagadoID",
                table: "sacadoProductos",
                column: "FechaPagadoID");

            migrationBuilder.CreateIndex(
                name: "IX_sacadoProductos_FechaSacadoID",
                table: "sacadoProductos",
                column: "FechaSacadoID");

            migrationBuilder.CreateIndex(
                name: "IX_sacadoProductos_ProductoID",
                table: "sacadoProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_sacadoProductos_UsuarioID",
                table: "sacadoProductos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ventaProductos_DeudorID",
                table: "ventaProductos",
                column: "DeudorID");

            migrationBuilder.CreateIndex(
                name: "IX_ventaProductos_FechaPagadoID",
                table: "ventaProductos",
                column: "FechaPagadoID");

            migrationBuilder.CreateIndex(
                name: "IX_ventaProductos_ProductoID",
                table: "ventaProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ventaProductos_VentaID",
                table: "ventaProductos",
                column: "VentaID");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_CajaId",
                table: "ventas",
                column: "CajaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventas_DeudorID",
                table: "ventas",
                column: "DeudorID");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_FechaID",
                table: "ventas",
                column: "FechaID");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_UsuarioID",
                table: "ventas",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abiertoProductos");

            migrationBuilder.DropTable(
                name: "cajaConteos");

            migrationBuilder.DropTable(
                name: "cajaModelventaProductosModel");

            migrationBuilder.DropTable(
                name: "consumosProductos");

            migrationBuilder.DropTable(
                name: "ingresoProductos");

            migrationBuilder.DropTable(
                name: "modificadoProductos");

            migrationBuilder.DropTable(
                name: "retiros");

            migrationBuilder.DropTable(
                name: "sacadoProductos");

            migrationBuilder.DropTable(
                name: "ventaProductos");

            migrationBuilder.DropTable(
                name: "ingresos");

            migrationBuilder.DropTable(
                name: "retiroMotivos");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "medidas");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "caja");

            migrationBuilder.DropTable(
                name: "deudores");

            migrationBuilder.DropTable(
                name: "fechas");

            migrationBuilder.DropTable(
                name: "usuarios");
            */
        }
    }
}
