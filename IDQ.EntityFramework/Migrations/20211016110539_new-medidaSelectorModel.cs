using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class newmedidaSelectorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_conteos_pseudoCajas_CajaEntradaId",
                table: "conteos");

            migrationBuilder.DropForeignKey(
                name: "FK_conteos_pseudoCajas_CajaSalidaId",
                table: "conteos");

            migrationBuilder.AddColumn<int>(
                name: "TipoSelectorId",
                table: "medidas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CajaSalidaId",
                table: "conteos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CajaEntradaId",
                table: "conteos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "medidaSelector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medidaSelector", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medidas_TipoSelectorId",
                table: "medidas",
                column: "TipoSelectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_conteos_pseudoCajas_CajaEntradaId",
                table: "conteos",
                column: "CajaEntradaId",
                principalTable: "pseudoCajas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_conteos_pseudoCajas_CajaSalidaId",
                table: "conteos",
                column: "CajaSalidaId",
                principalTable: "pseudoCajas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medidas_medidaSelector_TipoSelectorId",
                table: "medidas",
                column: "TipoSelectorId",
                principalTable: "medidaSelector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_conteos_pseudoCajas_CajaEntradaId",
                table: "conteos");

            migrationBuilder.DropForeignKey(
                name: "FK_conteos_pseudoCajas_CajaSalidaId",
                table: "conteos");

            migrationBuilder.DropForeignKey(
                name: "FK_medidas_medidaSelector_TipoSelectorId",
                table: "medidas");

            migrationBuilder.DropTable(
                name: "medidaSelector");

            migrationBuilder.DropIndex(
                name: "IX_medidas_TipoSelectorId",
                table: "medidas");

            migrationBuilder.DropColumn(
                name: "TipoSelectorId",
                table: "medidas");

            migrationBuilder.AlterColumn<int>(
                name: "CajaSalidaId",
                table: "conteos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CajaEntradaId",
                table: "conteos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_conteos_pseudoCajas_CajaEntradaId",
                table: "conteos",
                column: "CajaEntradaId",
                principalTable: "pseudoCajas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conteos_pseudoCajas_CajaSalidaId",
                table: "conteos",
                column: "CajaSalidaId",
                principalTable: "pseudoCajas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
