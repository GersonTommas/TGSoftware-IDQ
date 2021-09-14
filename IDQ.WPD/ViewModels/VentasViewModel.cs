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
        void helperClearProductoVenta() { if (newVentaProducto == null || newVentaProducto.Producto != null) { newVentaProducto = new ventaProductoModel() { Cantidad = 1 }; } helperClearTries(); }
        void helperClearTries() { ventaFallo = false; _failedCodigo = ""; }


        void helperFindProducto(object sender = null)
        {
            string _tempInputCodigo = inputCodigo.Trim();

            productoModel tempProd = null;
            try
            { tempProd = context.globalDb.productos.Local.Single(x => x.Codigo.ToLower() == _tempInputCodigo.ToLower()); } catch { }


            if (tempProd != null)
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
                    if (Shared.GlobalVars.messageError.NewProduct())
                    {
                        Shared.Navigators.UpdateEditorSlider(new Helpers.productoNewEditViewModel(_tempInputCodigo));
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
            { duplicate = newVenta.VentaProductosPerVenta.Single(x => x.Producto == newVentaProducto.Producto); } catch { }

            if (duplicate != null)
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

        void helperGuardarVenta()
        {

        }

        void helperGuardarVentaEfectivoExacto()
        {
            newVenta.Caja = new cajaModel() { Efectivo = newVenta.PrecioTotal, Fecha = Shared.GlobalVars.returnFecha(), Hora = Shared.GlobalVars.strHora, MercadoPago = 0, Vuelto = 0 };
            newVenta.Deudor = null;

            internalContabilizarVenta();

            context.globalDb.ventas.Local.Add(newVenta);
            _ = context.globalDb.SaveChanges();
            helperResetEverything();
        }

        void internalContabilizarVenta()
        {
            foreach (ventaProductoModel prod in newVenta.VentaProductosPerVenta)
            {
                prod.Producto.Stock -= prod.Cantidad;
                prod.PrecioPagado = prod.Precio;
                prod.FechaPagado = newVenta.Fecha;
            }

            newVenta.Fecha = newVenta.Caja.Fecha;
            newVenta.Hora = newVenta.Caja.Hora;
            newVenta.Usuario = Shared.GlobalVars.usuarioLogueado;

            context.globalCajaActual.Efectivo += newVenta.Caja.Efectivo;
        }

        bool checkAddProductoVenta => newVentaProducto.Producto != null && newVentaProducto.Cantidad > 0 && isItSafe;

        bool checkGuardarVenta => newVenta != null && newVenta.VentaProductosPerVenta.Count > 0 && isItSafe;

        bool isItSafe => Shared.Navigators.ContentTopNavigator.CurrentViewModel == null;
        #endregion // Helpers


        #region Commands
        public Command textBoxCommandFindProducto => new Command(
            (object parameter) => helperFindProducto(parameter),
            (object parameter) => !string.IsNullOrWhiteSpace(inputCodigo));


        public Command textBoxCommandAddProductoVenta => new Command(
            (object parameter) => helperAddProductoVenta(parameter),
            (object parameter) => checkAddProductoVenta);


        public Command dataGridCommandRemoveProductoVenta => new Command(
            (object parameter) => helperRemoveProductoVenta(parameter),
            (object parameter) => selectedVentaProducto != null);

        public Command ControlCommandPagarVenta => new Command(
            (object parameter) => { helperGuardarVenta(); },
            (object parameter) => checkGuardarVenta);

        public Command ControlCommandGuardarVentaEfectivoExacto => new Command(
            (object parameter) => helperGuardarVentaEfectivoExacto(),
            (object parameter) => checkGuardarVenta);

        public Command resultCommandCancelar => new Command(
            (object parameter) => helperResetEverything(),
            (object parameter) => isItSafe);
        #endregion // Commands
    }
}
