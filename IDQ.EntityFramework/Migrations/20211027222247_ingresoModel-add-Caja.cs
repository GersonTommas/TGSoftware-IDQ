using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class ingresoModeladdCaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CajaId",
                table: "ingresos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ingresos_CajaId",
                table: "ingresos",
                column: "CajaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresos_caja_CajaId",
                table: "ingresos",
                column: "CajaId",
                principalTable: "caja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingresos_caja_CajaId",
                table: "ingresos");

            migrationBuilder.DropIndex(
                name: "IX_ingresos_CajaId",
                table: "ingresos");

            migrationBuilder.DropColumn(
                name: "CajaId",
                table: "ingresos");
        }
    }
}
