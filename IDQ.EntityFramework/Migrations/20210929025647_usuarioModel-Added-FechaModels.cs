using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class usuarioModelAddedFechaModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FechaDeEgresoId",
                table: "usuarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FechaDeIngresoId",
                table: "usuarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_FechaDeEgresoId",
                table: "usuarios",
                column: "FechaDeEgresoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_FechaDeIngresoId",
                table: "usuarios",
                column: "FechaDeIngresoId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_fechas_FechaDeEgresoId",
                table: "usuarios",
                column: "FechaDeEgresoId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_fechas_FechaDeIngresoId",
                table: "usuarios",
                column: "FechaDeIngresoId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_fechas_FechaDeEgresoId",
                table: "usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_fechas_FechaDeIngresoId",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_FechaDeEgresoId",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_FechaDeIngresoId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "FechaDeEgresoId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "FechaDeIngresoId",
                table: "usuarios");
        }
    }
}
