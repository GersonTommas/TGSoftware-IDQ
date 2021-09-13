using IDQ.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.EntityFramework.Updates
{
    class Update016000
    {
        public static void xDoUpdate()
        {
            #region Update ventas 01
            ObservableCollection<ventaModel> ventas = context.globalDb.ventas.Local.ToObservableCollection();
            if (ventas.All(x => x.PrecioTotal == 0))
            {
                foreach (ventaModel venta in ventas)
                {
                    venta.PrecioTotal = Math.Round(venta.VentaProductosPerVenta.Sum(x => x.PrecioTotal), 2);
                }
                _ = context.globalDb.SaveChangesAsync();
            }
            #endregion // Update ventas 01


            #region Update deudorPagos 01
            ObservableCollection<deudorPagoModel> deudorPagos = context.globalDb.deudorPagos.Local.ToObservableCollection();
            ObservableCollection<cajaModel> cajas = context.globalDb.caja.Local.ToObservableCollection();
            if (deudorPagos.Count == 0)
            {
                 foreach (cajaModel caja in cajas)
                {
                    if (caja.VentaProductosPerCaja.Count > 0)
                    {
                        deudorPagoModel deudaPago = new deudorPagoModel();
                        deudaPago.Caja = caja; deudaPago.Fecha = caja.Fecha;

                        foreach (ventaProductoModel ventaProducto in caja.VentaProductosPerCaja)
                        {
                            if (deudaPago.Deudor == null)
                            {
                                deudaPago.Deudor = ventaProducto.Deudor;
                            }
                            if (!deudaPago.VentaProductosPerDeudorPago.Contains(ventaProducto))
                            {
                                deudaPago.VentaProductosPerDeudorPago.Add(ventaProducto);
                            }
                            if (!deudaPago.VentaPerDeudorPago.Contains(ventaProducto.Venta))
                            {
                                deudaPago.VentaPerDeudorPago.Add(ventaProducto.Venta);
                            }
                        }
                        if (deudaPago.Deudor != null)
                        {
                            context.globalDb.deudorPagos.Local.Add(deudaPago);
                            _ = context.globalDb.SaveChanges();
                        }
                    }
                }
            }
            #endregion // Update deudorPagos 01

            
            #region Update cajaConteo 01
            ObservableCollection<cajaConteoModel> cajaConteos = context.globalDb.cajaConteos.Local.ToObservableCollection();
            if (cajaConteos.All(x => x.EfectivoApertura == 0))
            {
                foreach (cajaConteoModel cajaConteo in cajaConteos)
                {
                    cajaConteo.EfectivoApertura = cajaConteo.EfectivoCierre = cajaConteo.Caja.MercadoPago;
                    cajaConteo.FechaApertura = cajaConteo.FechaCierre = cajaConteo.Caja.Fecha;
                    cajaConteo.HoraApertura = cajaConteo.HoraCierre = cajaConteo.Caja.Hora;
                    cajaConteo.CajaCierre = cajaConteo.Caja;

                    cajaConteo.Caja.MercadoPago = 0;
                    cajaConteo.Caja.Vuelto = 0;
                }
                context.globalDb.SaveChanges();
            }
            #endregion // Update cajaConteo 01
        }
    }
}
