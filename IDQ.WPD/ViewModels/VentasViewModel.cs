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

        string _inputCodigo;
        public string inputCodigo { get => _inputCodigo; set { if (SetProperty(ref _inputCodigo, value)) { OnPropertyChanged(); helperClearProductoVenta(); } } }


        string _failedCodigo;
        #endregion // Variables


        #region Helpers
        void helperResetEverything() { newVenta = new ventaModel(); helperClearProductoVenta(); }
        void helperClearProductoVenta() { newVentaProducto = new ventaProductoModel() { Cantidad = 1 }; helperClearTries(); }
        void helperClearTries() { ventaFallo = false; inputCodigo = ""; }


        void helperFindProducto(object sender = null)
        {
            try
            {
                productoModel tempProd = context.globalDb.productos.Local.Single(x => x.Codigo.ToLower() == inputCodigo.ToLower());
                newVentaProducto.Producto = tempProd;
                newVentaProducto.Precio = tempProd.PrecioActual;

                if (newVentaProducto.Cantidad < 1) { Shared.GlobalVars.nextTarget(sender); }
                helperClearTries();
                //OnPropertyChanged(nameof(newVentaProducto));
            }
            catch
            {
                newVentaProducto.Producto = null;
                if (!string.IsNullOrWhiteSpace(_failedCodigo) && _failedCodigo.ToLower() == inputCodigo.ToLower())
                {
                    if (Shared.GlobalVars.messageError.NewProduct())
                    {
                        /*
                        if (gOpenAddProducto(strCodigo))
                        {
                            helperSearchProduct(sender);
                        }*/
                    }
                }
                else
                {
                    _failedCodigo = inputCodigo;
                    try { (sender as TextBox).SelectAll(); } catch { }
                }
            }
        }

        void helperAddProductoVenta()
        {
            try
            {
                ventaProductoModel duplicate = newVenta.VentaProductosPerVenta.Single(x => x.Producto == newVentaProducto.Producto);
                duplicate.Cantidad += newVentaProducto.Cantidad;
            }
            catch
            {
                newVenta.VentaProductosPerVenta.Add(newVentaProducto);
            }

            newVentaProducto.Producto.Agregado = true;
            newVenta.PrecioTotal += newVentaProducto.PrecioTotal;
            helperClearProductoVenta();
        }
        void helperRemoveProductoVenta(object sentParameter)
        {
            if (sentParameter is ventaProductoModel tempVentaProducto)
            {
                _ = newVenta.VentaProductosPerVenta.Remove(tempVentaProducto);
            }
        }

        bool checkAddProductoVenta()
        {
            return newVentaProducto.Producto != null && newVentaProducto.Cantidad > 0;
        }

        bool helperGuardarVenta()
        {
            return true;
        }
        bool checkGuardarVenta()
        {
            return true;
        }
        #endregion // Helpers


        #region Commands
        public Command textBoxCommandFindProducto => new Command(
            (object parameter) => { },
            (object parameter) => true);


        public Command textBoxCommandAddProductoVenta => new Command(
            (object parameter) => helperAddProductoVenta(),
            (object parameter) => checkAddProductoVenta());


        public Command dataGridCommandRemoveProductoVenta => new Command(
            (object parameter) => { helperRemoveProductoVenta(parameter); },
            (object parameter) => { return true; });


        public Command resultCommandCancelar => new Command((object parameter) => helperResetEverything());
        #endregion // Commands
    }
}
