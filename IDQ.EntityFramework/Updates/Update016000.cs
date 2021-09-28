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
                        deudorPagoModel deudaPago = new deudorPagoModel
                        {
                            Caja = caja,
                            Fecha = caja.Fecha
                        };

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
                _ = context.globalDb.SaveChanges();
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
                _ = context.globalDb.SaveChanges();
            }
            #endregion // Update cajaConteo 01


            #region // Update Add-Ingreso-PrecioTotal
            ObservableCollection<ingresoModel> ingresos = context.globalDb.ingresos.Local.ToObservableCollection();
            if (ingresos.All(x => x.PrecioTotal == 0))
            {
                foreach (ingresoModel ingreso in ingresos)
                {
                    ingreso.PrecioTotal = Math.Round(ingreso.IngresoProductosPerIngreso.Sum(x => x.PrecioTotal), 2);
                }
                _ = context.globalDb.SaveChanges();
            }
            #endregion // Update Add-Ingreso-PrecioTotal


            #region Update Add-DeudorForCaja
            ObservableCollection<deudorModel> deudores = context.globalAllDeudores;
            if (deudores.All(x => x.cajasPerDeudor.Count == 0))
            {
                foreach (deudorModel deudor in deudores)
                {
                    if (deudor.DeudorPagosPerDeudor.Count > 0)
                    {
                        foreach (deudorPagoModel deudorPago in deudor.DeudorPagosPerDeudor)
                        {
                            if (!deudor.cajasPerDeudor.Contains(deudorPago.Caja)) { deudor.cajasPerDeudor.Add(deudorPago.Caja); }
                        }
                    }
                }
                _ = context.globalDb.SaveChanges();
            }
            #endregion // Update Add-DeudorForCaja


            #region Update Separated-Deudas
            ObservableCollection<deudaModel> deudas = context.globalDb.deudas.Local.ToObservableCollection();
            if (deudas.Count == 0)
            {
                foreach (ventaModel venta in ventas)
                {
                    if (venta.Deudor != null)
                    {
                        deudaModel tempDeuda = new deudaModel
                        {
                            Deudor = venta.Deudor,
                            FechaSacado = venta.Fecha,
                            Hora = venta.Hora,
                            Venta = venta
                        };
                        bool tempIsPagado = true;
                        fechaModel tempFechaPagado = null;

                        foreach (ventaProductoModel ventaProducto in venta.VentaProductosPerVenta)
                        {
                            deudaProductoModel tempDeudaProducto = new deudaProductoModel
                            {
                                CantidadAdeudada = ventaProducto.CantidadDeuda,
                                CantidadFaltante = ventaProducto.CantidadFaltante,
                                Precio = ventaProducto.Precio,
                                PrecioPagado = ventaProducto.PrecioPagado,
                                Producto = ventaProducto.Producto
                            };
                            if (ventaProducto.CantidadFaltante > 0) { tempIsPagado = false; }
                            else
                            {
                                if (tempFechaPagado != null && ventaProducto.FechaPagado != null)
                                {
                                    tempFechaPagado = ventaProducto.FechaPagado;
                                }
                            }

                            tempDeuda.deudaProductosPerDeuda.Add(tempDeudaProducto);
                        }
                        if (tempIsPagado)
                        {
                            if (tempFechaPagado == null)
                            {
                                try { tempFechaPagado = venta.Deudor.cajasPerDeudor.Last().Fecha; } catch { }
                            }
                            
                            tempDeuda.FechaPagado = tempFechaPagado;
                        }
                        tempDeuda.TotalPagado = tempDeuda.deudaProductosPerDeuda.Sum(x => x.PrecioPagado * (x.CantidadAdeudada - x.CantidadFaltante));

                        venta.Deudor.deudasPerDeudor.Add(tempDeuda);
                    }
                }
                _ = context.globalDb.SaveChanges();
            }
            #endregion // Update Separated-Deudas
        }
    }
}
