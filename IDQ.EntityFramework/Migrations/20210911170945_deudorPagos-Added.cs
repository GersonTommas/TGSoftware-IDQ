using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class deudorPagosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventas_caja_CajaId",
                table: "ventas");

            migrationBuilder.AlterColumn<int>(
                name: "CajaId",
                table: "ventas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "deudorPagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaID = table.Column<int>(type: "INTEGER", nullable: false),
                    DeudorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CajaID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deudorPagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deudorPagos_caja_CajaID",
                        column: x => x.CajaID,
                        principalTable: "caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deudorPagos_deudores_DeudorID",
                        column: x => x.DeudorID,
                        principalTable: "deudores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deudorPagos_fechas_FechaID",
                        column: x => x.FechaID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deudorPagoModelventaModel",
                columns: table => new
                {
                    DeudaorPagosPerVentaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VentaPerDeudorPagoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deudorPagoModelventaModel", x => new { x.DeudaorPagosPerVentaId, x.VentaPerDeudorPagoId });
                    table.ForeignKey(
                        name: "FK_deudorPagoModelventaModel_deudorPagos_DeudaorPagosPerVentaId",
                        column: x => x.DeudaorPagosPerVentaId,
                        principalTable: "deudorPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deudorPagoModelventaModel_ventas_VentaPerDeudorPagoId",
                        column: x => x.VentaPerDeudorPagoId,
                        principalTable: "ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deudorPagoModelventaProductoModel",
                columns: table => new
                {
                    VentaProductosPerDeudorPagoId = table.Column<int>(type: "INTEGER", nullable: false),
                    deudorPagosPerVentaProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deudorPagoModelventaProductoModel", x => new { x.VentaProductosPerDeudorPagoId, x.deudorPagosPerVentaProductoId });
                    table.ForeignKey(
                        name: "FK_deudorPagoModelventaProductoModel_deudorPagos_deudorPagosPerVentaProductoId",
                        column: x => x.deudorPagosPerVentaProductoId,
                        principalTable: "deudorPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deudorPagoModelventaProductoModel_ventaProductos_VentaProductosPerDeudorPagoId",
                        column: x => x.VentaProductosPerDeudorPagoId,
                        principalTable: "ventaProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deudorPagoModelventaModel_VentaPerDeudorPagoId",
                table: "deudorPagoModelventaModel",
                column: "VentaPerDeudorPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_deudorPagoModelventaProductoModel_deudorPagosPerVentaProductoId",
                table: "deudorPagoModelventaProductoModel",
                column: "deudorPagosPerVentaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_deudorPagos_CajaID",
                table: "deudorPagos",
                column: "CajaID");

            migrationBuilder.CreateIndex(
                name: "IX_deudorPagos_DeudorID",
                table: "deudorPagos",
                column: "DeudorID");

            migrationBuilder.CreateIndex(
                name: "IX_deudorPagos_FechaID",
                table: "deudorPagos",
                column: "FechaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_caja_CajaId",
                table: "ventas",
                column: "CajaId",
                principalTable: "caja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventas_caja_CajaId",
                table: "ventas");

            migrationBuilder.DropTable(
                name: "deudorPagoModelventaModel");

            migrationBuilder.DropTable(
                name: "deudorPagoModelventaProductoModel");

            migrationBuilder.DropTable(
                name: "deudorPagos");

            migrationBuilder.AlterColumn<int>(
                name: "CajaId",
                table: "ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_caja_CajaId",
                table: "ventas",
                column: "CajaId",
                principalTable: "caja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
