using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class conteosRebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pseudoCajas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Efectivo = table.Column<decimal>(type: "decimal(14, 2)", nullable: false),
                    MercadoPago = table.Column<decimal>(type: "decimal(14, 2)", nullable: false),
                    CajaEfectivo = table.Column<decimal>(type: "decimal(14, 2)", nullable: false),
                    CajaMercadoPago = table.Column<decimal>(type: "decimal(14, 2)", nullable: false),
                    AgregadoEfectivo = table.Column<decimal>(type: "decimal(14, 2)", nullable: false),
                    AgregadoMercadoPago = table.Column<decimal>(type: "decimal(14, 2)", nullable: false),
                    Detalles = table.Column<string>(type: "TEXT", nullable: true),
                    FechaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Hora = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pseudoCajas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pseudoCajas_fechas_FechaId",
                        column: x => x.FechaId,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "conteos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    FechaId = table.Column<int>(type: "INTEGER", nullable: true),
                    CajaEntradaId = table.Column<int>(type: "INTEGER", nullable: true),
                    CajaSalidaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conteos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_conteos_fechas_FechaId",
                        column: x => x.FechaId,
                        principalTable: "fechas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_conteos_pseudoCajas_CajaEntradaId",
                        column: x => x.CajaEntradaId,
                        principalTable: "pseudoCajas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conteos_pseudoCajas_CajaSalidaId",
                        column: x => x.CajaSalidaId,
                        principalTable: "pseudoCajas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conteos_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_conteos_CajaEntradaId",
                table: "conteos",
                column: "CajaEntradaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_conteos_CajaSalidaId",
                table: "conteos",
                column: "CajaSalidaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_conteos_FechaId",
                table: "conteos",
                column: "FechaId");

            migrationBuilder.CreateIndex(
                name: "IX_conteos_UsuarioId",
                table: "conteos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_pseudoCajas_FechaId",
                table: "pseudoCajas",
                column: "FechaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conteos");

            migrationBuilder.DropTable(
                name: "pseudoCajas");
        }
    }
}
