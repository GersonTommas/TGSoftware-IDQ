using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class doubletodecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioTotal",
                table: "ventas",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioPagado",
                table: "ventaProductos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "ventaProductos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Resto",
                table: "usuarios",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "sacadoProductos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioIngreso",
                table: "productos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioActual",
                table: "productos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioTotal",
                table: "ingresos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PagadoPesos",
                table: "ingresos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PagadoMP",
                table: "ingresos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioPagado",
                table: "ingresoProductos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioActual",
                table: "ingresoProductos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Resto",
                table: "deudores",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPagado",
                table: "deudas",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioPagado",
                table: "deudaProductos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "deudaProductos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "consumosProductos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "MercadoPagoCierre",
                table: "cajaConteos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "MercadoPagoApertura",
                table: "cajaConteos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "EfectivoCierre",
                table: "cajaConteos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "EfectivoApertura",
                table: "cajaConteos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiferenciaCierre",
                table: "cajaConteos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiferenciaApertura",
                table: "cajaConteos",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Vuelto",
                table: "caja",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "MercadoPago",
                table: "caja",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Efectivo",
                table: "caja",
                type: "decimal(14, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PrecioTotal",
                table: "ventas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioPagado",
                table: "ventaProductos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "ventaProductos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Resto",
                table: "usuarios",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "sacadoProductos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioIngreso",
                table: "productos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioActual",
                table: "productos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioTotal",
                table: "ingresos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PagadoPesos",
                table: "ingresos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PagadoMP",
                table: "ingresos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioPagado",
                table: "ingresoProductos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioActual",
                table: "ingresoProductos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Resto",
                table: "deudores",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPagado",
                table: "deudas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioPagado",
                table: "deudaProductos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "deudaProductos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "consumosProductos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "MercadoPagoCierre",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "MercadoPagoApertura",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "EfectivoCierre",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "EfectivoApertura",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "DiferenciaCierre",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "DiferenciaApertura",
                table: "cajaConteos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Vuelto",
                table: "caja",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "MercadoPago",
                table: "caja",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Efectivo",
                table: "caja",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14, 2)");
        }
    }
}
