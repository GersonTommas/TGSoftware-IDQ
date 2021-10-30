using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Linq;
using System.Windows.Controls;

namespace IDQ.WPF.ViewModels
{
    public class VentasViewModel : Base.ViewModelBase
    {
        #region Initialize
        public VentasViewModel() { helperResetEverything(); }
        #endregion // Initialize


        #region Variables
        ventaModel _newVenta;
        public ventaModel newVenta { get => _newVenta; set { if (SetProperty(ref _newVenta, value)) { OnPropertyChanged(); } } }

        bool _ventaFallo;
        public bool ventaFallo { get => _ventaFallo; set { if (SetProperty(ref _ventaFallo, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(windowBackground)); } } }
        public string windowBackground => !ventaFallo ? Shared.GlobalVars.colorWindowBackgroundOK : Shared.GlobalVars.colorWindowBackkgroundNO;


        ventaProductoModel _newVentaProducto;
        public ventaProductoModel newVentaProducto { get => _newVentaProducto; set { if (SetProperty(ref _newVentaProducto, value)) { OnPropertyChanged(); } } }

        ventaProductoModel _selectedVentaProducto;
        public ventaProductoModel selectedVentaProducto { get => _selectedVentaProducto; set { if (SetProperty(ref _selectedVentaProducto, value)) { OnPropertyChanged(); } } }

        string _inputCodigo;
        public string inputCodigo { get => _inputCodigo; set { if (SetProperty(ref _inputCodigo, value)) { OnPropertyChanged(); helperClearProductoVenta(); } } }


        string _failedCodigo;
        #endregion // Variables


        #region Helpers
        void helperResetEverything() { newVenta = new ventaModel(); helperClearProductoVenta(); }
        void helperClearProductoVenta() { if (newVentaProducto is null || newVentaProducto.Producto is not null) { newVentaProducto = new ventaProductoModel() { Cantidad = 1 }; } helperClearTries(); }
        void helperClearTries() { ventaFallo = false; _failedCodigo = ""; }


        void helperFindProducto(object sender = null)
        {
            string _tempInputCodigo = inputCodigo.Trim();

            productoModel tempProd = null;

            try { tempProd = context.globalDb.productos.Local.Single(x => x.Codigo.ToLower() == _tempInputCodigo.ToLower()); } catch { }


            if (tempProd is not null)
            {
                newVentaProducto.Producto = tempProd;
                newVentaProducto.Precio = tempProd.PrecioActual;

                if (newVentaProducto.Cantidad < 1) { Shared.GlobalVars.nextTarget(sender); }
                else if (checkAddProductoVenta) { helperAddProductoVenta(sender); }
                helperClearTries();
            }
            else
            {
                newVentaProducto.Producto = null;
                if (!string.IsNullOrWhiteSpace(_failedCodigo) && _failedCodigo.ToLower() == _tempInputCodigo.ToLower())
                {
                    if (Shared.GlobalErrors.NewProduct())
                    {
                        Shared.Navigators.ContentTopNavigator.updateNavigator(new Helpers.productoNewEditViewModel(_tempInputCodigo));
                    }
                }
                else
                {
                    _failedCodigo = _tempInputCodigo;
                    try { (sender as TextBox).SelectAll(); } catch { }
                }
            }
        }

        void helperAddProductoVenta(object sender)
        {
            ventaProductoModel duplicate = null;

            try
            { duplicate = newVenta.VentaProductosPerVenta.Single(x => x.Producto == newVentaProducto.Producto); }
            catch { }

            if (duplicate is not null)
            {
                duplicate.Cantidad += newVentaProducto.Cantidad;
            }
            else
            {
                newVenta.VentaProductosPerVenta.Add(newVentaProducto);
            }

            newVentaProducto.Producto.Agregado = true;
            newVenta.PrecioTotal += newVentaProducto.PrecioTotal;
            inputCodigo = "";
            helperClearProductoVenta();
        }

        void helperRemoveProductoVenta(object sentParameter)
        {
            if (sentParameter is ventaProductoModel tempVentaProducto)
            {
                newVenta.PrecioTotal -= tempVentaProducto.PrecioTotal;
                if (newVenta.PrecioTotal < 0) { newVenta.PrecioTotal = 0; }
                _ = newVenta.VentaProductosPerVenta.Remove(tempVentaProducto);
            }
        }

        void helperPagarVenta()
        {
            Shared.Navigators.ContentTopNavigator.updateNavigator(new Helpers.pagarVentaViewModel(this));
        }

        public void helperGuardarVenta(cajaModel sentCaja, deudorModel sentDeudor, bool isPagarDeuda)
        {
            newVenta.Caja = sentCaja;
            internalContabilizarVenta();

            if (sentDeudor is null)
            {
                context.globalCajaActual.Efectivo -= newVenta.Caja.Vuelto;
            }
            else
            {
                decimal tempCobrado = sentCaja.Efectivo + sentCaja.MercadoPago + sentDeudor.Resto;

                if (tempCobrado >= newVenta.PrecioTotal)
                {
                    tempCobrado -= newVenta.PrecioTotal;
                    sentDeudor.Resto = tempCobrado;
                }
                else
                {
                    deudaModel newDeuda = new deudaModel();

                    foreach (ventaProductoModel prod in newVenta.VentaProductosPerVenta)
                    {
                        if (tempCobrado > prod.PrecioTotal)
                        {
                            tempCobrado -= prod.PrecioTotal;
                        }
                        else
                        {
                            int tempCantidad = prod.Cantidad;

                            for (int i = 0; i < prod.Cantidad; i++)
                            {
                                if (tempCobrado > prod.Precio)
                                {
                                    tempCobrado -= prod.Precio;
                                    tempCantidad -= 1;
                                }
                            }

                            if (newDeuda.Deudor is null)
                            {
                                newDeuda.Deudor = sentDeudor;
                                newDeuda.FechaSacado = newVenta.Fecha;
                                newDeuda.Hora = newVenta.Hora;
                            }

                            newDeuda.deudaProductosPerDeuda.Add(new deudaProductoModel() { CantidadAdeudada = tempCantidad, CantidadFaltante = tempCantidad, Precio = prod.Precio, Producto = prod.Producto, Deudor = sentDeudor });
                            sentDeudor.deudasPerDeudor.Add(newDeuda);
                        }
                    }

                    newVenta.Deudor = sentDeudor;
                    newVenta.DeudaForVenta = newDeuda;
                }


                if (isPagarDeuda)
                {
                    if (tempCobrado > 0)
                    {
                        deudorPagoModel newDeudorPago = new deudorPagoModel() { Caja = newVenta.Caja, Deudor = sentDeudor, Fecha = newVenta.Fecha };

                        tempCobrado = sentDeudor.updatePagarAllDeudas(tempCobrado, newVenta.Fecha);

                        newVenta.Caja.Vuelto = tempCobrado;
                        context.globalCajaActual.Efectivo -= newVenta.Caja.Vuelto;
                        context.globalDb.deudorPagos.Local.Add(newDeudorPago);
                    }
                }
                else
                {
                    context.globalCajaActual.Efectivo -= newVenta.Caja.Vuelto;
                }

                newVenta.Deudor = sentDeudor;
            }

            context.globalDb.ventas.Local.Add(newVenta);
            _ = context.globalDb.SaveChanges();

            helperResetEverything();
        }

        void helperGuardarVentaEfectivoExacto()
        {
            newVenta.Caja = new cajaModel() { Efectivo = newVenta.PrecioTotal, Fecha = Shared.GlobalVars.returnFecha(), Hora = globalStringHora, MercadoPago = 0, Vuelto = 0 };
            newVenta.Deudor = null;

            internalContabilizarVenta(true);

            context.globalDb.ventas.Local.Add(newVenta);
            _ = context.globalDb.SaveChanges();
            helperResetEverything();
        }

        void internalContabilizarVenta(bool isCambioExacto = false)
        {
            foreach (ventaProductoModel prod in newVenta.VentaProductosPerVenta)
            {
                prod.Producto.Stock -= prod.Cantidad;
                prod.Precio = prod.Producto.PrecioActual;
            }

            newVenta.Fecha = newVenta.Caja.Fecha;
            newVenta.Hora = newVenta.Caja.Hora;
            newVenta.Usuario = Shared.GlobalVars.usuarioLogueado;

            context.globalCajaActual.Efectivo += newVenta.Caja.Efectivo;
            context.globalCajaActual.MercadoPago += newVenta.Caja.MercadoPago;
        }

        bool checkAddProductoVenta => newVentaProducto.Producto is not null && newVentaProducto.Cantidad > 0 && isItSafe;

        bool checkGuardarVenta => newVenta is not null && newVenta.VentaProductosPerVenta.Count > 0 && isItSafe;

        bool isItSafe => Shared.Navigators.ContentTopNavigator.CurrentViewModel is null;
        #endregion // Helpers


        #region Commands
        public Command buttonCommandOpenBuscador => new Command(
            (object parameter) => { HelperFullWindow buscador = new HelperFullWindow(); if (buscador.ShowDialog() == true) { if (buscador.resultProducto is not null) { inputCodigo = buscador.resultProducto.Codigo; newVentaProducto.Cantidad = buscador.resultCantidad; helperFindProducto(); } } });


        public Command textBoxCommandFindProducto => new Command(
            (object parameter) => helperFindProducto(parameter),
            (object parameter) => !string.IsNullOrWhiteSpace(inputCodigo));


        public Command textBoxCommandAddProductoVenta => new Command(
            (object parameter) => helperAddProductoVenta(parameter),
            (object parameter) => checkAddProductoVenta);

        public Command textBoxCommandUpCantidad => new Command(
            (object parameter) => { if (newVentaProducto.Cantidad < 1) { newVentaProducto.Cantidad = 1; } else { newVentaProducto.Cantidad++; } });

        public Command textBoxCommandDnCantidad => new Command(
            (object parameter) => { if (newVentaProducto.Cantidad < 2) { newVentaProducto.Cantidad = 1; } else { newVentaProducto.Cantidad--; } });

        public Command dataGridCommandRemoveProductoVenta => new Command(
            (object parameter) => helperRemoveProductoVenta(selectedVentaProducto),
            (object parameter) => selectedVentaProducto is not null);

        public Command controlCommandPagarVenta => new Command(
            (object parameter) => helperPagarVenta(),
            (object parameter) => checkGuardarVenta);

        public Command controlCommandGuardarVentaEfectivoExacto => new Command(
            (object parameter) => helperGuardarVentaEfectivoExacto(),
            (object parameter) => checkGuardarVenta);

        public Command resultCommandCancelar => new Command(
            (object parameter) => helperResetEverything(),
            (object parameter) => isItSafe);
        #endregion // Commands
    }
}
