using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class deudaProductoModelAddDeudor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeudorId",
                table: "deudaProductos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_deudaProductos_DeudorId",
                table: "deudaProductos",
                column: "DeudorId");

            migrationBuilder.AddForeignKey(
                name: "FK_deudaProductos_deudores_DeudorId",
                table: "deudaProductos",
                column: "DeudorId",
                principalTable: "deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deudaProductos_deudores_DeudorId",
                table: "deudaProductos");

            migrationBuilder.DropIndex(
                name: "IX_deudaProductos_DeudorId",
                table: "deudaProductos");

            migrationBuilder.DropColumn(
                name: "DeudorId",
                table: "deudaProductos");
        }
    }
}
