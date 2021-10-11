using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class cajaconteos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropColumn(
                name: "Salida",
                table: "cajaConteos");
            */

            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "cajaConteos");

            migrationBuilder.RenameColumn(
                name: "Salida",
                table: "cajaConteos",
                newName: "Detalle");

            migrationBuilder.RenameColumn(
                name: "Diferencia",
                table: "cajaConteos",
                newName: "DiferenciaApertura");
            
            migrationBuilder.AddColumn<int>(
                name: "FechaAperturaID",
                table: "cajaConteos",
                type: "INTEGER",
                nullable: false,
                defaultValue: "1");

            migrationBuilder.AddColumn<int>(
                name: "CajaCierreID",
                table: "cajaConteos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MercadoPagoCierre",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DiferenciaCierre",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EfectivoApertura",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EfectivoCierre",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "FechaCierreID",
                table: "cajaConteos",
                type: "INTEGER",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "HoraApertura",
                table: "cajaConteos",
                type: "TEXT",
                nullable: true);
            
            migrationBuilder.AddColumn<string>(
                name: "HoraCierre",
                table: "cajaConteos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MercadoPagoApertura",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_cajaConteos_CajaCierreID",
                table: "cajaConteos",
                column: "CajaCierreID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cajaConteos_FechaAperturaID",
                table: "cajaConteos",
                column: "FechaAperturaID");

            migrationBuilder.CreateIndex(
                name: "IX_cajaConteos_FechaCierreID",
                table: "cajaConteos",
                column: "FechaCierreID");

            migrationBuilder.AddForeignKey(
                name: "FK_cajaConteos_caja_CajaCierreID",
                table: "cajaConteos",
                column: "CajaCierreID",
                principalTable: "caja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cajaConteos_fechas_FechaAperturaID",
                table: "cajaConteos",
                column: "FechaAperturaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cajaConteos_fechas_FechaCierreID",
                table: "cajaConteos",
                column: "FechaCierreID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cajaConteos_caja_CajaCierreID",
                table: "cajaConteos");

            migrationBuilder.DropForeignKey(
                name: "FK_cajaConteos_fechas_FechaAperturaID",
                table: "cajaConteos");

            migrationBuilder.DropForeignKey(
                name: "FK_cajaConteos_fechas_FechaCierreID",
                table: "cajaConteos");

            migrationBuilder.DropIndex(
                name: "IX_cajaConteos_CajaCierreID",
                table: "cajaConteos");

            migrationBuilder.DropIndex(
                name: "IX_cajaConteos_FechaAperturaID",
                table: "cajaConteos");

            migrationBuilder.DropIndex(
                name: "IX_cajaConteos_FechaCierreID",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "CajaCierreID",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "DiferenciaApertura",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "DiferenciaCierre",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "EfectivoApertura",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "EfectivoCierre",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "FechaCierreID",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "HoraApertura",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "HoraCierre",
                table: "cajaConteos");

            migrationBuilder.DropColumn(
                name: "MercadoPagoApertura",
                table: "cajaConteos");

            migrationBuilder.RenameColumn(
                name: "MercadoPagoCierre",
                table: "cajaConteos",
                newName: "Diferencia");

            /*
            migrationBuilder.RenameColumn(
                name: "FechaAperturaID",
                table: "cajaConteos",
                newName: "Salida");*/
        }
    }
}
