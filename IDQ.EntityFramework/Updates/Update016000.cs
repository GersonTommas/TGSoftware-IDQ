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
            #region Update 20210910013623_ventas-preciototal
            ObservableCollection<ventaModel> ventas = context.globalDb.ventas.Local.ToObservableCollection();
            if (ventas.All(x => x.PrecioTotal == 0))
            {
                foreach (ventaModel venta in ventas)
                {
                    venta.PrecioTotal = Math.Round(venta.VentaProductosPerVenta.Sum(x => x.PrecioTotal), 2);
                }
            }
            #endregion // Update 20210910013623_ventas-preciototal


            #region Update 20210911170945_deudorPagos-Added
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
                            if (deudaPago.Deudor is null)
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
                        if (deudaPago.Deudor is not null)
                        {
                            context.globalDb.deudorPagos.Local.Add(deudaPago);
                            _ = context.globalDb.SaveChanges();
                        }
                    }
                }
            }
            #endregion // Update 20210911170945_deudorPagos-Added

            /*
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
            */

            #region // Update Add-Ingreso-PrecioTotal
            ObservableCollection<ingresoModel> ingresos = context.globalDb.ingresos.Local.ToObservableCollection();
            if (ingresos.All(x => x.PrecioTotal == 0))
            {
                foreach (ingresoModel ingreso in ingresos)
                {
                    ingreso.PrecioTotal = Math.Round(ingreso.IngresoProductosPerIngreso.Sum(x => x.PrecioTotal), 2);
                }
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
            }
            #endregion // Update Add-DeudorForCaja


            #region Update Separated-Deudas
            ObservableCollection<deudaModel> deudas = context.globalDb.deudas.Local.ToObservableCollection();
            if (deudas.Count == 0)
            {
                foreach (ventaModel venta in ventas)
                {
                    if (venta.Deudor is not null)
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
                                if (tempFechaPagado is not null && ventaProducto.FechaPagado is not null)
                                {
                                    tempFechaPagado = ventaProducto.FechaPagado;
                                }
                            }

                            tempDeuda.deudaProductosPerDeuda.Add(tempDeudaProducto);
                        }
                        if (tempIsPagado)
                        {
                            if (tempFechaPagado is null)
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


            #region Update 20210929025647 usuarioModel Added-FechaModels
            ObservableCollection<usuarioModel> usuarios = context.globalDb.usuarios.Local.ToObservableCollection();
            if (usuarios.All(x => x.FechaDeIngreso is null))
            {
                foreach (usuarioModel usuario in usuarios)
                {
                    if (usuario.FechaIngreso is not null)
                    {
                        usuario.FechaDeIngreso = context.returnFecha(usuario.FechaIngreso);
                    }

                    if (usuario.FechaSalida is not null)
                    {
                        usuario.FechaDeEgreso = context.returnFecha(usuario.FechaSalida);
                    }

                }
            }
            #endregion // Update 20210929025647 usuarioModel Added-FechaModels


            #region Update Conteos
            IOrderedEnumerable<cajaConteoModel> cajaConteos = context.globalDb.cajaConteos.Local.OrderBy(x => x.CajaID);
            if (!context.globalDb.conteos.Any())
            {
                foreach (cajaConteoModel exConteo in cajaConteos)
                {
                    conteoModel tempConteo = null;

                    try { tempConteo = context.globalDb.conteos.Single(x => x.Usuario == exConteo.Usuario && x.CajaSalida == null); } catch { }

                    if (tempConteo is not null)
                    {
                        if (exConteo.Detalle == "1")
                        {
                            if (exConteo.Caja.Fecha == tempConteo.Fecha)
                            {
                                tempConteo.CajaSalida = new pseudoCajaModel()
                                {
                                    CajaEfectivo = exConteo.Caja.Efectivo,
                                    Efectivo = exConteo.Caja.MercadoPago,
                                    Fecha = exConteo.Caja.Fecha,
                                    Hora = exConteo.Caja.Hora
                                };
                            }
                            else
                            {
                                tempConteo.CajaSalida = new pseudoCajaModel()
                                {
                                    AgregadoEfectivo = tempConteo.CajaEntrada.AgregadoEfectivo,
                                    AgregadoMercadoPago = tempConteo.CajaEntrada.AgregadoMercadoPago,
                                    CajaEfectivo = tempConteo.CajaEntrada.CajaEfectivo,
                                    CajaMercadoPago = tempConteo.CajaEntrada.CajaMercadoPago,
                                    Efectivo = tempConteo.CajaEntrada.Efectivo,
                                    Fecha = tempConteo.CajaEntrada.Fecha,
                                    Hora = tempConteo.CajaEntrada.Hora,
                                    MercadoPago = tempConteo.CajaEntrada.MercadoPago,
                                    Detalles = "AUTOMATICO - Sin Cierre Encontrado."
                                };

                                conteoModel newConteo = new conteoModel()
                                {
                                    Fecha = exConteo.Caja.Fecha,
                                    Usuario = exConteo.Usuario,
                                    CajaEntrada = new pseudoCajaModel()
                                    {
                                        CajaEfectivo = exConteo.Caja.Efectivo,
                                        Efectivo = exConteo.Caja.MercadoPago,
                                        Fecha = exConteo.Caja.Fecha,
                                        Hora = exConteo.Caja.Hora,
                                        Detalles = "AUTOMATICO - Sin Apertura Encontrada."
                                    },
                                    CajaSalida = new pseudoCajaModel()
                                    {
                                        CajaEfectivo = exConteo.Caja.Efectivo,
                                        Efectivo = exConteo.Caja.MercadoPago,
                                        Fecha = exConteo.Caja.Fecha,
                                        Hora = exConteo.Caja.Hora
                                    }
                                };
                                context.globalDb.conteos.Local.Add(newConteo);
                            }
                        }
                        else
                        {
                            tempConteo.CajaSalida = new pseudoCajaModel()
                            {
                                AgregadoEfectivo = tempConteo.CajaEntrada.AgregadoEfectivo,
                                AgregadoMercadoPago = tempConteo.CajaEntrada.AgregadoMercadoPago,
                                CajaEfectivo = tempConteo.CajaEntrada.CajaEfectivo,
                                CajaMercadoPago = tempConteo.CajaEntrada.CajaMercadoPago,
                                Efectivo = tempConteo.CajaEntrada.Efectivo,
                                Fecha = tempConteo.CajaEntrada.Fecha,
                                Hora = tempConteo.CajaEntrada.Hora,
                                MercadoPago = tempConteo.CajaEntrada.MercadoPago,
                                Detalles = "AUTOMATICO - Sin Cierre Encontrado."
                            };

                            conteoModel newConteo = new conteoModel()
                            {
                                Usuario = exConteo.Usuario,
                                Fecha = exConteo.Caja.Fecha,
                                CajaEntrada = new pseudoCajaModel()
                                {
                                    Fecha = exConteo.Caja.Fecha,
                                    Hora = exConteo.Caja.Hora,
                                    CajaEfectivo = exConteo.Caja.Efectivo,
                                    Efectivo = exConteo.Caja.MercadoPago
                                }
                            };
                            context.globalDb.conteos.Local.Add(newConteo);
                        }
                    }
                    else
                    {
                        if (exConteo.Detalle == "1")
                        {
                            tempConteo = new conteoModel()
                            {
                                Fecha = exConteo.Caja.Fecha,
                                Usuario = exConteo.Usuario,
                                CajaEntrada = new pseudoCajaModel()
                                {
                                    CajaEfectivo = exConteo.Caja.Efectivo,
                                    Efectivo = exConteo.Caja.MercadoPago,
                                    Fecha = exConteo.Caja.Fecha,
                                    Hora = exConteo.Caja.Hora,
                                    Detalles = "AUTOMATICO - Solo CIERRE."
                                },
                                CajaSalida = new pseudoCajaModel()
                                {
                                    CajaEfectivo = exConteo.Caja.Efectivo,
                                    Efectivo = exConteo.Caja.MercadoPago,
                                    Fecha = exConteo.Caja.Fecha,
                                    Hora = exConteo.Caja.Hora
                                }
                            };
                            context.globalDb.conteos.Local.Add(tempConteo);
                        }
                        else
                        {
                            tempConteo = new conteoModel()
                            {
                                Fecha = exConteo.Caja.Fecha,
                                Usuario = exConteo.Usuario,
                                CajaEntrada = new pseudoCajaModel()
                                {
                                    CajaEfectivo = exConteo.Caja.Efectivo,
                                    Efectivo = exConteo.Caja.MercadoPago,
                                    Fecha = exConteo.Caja.Fecha,
                                    Hora = exConteo.Caja.Hora
                                }
                            };
                            context.globalDb.conteos.Local.Add(tempConteo);
                        }
                    }
                    _ = context.globalDb.SaveChanges();
                }
            }
            #endregion // Update Conteos

            _ = context.globalDb.SaveChanges();
        }
    }
}
