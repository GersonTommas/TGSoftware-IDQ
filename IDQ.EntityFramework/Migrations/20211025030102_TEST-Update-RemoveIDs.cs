using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class TESTUpdateRemoveIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_abiertoProductos_fechas_FechaID",
                table: "abiertoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_abiertoProductos_productos_ProductoAgregadoID",
                table: "abiertoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_abiertoProductos_productos_ProductoSacadoID",
                table: "abiertoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_abiertoProductos_usuarios_UsuarioID",
                table: "abiertoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_caja_fechas_FechaID",
                table: "caja");

            migrationBuilder.DropForeignKey(
                name: "FK_consumosProductos_fechas_FechaID",
                table: "consumosProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_consumosProductos_productos_ProductoID",
                table: "consumosProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudaProductos_deudas_DeudaID",
                table: "deudaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudaProductos_productos_ProductoID",
                table: "deudaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudas_deudores_DeudorID",
                table: "deudas");

            migrationBuilder.DropForeignKey(
                name: "FK_deudas_fechas_FechaPagadoID",
                table: "deudas");

            migrationBuilder.DropForeignKey(
                name: "FK_deudas_fechas_FechaSacadoID",
                table: "deudas");

            migrationBuilder.DropForeignKey(
                name: "FK_deudas_ventas_VentaID",
                table: "deudas");

            migrationBuilder.DropForeignKey(
                name: "FK_deudores_usuarios_UsuarioID",
                table: "deudores");

            migrationBuilder.DropForeignKey(
                name: "FK_deudorPagos_caja_CajaID",
                table: "deudorPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudorPagos_deudores_DeudorID",
                table: "deudorPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudorPagos_fechas_FechaID",
                table: "deudorPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresoProductos_ingresos_IngresoID",
                table: "ingresoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresoProductos_productos_ProductoID",
                table: "ingresoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresos_fechas_FechaID",
                table: "ingresos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresos_proveedores_ProveedorID",
                table: "ingresos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresos_usuarios_UsuarioID",
                table: "ingresos");

            migrationBuilder.DropForeignKey(
                name: "FK_modificadoProductos_fechas_FechaID",
                table: "modificadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_modificadoProductos_productos_ProductoID",
                table: "modificadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_modificadoProductos_usuarios_UsuarioID",
                table: "modificadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_fechas_FechaModificadoID",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_medidas_MedidaID",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_tags_TagID",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_caja_CajaID",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_fechas_FechaID",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_proveedores_ProveedorID",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_retiroMotivos_MotivoID",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_usuarios_UsuarioAutorizaID",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_usuarios_UsuarioRetiraID",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_sacadoProductos_fechas_FechaPagadoID",
                table: "sacadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_sacadoProductos_fechas_FechaSacadoID",
                table: "sacadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_sacadoProductos_productos_ProductoID",
                table: "sacadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_sacadoProductos_usuarios_UsuarioID",
                table: "sacadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventaProductos_productos_ProductoID",
                table: "ventaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventaProductos_ventas_VentaID",
                table: "ventaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_deudores_DeudorID",
                table: "ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_fechas_FechaID",
                table: "ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_usuarios_UsuarioID",
                table: "ventas");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "ventas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "FechaID",
                table: "ventas",
                newName: "FechaId");

            migrationBuilder.RenameColumn(
                name: "DeudorID",
                table: "ventas",
                newName: "DeudorId");

            migrationBuilder.RenameIndex(
                name: "IX_ventas_UsuarioID",
                table: "ventas",
                newName: "IX_ventas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ventas_FechaID",
                table: "ventas",
                newName: "IX_ventas_FechaId");

            migrationBuilder.RenameIndex(
                name: "IX_ventas_DeudorID",
                table: "ventas",
                newName: "IX_ventas_DeudorId");

            migrationBuilder.RenameColumn(
                name: "VentaID",
                table: "ventaProductos",
                newName: "VentaId");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "ventaProductos",
                newName: "ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_ventaProductos_VentaID",
                table: "ventaProductos",
                newName: "IX_ventaProductos_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_ventaProductos_ProductoID",
                table: "ventaProductos",
                newName: "IX_ventaProductos_ProductoId");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "sacadoProductos",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "sacadoProductos",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "FechaSacadoID",
                table: "sacadoProductos",
                newName: "FechaSacadoId");

            migrationBuilder.RenameColumn(
                name: "FechaPagadoID",
                table: "sacadoProductos",
                newName: "FechaPagadoId");

            migrationBuilder.RenameIndex(
                name: "IX_sacadoProductos_UsuarioID",
                table: "sacadoProductos",
                newName: "IX_sacadoProductos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_sacadoProductos_ProductoID",
                table: "sacadoProductos",
                newName: "IX_sacadoProductos_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_sacadoProductos_FechaSacadoID",
                table: "sacadoProductos",
                newName: "IX_sacadoProductos_FechaSacadoId");

            migrationBuilder.RenameIndex(
                name: "IX_sacadoProductos_FechaPagadoID",
                table: "sacadoProductos",
                newName: "IX_sacadoProductos_FechaPagadoId");

            migrationBuilder.RenameColumn(
                name: "UsuarioRetiraID",
                table: "retiros",
                newName: "UsuarioRetiraId");

            migrationBuilder.RenameColumn(
                name: "UsuarioAutorizaID",
                table: "retiros",
                newName: "UsuarioAutorizaId");

            migrationBuilder.RenameColumn(
                name: "ProveedorID",
                table: "retiros",
                newName: "ProveedorId");

            migrationBuilder.RenameColumn(
                name: "MotivoID",
                table: "retiros",
                newName: "MotivoId");

            migrationBuilder.RenameColumn(
                name: "FechaID",
                table: "retiros",
                newName: "FechaId");

            migrationBuilder.RenameColumn(
                name: "CajaID",
                table: "retiros",
                newName: "CajaId");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_UsuarioRetiraID",
                table: "retiros",
                newName: "IX_retiros_UsuarioRetiraId");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_UsuarioAutorizaID",
                table: "retiros",
                newName: "IX_retiros_UsuarioAutorizaId");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_ProveedorID",
                table: "retiros",
                newName: "IX_retiros_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_MotivoID",
                table: "retiros",
                newName: "IX_retiros_MotivoId");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_FechaID",
                table: "retiros",
                newName: "IX_retiros_FechaId");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_CajaID",
                table: "retiros",
                newName: "IX_retiros_CajaId");

            migrationBuilder.RenameColumn(
                name: "TagID",
                table: "productos",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "MedidaID",
                table: "productos",
                newName: "MedidaId");

            migrationBuilder.RenameColumn(
                name: "FechaModificadoID",
                table: "productos",
                newName: "FechaModificadoId");

            migrationBuilder.RenameIndex(
                name: "IX_productos_TagID",
                table: "productos",
                newName: "IX_productos_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_productos_MedidaID",
                table: "productos",
                newName: "IX_productos_MedidaId");

            migrationBuilder.RenameIndex(
                name: "IX_productos_FechaModificadoID",
                table: "productos",
                newName: "IX_productos_FechaModificadoId");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "modificadoProductos",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "modificadoProductos",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "FechaID",
                table: "modificadoProductos",
                newName: "FechaId");

            migrationBuilder.RenameIndex(
                name: "IX_modificadoProductos_UsuarioID",
                table: "modificadoProductos",
                newName: "IX_modificadoProductos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_modificadoProductos_ProductoID",
                table: "modificadoProductos",
                newName: "IX_modificadoProductos_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_modificadoProductos_FechaID",
                table: "modificadoProductos",
                newName: "IX_modificadoProductos_FechaId");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "ingresos",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ProveedorID",
                table: "ingresos",
                newName: "ProveedorId");

            migrationBuilder.RenameColumn(
                name: "FechaID",
                table: "ingresos",
                newName: "FechaId");

            migrationBuilder.RenameIndex(
                name: "IX_ingresos_UsuarioID",
                table: "ingresos",
                newName: "IX_ingresos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ingresos_ProveedorID",
                table: "ingresos",
                newName: "IX_ingresos_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_ingresos_FechaID",
                table: "ingresos",
                newName: "IX_ingresos_FechaId");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "ingresoProductos",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "IngresoID",
                table: "ingresoProductos",
                newName: "IngresoId");

            migrationBuilder.RenameIndex(
                name: "IX_ingresoProductos_ProductoID",
                table: "ingresoProductos",
                newName: "IX_ingresoProductos_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_ingresoProductos_IngresoID",
                table: "ingresoProductos",
                newName: "IX_ingresoProductos_IngresoId");

            migrationBuilder.RenameColumn(
                name: "FechaID",
                table: "deudorPagos",
                newName: "FechaId");

            migrationBuilder.RenameColumn(
                name: "DeudorID",
                table: "deudorPagos",
                newName: "DeudorId");

            migrationBuilder.RenameColumn(
                name: "CajaID",
                table: "deudorPagos",
                newName: "CajaId");

            migrationBuilder.RenameIndex(
                name: "IX_deudorPagos_FechaID",
                table: "deudorPagos",
                newName: "IX_deudorPagos_FechaId");

            migrationBuilder.RenameIndex(
                name: "IX_deudorPagos_DeudorID",
                table: "deudorPagos",
                newName: "IX_deudorPagos_DeudorId");

            migrationBuilder.RenameIndex(
                name: "IX_deudorPagos_CajaID",
                table: "deudorPagos",
                newName: "IX_deudorPagos_CajaId");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "deudores",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_deudores_UsuarioID",
                table: "deudores",
                newName: "IX_deudores_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "VentaID",
                table: "deudas",
                newName: "VentaId");

            migrationBuilder.RenameColumn(
                name: "FechaSacadoID",
                table: "deudas",
                newName: "FechaSacadoId");

            migrationBuilder.RenameColumn(
                name: "FechaPagadoID",
                table: "deudas",
                newName: "FechaPagadoId");

            migrationBuilder.RenameColumn(
                name: "DeudorID",
                table: "deudas",
                newName: "DeudorId");

            migrationBuilder.RenameIndex(
                name: "IX_deudas_VentaID",
                table: "deudas",
                newName: "IX_deudas_VentaId");

            migrationBuilder.RenameIndex(
                name: "IX_deudas_FechaSacadoID",
                table: "deudas",
                newName: "IX_deudas_FechaSacadoId");

            migrationBuilder.RenameIndex(
                name: "IX_deudas_FechaPagadoID",
                table: "deudas",
                newName: "IX_deudas_FechaPagadoId");

            migrationBuilder.RenameIndex(
                name: "IX_deudas_DeudorID",
                table: "deudas",
                newName: "IX_deudas_DeudorId");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "deudaProductos",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "DeudaID",
                table: "deudaProductos",
                newName: "DeudaId");

            migrationBuilder.RenameIndex(
                name: "IX_deudaProductos_ProductoID",
                table: "deudaProductos",
                newName: "IX_deudaProductos_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_deudaProductos_DeudaID",
                table: "deudaProductos",
                newName: "IX_deudaProductos_DeudaId");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "consumosProductos",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "FechaID",
                table: "consumosProductos",
                newName: "FechaId");

            migrationBuilder.RenameIndex(
                name: "IX_consumosProductos_ProductoID",
                table: "consumosProductos",
                newName: "IX_consumosProductos_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_consumosProductos_FechaID",
                table: "consumosProductos",
                newName: "IX_consumosProductos_FechaId");

            migrationBuilder.RenameColumn(
                name: "FechaID",
                table: "caja",
                newName: "FechaId");

            migrationBuilder.RenameIndex(
                name: "IX_caja_FechaID",
                table: "caja",
                newName: "IX_caja_FechaId");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "abiertoProductos",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ProductoSacadoID",
                table: "abiertoProductos",
                newName: "ProductoSacadoId");

            migrationBuilder.RenameColumn(
                name: "ProductoAgregadoID",
                table: "abiertoProductos",
                newName: "ProductoAgregadoId");

            migrationBuilder.RenameColumn(
                name: "FechaID",
                table: "abiertoProductos",
                newName: "FechaId");

            migrationBuilder.RenameIndex(
                name: "IX_abiertoProductos_UsuarioID",
                table: "abiertoProductos",
                newName: "IX_abiertoProductos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_abiertoProductos_ProductoSacadoID",
                table: "abiertoProductos",
                newName: "IX_abiertoProductos_ProductoSacadoId");

            migrationBuilder.RenameIndex(
                name: "IX_abiertoProductos_ProductoAgregadoID",
                table: "abiertoProductos",
                newName: "IX_abiertoProductos_ProductoAgregadoId");

            migrationBuilder.RenameIndex(
                name: "IX_abiertoProductos_FechaID",
                table: "abiertoProductos",
                newName: "IX_abiertoProductos_FechaId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ventas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FechaId",
                table: "ventas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "VentaId",
                table: "ventaProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "ventaProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "sacadoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "sacadoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioRetiraId",
                table: "retiros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioAutorizaId",
                table: "retiros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MotivoId",
                table: "retiros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FechaId",
                table: "retiros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CajaId",
                table: "retiros",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "productos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MedidaId",
                table: "productos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "modificadoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "modificadoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FechaId",
                table: "modificadoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "ingresos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorId",
                table: "ingresos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FechaId",
                table: "ingresos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "ingresoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "IngresoId",
                table: "ingresoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FechaId",
                table: "deudorPagos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "DeudorId",
                table: "deudorPagos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CajaId",
                table: "deudorPagos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "deudores",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "DeudorId",
                table: "deudas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "deudaProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "DeudaId",
                table: "deudaProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "consumosProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FechaId",
                table: "consumosProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FechaId",
                table: "caja",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "abiertoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FechaId",
                table: "abiertoProductos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_abiertoProductos_fechas_FechaId",
                table: "abiertoProductos",
                column: "FechaId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_abiertoProductos_productos_ProductoAgregadoId",
                table: "abiertoProductos",
                column: "ProductoAgregadoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_abiertoProductos_productos_ProductoSacadoId",
                table: "abiertoProductos",
                column: "ProductoSacadoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_abiertoProductos_usuarios_UsuarioId",
                table: "abiertoProductos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_caja_fechas_FechaId",
                table: "caja",
                column: "FechaId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_consumosProductos_fechas_FechaId",
                table: "consumosProductos",
                column: "FechaId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_consumosProductos_productos_ProductoId",
                table: "consumosProductos",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudaProductos_deudas_DeudaId",
                table: "deudaProductos",
                column: "DeudaId",
                principalTable: "deudas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudaProductos_productos_ProductoId",
                table: "deudaProductos",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudas_deudores_DeudorId",
                table: "deudas",
                column: "DeudorId",
                principalTable: "deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudas_fechas_FechaPagadoId",
                table: "deudas",
                column: "FechaPagadoId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudas_fechas_FechaSacadoId",
                table: "deudas",
                column: "FechaSacadoId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudas_ventas_VentaId",
                table: "deudas",
                column: "VentaId",
                principalTable: "ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudores_usuarios_UsuarioId",
                table: "deudores",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudorPagos_caja_CajaId",
                table: "deudorPagos",
                column: "CajaId",
                principalTable: "caja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudorPagos_deudores_DeudorId",
                table: "deudorPagos",
                column: "DeudorId",
                principalTable: "deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudorPagos_fechas_FechaId",
                table: "deudorPagos",
                column: "FechaId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresoProductos_ingresos_IngresoId",
                table: "ingresoProductos",
                column: "IngresoId",
                principalTable: "ingresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresoProductos_productos_ProductoId",
                table: "ingresoProductos",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresos_fechas_FechaId",
                table: "ingresos",
                column: "FechaId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresos_proveedores_ProveedorId",
                table: "ingresos",
                column: "ProveedorId",
                principalTable: "proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresos_usuarios_UsuarioId",
                table: "ingresos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_modificadoProductos_fechas_FechaId",
                table: "modificadoProductos",
                column: "FechaId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_modificadoProductos_productos_ProductoId",
                table: "modificadoProductos",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_modificadoProductos_usuarios_UsuarioId",
                table: "modificadoProductos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_fechas_FechaModificadoId",
                table: "productos",
                column: "FechaModificadoId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_medidas_MedidaId",
                table: "productos",
                column: "MedidaId",
                principalTable: "medidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_tags_TagId",
                table: "productos",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_caja_CajaId",
                table: "retiros",
                column: "CajaId",
                principalTable: "caja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_fechas_FechaId",
                table: "retiros",
                column: "FechaId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_proveedores_ProveedorId",
                table: "retiros",
                column: "ProveedorId",
                principalTable: "proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_retiroMotivos_MotivoId",
                table: "retiros",
                column: "MotivoId",
                principalTable: "retiroMotivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_usuarios_UsuarioAutorizaId",
                table: "retiros",
                column: "UsuarioAutorizaId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_usuarios_UsuarioRetiraId",
                table: "retiros",
                column: "UsuarioRetiraId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sacadoProductos_fechas_FechaPagadoId",
                table: "sacadoProductos",
                column: "FechaPagadoId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sacadoProductos_fechas_FechaSacadoId",
                table: "sacadoProductos",
                column: "FechaSacadoId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sacadoProductos_productos_ProductoId",
                table: "sacadoProductos",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sacadoProductos_usuarios_UsuarioId",
                table: "sacadoProductos",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventaProductos_productos_ProductoId",
                table: "ventaProductos",
                column: "ProductoId",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventaProductos_ventas_VentaId",
                table: "ventaProductos",
                column: "VentaId",
                principalTable: "ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_deudores_DeudorId",
                table: "ventas",
                column: "DeudorId",
                principalTable: "deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_fechas_FechaId",
                table: "ventas",
                column: "FechaId",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_usuarios_UsuarioId",
                table: "ventas",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_abiertoProductos_fechas_FechaId",
                table: "abiertoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_abiertoProductos_productos_ProductoAgregadoId",
                table: "abiertoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_abiertoProductos_productos_ProductoSacadoId",
                table: "abiertoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_abiertoProductos_usuarios_UsuarioId",
                table: "abiertoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_caja_fechas_FechaId",
                table: "caja");

            migrationBuilder.DropForeignKey(
                name: "FK_consumosProductos_fechas_FechaId",
                table: "consumosProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_consumosProductos_productos_ProductoId",
                table: "consumosProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudaProductos_deudas_DeudaId",
                table: "deudaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudaProductos_productos_ProductoId",
                table: "deudaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudas_deudores_DeudorId",
                table: "deudas");

            migrationBuilder.DropForeignKey(
                name: "FK_deudas_fechas_FechaPagadoId",
                table: "deudas");

            migrationBuilder.DropForeignKey(
                name: "FK_deudas_fechas_FechaSacadoId",
                table: "deudas");

            migrationBuilder.DropForeignKey(
                name: "FK_deudas_ventas_VentaId",
                table: "deudas");

            migrationBuilder.DropForeignKey(
                name: "FK_deudores_usuarios_UsuarioId",
                table: "deudores");

            migrationBuilder.DropForeignKey(
                name: "FK_deudorPagos_caja_CajaId",
                table: "deudorPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudorPagos_deudores_DeudorId",
                table: "deudorPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_deudorPagos_fechas_FechaId",
                table: "deudorPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresoProductos_ingresos_IngresoId",
                table: "ingresoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresoProductos_productos_ProductoId",
                table: "ingresoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresos_fechas_FechaId",
                table: "ingresos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresos_proveedores_ProveedorId",
                table: "ingresos");

            migrationBuilder.DropForeignKey(
                name: "FK_ingresos_usuarios_UsuarioId",
                table: "ingresos");

            migrationBuilder.DropForeignKey(
                name: "FK_modificadoProductos_fechas_FechaId",
                table: "modificadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_modificadoProductos_productos_ProductoId",
                table: "modificadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_modificadoProductos_usuarios_UsuarioId",
                table: "modificadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_fechas_FechaModificadoId",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_medidas_MedidaId",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_tags_TagId",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_caja_CajaId",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_fechas_FechaId",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_proveedores_ProveedorId",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_retiroMotivos_MotivoId",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_usuarios_UsuarioAutorizaId",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_retiros_usuarios_UsuarioRetiraId",
                table: "retiros");

            migrationBuilder.DropForeignKey(
                name: "FK_sacadoProductos_fechas_FechaPagadoId",
                table: "sacadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_sacadoProductos_fechas_FechaSacadoId",
                table: "sacadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_sacadoProductos_productos_ProductoId",
                table: "sacadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_sacadoProductos_usuarios_UsuarioId",
                table: "sacadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventaProductos_productos_ProductoId",
                table: "ventaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventaProductos_ventas_VentaId",
                table: "ventaProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_deudores_DeudorId",
                table: "ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_fechas_FechaId",
                table: "ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_ventas_usuarios_UsuarioId",
                table: "ventas");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ventas",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "FechaId",
                table: "ventas",
                newName: "FechaID");

            migrationBuilder.RenameColumn(
                name: "DeudorId",
                table: "ventas",
                newName: "DeudorID");

            migrationBuilder.RenameIndex(
                name: "IX_ventas_UsuarioId",
                table: "ventas",
                newName: "IX_ventas_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_ventas_FechaId",
                table: "ventas",
                newName: "IX_ventas_FechaID");

            migrationBuilder.RenameIndex(
                name: "IX_ventas_DeudorId",
                table: "ventas",
                newName: "IX_ventas_DeudorID");

            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "ventaProductos",
                newName: "VentaID");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "ventaProductos",
                newName: "ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_ventaProductos_VentaId",
                table: "ventaProductos",
                newName: "IX_ventaProductos_VentaID");

            migrationBuilder.RenameIndex(
                name: "IX_ventaProductos_ProductoId",
                table: "ventaProductos",
                newName: "IX_ventaProductos_ProductoID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "sacadoProductos",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "sacadoProductos",
                newName: "ProductoID");

            migrationBuilder.RenameColumn(
                name: "FechaSacadoId",
                table: "sacadoProductos",
                newName: "FechaSacadoID");

            migrationBuilder.RenameColumn(
                name: "FechaPagadoId",
                table: "sacadoProductos",
                newName: "FechaPagadoID");

            migrationBuilder.RenameIndex(
                name: "IX_sacadoProductos_UsuarioId",
                table: "sacadoProductos",
                newName: "IX_sacadoProductos_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_sacadoProductos_ProductoId",
                table: "sacadoProductos",
                newName: "IX_sacadoProductos_ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_sacadoProductos_FechaSacadoId",
                table: "sacadoProductos",
                newName: "IX_sacadoProductos_FechaSacadoID");

            migrationBuilder.RenameIndex(
                name: "IX_sacadoProductos_FechaPagadoId",
                table: "sacadoProductos",
                newName: "IX_sacadoProductos_FechaPagadoID");

            migrationBuilder.RenameColumn(
                name: "UsuarioRetiraId",
                table: "retiros",
                newName: "UsuarioRetiraID");

            migrationBuilder.RenameColumn(
                name: "UsuarioAutorizaId",
                table: "retiros",
                newName: "UsuarioAutorizaID");

            migrationBuilder.RenameColumn(
                name: "ProveedorId",
                table: "retiros",
                newName: "ProveedorID");

            migrationBuilder.RenameColumn(
                name: "MotivoId",
                table: "retiros",
                newName: "MotivoID");

            migrationBuilder.RenameColumn(
                name: "FechaId",
                table: "retiros",
                newName: "FechaID");

            migrationBuilder.RenameColumn(
                name: "CajaId",
                table: "retiros",
                newName: "CajaID");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_UsuarioRetiraId",
                table: "retiros",
                newName: "IX_retiros_UsuarioRetiraID");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_UsuarioAutorizaId",
                table: "retiros",
                newName: "IX_retiros_UsuarioAutorizaID");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_ProveedorId",
                table: "retiros",
                newName: "IX_retiros_ProveedorID");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_MotivoId",
                table: "retiros",
                newName: "IX_retiros_MotivoID");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_FechaId",
                table: "retiros",
                newName: "IX_retiros_FechaID");

            migrationBuilder.RenameIndex(
                name: "IX_retiros_CajaId",
                table: "retiros",
                newName: "IX_retiros_CajaID");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "productos",
                newName: "TagID");

            migrationBuilder.RenameColumn(
                name: "MedidaId",
                table: "productos",
                newName: "MedidaID");

            migrationBuilder.RenameColumn(
                name: "FechaModificadoId",
                table: "productos",
                newName: "FechaModificadoID");

            migrationBuilder.RenameIndex(
                name: "IX_productos_TagId",
                table: "productos",
                newName: "IX_productos_TagID");

            migrationBuilder.RenameIndex(
                name: "IX_productos_MedidaId",
                table: "productos",
                newName: "IX_productos_MedidaID");

            migrationBuilder.RenameIndex(
                name: "IX_productos_FechaModificadoId",
                table: "productos",
                newName: "IX_productos_FechaModificadoID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "modificadoProductos",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "modificadoProductos",
                newName: "ProductoID");

            migrationBuilder.RenameColumn(
                name: "FechaId",
                table: "modificadoProductos",
                newName: "FechaID");

            migrationBuilder.RenameIndex(
                name: "IX_modificadoProductos_UsuarioId",
                table: "modificadoProductos",
                newName: "IX_modificadoProductos_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_modificadoProductos_ProductoId",
                table: "modificadoProductos",
                newName: "IX_modificadoProductos_ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_modificadoProductos_FechaId",
                table: "modificadoProductos",
                newName: "IX_modificadoProductos_FechaID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ingresos",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "ProveedorId",
                table: "ingresos",
                newName: "ProveedorID");

            migrationBuilder.RenameColumn(
                name: "FechaId",
                table: "ingresos",
                newName: "FechaID");

            migrationBuilder.RenameIndex(
                name: "IX_ingresos_UsuarioId",
                table: "ingresos",
                newName: "IX_ingresos_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_ingresos_ProveedorId",
                table: "ingresos",
                newName: "IX_ingresos_ProveedorID");

            migrationBuilder.RenameIndex(
                name: "IX_ingresos_FechaId",
                table: "ingresos",
                newName: "IX_ingresos_FechaID");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "ingresoProductos",
                newName: "ProductoID");

            migrationBuilder.RenameColumn(
                name: "IngresoId",
                table: "ingresoProductos",
                newName: "IngresoID");

            migrationBuilder.RenameIndex(
                name: "IX_ingresoProductos_ProductoId",
                table: "ingresoProductos",
                newName: "IX_ingresoProductos_ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_ingresoProductos_IngresoId",
                table: "ingresoProductos",
                newName: "IX_ingresoProductos_IngresoID");

            migrationBuilder.RenameColumn(
                name: "FechaId",
                table: "deudorPagos",
                newName: "FechaID");

            migrationBuilder.RenameColumn(
                name: "DeudorId",
                table: "deudorPagos",
                newName: "DeudorID");

            migrationBuilder.RenameColumn(
                name: "CajaId",
                table: "deudorPagos",
                newName: "CajaID");

            migrationBuilder.RenameIndex(
                name: "IX_deudorPagos_FechaId",
                table: "deudorPagos",
                newName: "IX_deudorPagos_FechaID");

            migrationBuilder.RenameIndex(
                name: "IX_deudorPagos_DeudorId",
                table: "deudorPagos",
                newName: "IX_deudorPagos_DeudorID");

            migrationBuilder.RenameIndex(
                name: "IX_deudorPagos_CajaId",
                table: "deudorPagos",
                newName: "IX_deudorPagos_CajaID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "deudores",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_deudores_UsuarioId",
                table: "deudores",
                newName: "IX_deudores_UsuarioID");

            migrationBuilder.RenameColumn(
                name: "VentaId",
                table: "deudas",
                newName: "VentaID");

            migrationBuilder.RenameColumn(
                name: "FechaSacadoId",
                table: "deudas",
                newName: "FechaSacadoID");

            migrationBuilder.RenameColumn(
                name: "FechaPagadoId",
                table: "deudas",
                newName: "FechaPagadoID");

            migrationBuilder.RenameColumn(
                name: "DeudorId",
                table: "deudas",
                newName: "DeudorID");

            migrationBuilder.RenameIndex(
                name: "IX_deudas_VentaId",
                table: "deudas",
                newName: "IX_deudas_VentaID");

            migrationBuilder.RenameIndex(
                name: "IX_deudas_FechaSacadoId",
                table: "deudas",
                newName: "IX_deudas_FechaSacadoID");

            migrationBuilder.RenameIndex(
                name: "IX_deudas_FechaPagadoId",
                table: "deudas",
                newName: "IX_deudas_FechaPagadoID");

            migrationBuilder.RenameIndex(
                name: "IX_deudas_DeudorId",
                table: "deudas",
                newName: "IX_deudas_DeudorID");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "deudaProductos",
                newName: "ProductoID");

            migrationBuilder.RenameColumn(
                name: "DeudaId",
                table: "deudaProductos",
                newName: "DeudaID");

            migrationBuilder.RenameIndex(
                name: "IX_deudaProductos_ProductoId",
                table: "deudaProductos",
                newName: "IX_deudaProductos_ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_deudaProductos_DeudaId",
                table: "deudaProductos",
                newName: "IX_deudaProductos_DeudaID");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "consumosProductos",
                newName: "ProductoID");

            migrationBuilder.RenameColumn(
                name: "FechaId",
                table: "consumosProductos",
                newName: "FechaID");

            migrationBuilder.RenameIndex(
                name: "IX_consumosProductos_ProductoId",
                table: "consumosProductos",
                newName: "IX_consumosProductos_ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_consumosProductos_FechaId",
                table: "consumosProductos",
                newName: "IX_consumosProductos_FechaID");

            migrationBuilder.RenameColumn(
                name: "FechaId",
                table: "caja",
                newName: "FechaID");

            migrationBuilder.RenameIndex(
                name: "IX_caja_FechaId",
                table: "caja",
                newName: "IX_caja_FechaID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "abiertoProductos",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "ProductoSacadoId",
                table: "abiertoProductos",
                newName: "ProductoSacadoID");

            migrationBuilder.RenameColumn(
                name: "ProductoAgregadoId",
                table: "abiertoProductos",
                newName: "ProductoAgregadoID");

            migrationBuilder.RenameColumn(
                name: "FechaId",
                table: "abiertoProductos",
                newName: "FechaID");

            migrationBuilder.RenameIndex(
                name: "IX_abiertoProductos_UsuarioId",
                table: "abiertoProductos",
                newName: "IX_abiertoProductos_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_abiertoProductos_ProductoSacadoId",
                table: "abiertoProductos",
                newName: "IX_abiertoProductos_ProductoSacadoID");

            migrationBuilder.RenameIndex(
                name: "IX_abiertoProductos_ProductoAgregadoId",
                table: "abiertoProductos",
                newName: "IX_abiertoProductos_ProductoAgregadoID");

            migrationBuilder.RenameIndex(
                name: "IX_abiertoProductos_FechaId",
                table: "abiertoProductos",
                newName: "IX_abiertoProductos_FechaID");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaID",
                table: "ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VentaID",
                table: "ventaProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "ventaProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "sacadoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "sacadoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioRetiraID",
                table: "retiros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioAutorizaID",
                table: "retiros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MotivoID",
                table: "retiros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaID",
                table: "retiros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CajaID",
                table: "retiros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TagID",
                table: "productos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedidaID",
                table: "productos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "modificadoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "modificadoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaID",
                table: "modificadoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "ingresos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProveedorID",
                table: "ingresos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaID",
                table: "ingresos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "ingresoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IngresoID",
                table: "ingresoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaID",
                table: "deudorPagos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeudorID",
                table: "deudorPagos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CajaID",
                table: "deudorPagos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "deudores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeudorID",
                table: "deudas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "deudaProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeudaID",
                table: "deudaProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoID",
                table: "consumosProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaID",
                table: "consumosProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaID",
                table: "caja",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "abiertoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FechaID",
                table: "abiertoProductos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_abiertoProductos_fechas_FechaID",
                table: "abiertoProductos",
                column: "FechaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_abiertoProductos_productos_ProductoAgregadoID",
                table: "abiertoProductos",
                column: "ProductoAgregadoID",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_abiertoProductos_productos_ProductoSacadoID",
                table: "abiertoProductos",
                column: "ProductoSacadoID",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_abiertoProductos_usuarios_UsuarioID",
                table: "abiertoProductos",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_caja_fechas_FechaID",
                table: "caja",
                column: "FechaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_consumosProductos_fechas_FechaID",
                table: "consumosProductos",
                column: "FechaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_consumosProductos_productos_ProductoID",
                table: "consumosProductos",
                column: "ProductoID",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudaProductos_deudas_DeudaID",
                table: "deudaProductos",
                column: "DeudaID",
                principalTable: "deudas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudaProductos_productos_ProductoID",
                table: "deudaProductos",
                column: "ProductoID",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudas_deudores_DeudorID",
                table: "deudas",
                column: "DeudorID",
                principalTable: "deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudas_fechas_FechaPagadoID",
                table: "deudas",
                column: "FechaPagadoID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_deudas_fechas_FechaSacadoID",
                table: "deudas",
                column: "FechaSacadoID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudas_ventas_VentaID",
                table: "deudas",
                column: "VentaID",
                principalTable: "ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudores_usuarios_UsuarioID",
                table: "deudores",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudorPagos_caja_CajaID",
                table: "deudorPagos",
                column: "CajaID",
                principalTable: "caja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudorPagos_deudores_DeudorID",
                table: "deudorPagos",
                column: "DeudorID",
                principalTable: "deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deudorPagos_fechas_FechaID",
                table: "deudorPagos",
                column: "FechaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresoProductos_ingresos_IngresoID",
                table: "ingresoProductos",
                column: "IngresoID",
                principalTable: "ingresos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresoProductos_productos_ProductoID",
                table: "ingresoProductos",
                column: "ProductoID",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresos_fechas_FechaID",
                table: "ingresos",
                column: "FechaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresos_proveedores_ProveedorID",
                table: "ingresos",
                column: "ProveedorID",
                principalTable: "proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ingresos_usuarios_UsuarioID",
                table: "ingresos",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modificadoProductos_fechas_FechaID",
                table: "modificadoProductos",
                column: "FechaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modificadoProductos_productos_ProductoID",
                table: "modificadoProductos",
                column: "ProductoID",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modificadoProductos_usuarios_UsuarioID",
                table: "modificadoProductos",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_fechas_FechaModificadoID",
                table: "productos",
                column: "FechaModificadoID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_medidas_MedidaID",
                table: "productos",
                column: "MedidaID",
                principalTable: "medidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_tags_TagID",
                table: "productos",
                column: "TagID",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_caja_CajaID",
                table: "retiros",
                column: "CajaID",
                principalTable: "caja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_fechas_FechaID",
                table: "retiros",
                column: "FechaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_proveedores_ProveedorID",
                table: "retiros",
                column: "ProveedorID",
                principalTable: "proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_retiroMotivos_MotivoID",
                table: "retiros",
                column: "MotivoID",
                principalTable: "retiroMotivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_usuarios_UsuarioAutorizaID",
                table: "retiros",
                column: "UsuarioAutorizaID",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_retiros_usuarios_UsuarioRetiraID",
                table: "retiros",
                column: "UsuarioRetiraID",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sacadoProductos_fechas_FechaPagadoID",
                table: "sacadoProductos",
                column: "FechaPagadoID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sacadoProductos_fechas_FechaSacadoID",
                table: "sacadoProductos",
                column: "FechaSacadoID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sacadoProductos_productos_ProductoID",
                table: "sacadoProductos",
                column: "ProductoID",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sacadoProductos_usuarios_UsuarioID",
                table: "sacadoProductos",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventaProductos_productos_ProductoID",
                table: "ventaProductos",
                column: "ProductoID",
                principalTable: "productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventaProductos_ventas_VentaID",
                table: "ventaProductos",
                column: "VentaID",
                principalTable: "ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_deudores_DeudorID",
                table: "ventas",
                column: "DeudorID",
                principalTable: "deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_fechas_FechaID",
                table: "ventas",
                column: "FechaID",
                principalTable: "fechas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_usuarios_UsuarioID",
                table: "ventas",
                column: "UsuarioID",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
