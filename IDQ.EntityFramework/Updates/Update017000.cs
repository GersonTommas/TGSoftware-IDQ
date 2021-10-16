using IDQ.Domain.Models;
using System.Linq;

namespace IDQ.EntityFramework.Updates
{
    class Update017000
    {
        public static void xDoUpdate()
        {
            if (!context.globalDb.medidaSelector.Local.Any())
            {
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "cm" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "cc" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "g" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "Kg" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "L" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "ml" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "u" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "Par" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "w" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "Kw" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "v" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "Talle" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "mg" });
                context.globalDb.medidaSelector.Local.Add(new medidaSelectorModel() { Tipo = "cl" });

                _ = context.globalDb.SaveChanges();
            }
            foreach (medidaModel item in context.globalDb.medidas.Local)
            {
                try { item.TipoSelector = context.globalDb.medidaSelector.Local.Single(x => x.Tipo == item.TipoShort); } catch { }
            }
            _ = context.globalDb.SaveChanges();


            foreach (fechaModel item in context.globalDb.fechas.Local)
            {
                System.Collections.Generic.IEnumerable<fechaModel> itemlist = context.globalDb.fechas.Local.Where(x => x.Fecha == item.Fecha);
                if (itemlist.Count() > 1)
                {
                    fechaModel newFecha = context.globalDb.fechas.Local.First(x => x.Fecha == item.Fecha);

                    if (newFecha.Id != item.Id)
                    {
                        foreach (abiertoProductoModel subitem in item.AbiertoProductosPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (cajaConteoModel subitem in item.CajaConteosAperturaPerFecha)
                        {
                            subitem.FechaApertura = newFecha;
                        }
                        foreach (cajaConteoModel subitem in item.CajaConteosCierrePerFecha)
                        {
                            subitem.FechaCierre = newFecha;
                        }
                        foreach (cajaModel subitem in item.CajasPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (consumoProductoModel subitem in item.ConsumosProductosPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (conteoModel subitem in item.ConteosPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (deudaModel subitem in item.DeudasPagadoPerFecha)
                        {
                            subitem.FechaPagado = newFecha;
                        }
                        foreach (deudaModel subitem in item.DeudasSacadoPerFecha)
                        {
                            subitem.FechaSacado = newFecha;
                        }
                        foreach (deudorPagoModel subitem in item.DeudorPagosPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (ingresoModel subitem in item.IngresosPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (modificadoProductoModel subitem in item.ModificadosProductosPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (productoModel subitem in item.ProductosModificadosPerFecha)
                        {
                            subitem.FechaModificado = newFecha;
                        }
                        foreach (pseudoCajaModel subitem in item.pseudoCajasPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (retiroCajaModel subitem in item.RetirosPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                        foreach (sacadoProductoModel subitem in item.SacadoProductosPagadosPerFecha)
                        {
                            subitem.FechaPagado = newFecha;
                        }
                        foreach (sacadoProductoModel subitem in item.SacadoProductosSacadosPerFecha)
                        {
                            subitem.FechaSacado = newFecha;
                        }
                        foreach (usuarioModel subitem in item.UsuariosPerFechaEgreso)
                        {
                            subitem.FechaDeEgreso = newFecha;
                        }
                        foreach (usuarioModel subitem in item.UsuariosPerFechaIngreso)
                        {
                            subitem.FechaDeIngreso = newFecha;
                        }
                        foreach (ventaProductoModel subitem in item.VentaProductosPagadosPerFecha)
                        {
                            subitem.FechaPagado = newFecha;
                        }
                        foreach (ventaModel subitem in item.VentasPerFecha)
                        {
                            subitem.Fecha = newFecha;
                        }
                    }
                }
            }
            _ = context.globalDb.SaveChanges();
        }
    }
}
