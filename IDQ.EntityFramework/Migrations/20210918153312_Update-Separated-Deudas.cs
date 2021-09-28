using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class UpdateSeparatedDeudas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeudorForCajaId",
                table: "caja",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "deudas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalPagado = table.Column<double>(type: "REAL", nullable: false),
                    Hora = table.Column<string>(type: "TEXT", nullable: true),
                    FechaSacadoID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaPagadoID = table.Column<int>(type: "INTEGER", nullable: true),
                    DeudorID = table.Column<int>(type: "INTEGER", nullable: false),
                    VentaID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deudas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deudas_deudores_DeudorID",
                        column: x => x.DeudorID,
                        principalTable: "deudores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deudas_fechas_FechaPagadoID",
                        column: x => x.FechaPagadoID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_deudas_fechas_FechaSacadoID",
                        column: x => x.FechaSacadoID,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deudas_ventas_VentaID",
                        column: x => x.VentaID,
                        principalTable: "ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deudaProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CantidadAdeudada = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadFaltante = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    PrecioPagado = table.Column<double>(type: "REAL", nullable: false),
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false),
                    DeudaID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deudaProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deudaProductos_deudas_DeudaID",
                        column: x => x.DeudaID,
                        principalTable: "deudas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deudaProductos_productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_caja_DeudorForCajaId",
                table: "caja",
                column: "DeudorForCajaId");

            migrationBuilder.CreateIndex(
                name: "IX_deudaProductos_DeudaID",
                table: "deudaProductos",
                column: "DeudaID");

            migrationBuilder.CreateIndex(
                name: "IX_deudaProductos_ProductoID",
                table: "deudaProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_deudas_DeudorID",
                table: "deudas",
                column: "DeudorID");

            migrationBuilder.CreateIndex(
                name: "IX_deudas_FechaPagadoID",
                table: "deudas",
                column: "FechaPagadoID");

            migrationBuilder.CreateIndex(
                name: "IX_deudas_FechaSacadoID",
                table: "deudas",
                column: "FechaSacadoID");

            migrationBuilder.CreateIndex(
                name: "IX_deudas_VentaID",
                table: "deudas",
                column: "VentaID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_caja_deudores_DeudorForCajaId",
                table: "caja",
                column: "DeudorForCajaId",
                principalTable: "deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_caja_deudores_DeudorForCajaId",
                table: "caja");

            migrationBuilder.DropTable(
                name: "deudaProductos");

            migrationBuilder.DropTable(
                name: "deudas");

            migrationBuilder.DropIndex(
                name: "IX_caja_DeudorForCajaId",
                table: "caja");

            migrationBuilder.DropColumn(
                name: "DeudorForCajaId",
                table: "caja");
        }
    }
}
