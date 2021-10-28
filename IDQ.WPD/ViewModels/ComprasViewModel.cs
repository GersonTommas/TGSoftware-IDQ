using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace IDQ.WPF.ViewModels
{
    public class ComprasViewModel : Base.ViewModelBase
    {
        #region Initialize
        public ComprasViewModel()
        {
            _searchTimer.Tick += new EventHandler(searchTimer_Click); _searchTimer.Interval = new TimeSpan(0, 0, 0, 0, 150);

            try
            {

                buscCollectionViewSourceProductos.SortDescriptions.Clear(); buscCollectionViewSourceProductos.SortDescriptions.Add(new SortDescription(nameof(productoModel.Descripcion), ListSortDirection.Ascending));
                buscCollectionViewSourceProductos.Filter = delegate (object item)
                {
                    productoModel tempItem = item as productoModel;
                    if (buscCheckBoxStockIsChecked == true && tempItem.Stock < 1) { return false; }
                    else if (buscCheckBoxStockIsChecked == false && tempItem.Stock > 0) { return false; }

                    if (buscCheckBoxIsActivoIsChecked == true && !tempItem.Activo) { return false; }
                    else if (buscCheckBoxIsActivoIsChecked == false && tempItem.Activo) { return false; }


                    if (localBoolDescripcionCodigo)
                    { if (!String.IsNullOrWhiteSpace(buscStringToSearch) && !tempItem.Descripcion.Contains(buscStringToSearch, StringComparison.OrdinalIgnoreCase)) { return false; } }
                    else { if (!String.IsNullOrWhiteSpace(buscStringToSearch) && !tempItem.Codigo.Contains(buscStringToSearch, StringComparison.OrdinalIgnoreCase)) { return false; } }
                    return true;
                };
            }
            catch { }
        }
        #endregion // Initialize



        #region Shared
        // Properties
        ingresoModel _newIngreso = new ingresoModel();
        public ingresoModel newIngreso { get => _newIngreso; set { if (SetProperty(ref _newIngreso, value)) { OnPropertyChanged(); } } }



        // Cleaners
        void cleanerIngreso()
        {
            newIngreso = new ingresoModel();
            foreach (productoModel producto in context.globalAllProductos.Where(x => x.CantidadIngresado > 0))
            {
                producto.CantidadIngresado = 0;
            }
        }



        // Helpers
        public void helperPagar(proveedorModel sentProveedor, Decimal sentEfectivo, Decimal sentMP, Decimal sentVuelto)
        {

            fechaModel newFecha = Shared.GlobalVars.returnFecha();
            String newHora = globalStringHora;
            newIngreso.Usuario = Shared.GlobalVars.usuarioLogueado;

            foreach (ingresoProductoModel iProducto in newIngreso.IngresoProductosPerIngreso)
            {
                iProducto.Producto.PrecioIngreso = iProducto.PrecioPagado;
                iProducto.Producto.PrecioActual = iProducto.PrecioActual;
                iProducto.Producto.Stock += iProducto.Cantidad;
            }

            newIngreso.Proveedor = sentProveedor;

            if (sentEfectivo > 0 || sentMP > 0)
            {

                cajaModel newCaja = new cajaModel()
                {
                    Fecha = newFecha,
                    Hora = newHora,
                    Efectivo = sentEfectivo,
                    MercadoPago = sentMP
                };

                if (sentVuelto > 0)
                {
                    newCaja.Vuelto = sentVuelto;
                }
            }

            context.globalCajaActual.Efectivo -= sentEfectivo;
            context.globalCajaActual.MercadoPago -= sentMP;

            newIngreso.Fecha = newFecha;
            newIngreso.Hora = newHora;

            //newIngreso.PagadoMP = sentMP;
            //newIngreso.PagadoPesos = sentEfectivo;

            if (sentVuelto > 0)
            {
                //newIngreso.PagadoPesos -= sentVuelto;
                context.globalCajaActual.Efectivo += sentVuelto;
            }

            context.globalDb.ingresos.Local.Add(newIngreso);
            _ = context.globalDb.SaveChanges();

            cleanerIngreso();
        }


        void helperNuevoProducto(string sentCodigo = null)
        {
            if (sentCodigo is null || string.IsNullOrWhiteSpace(sentCodigo))
            {
                Shared.Navigators.ContentTopNavigator.updateNavigator(new Helpers.productoNewEditViewModel());
            }
            else
            {
                Shared.Navigators.ContentTopNavigator.updateNavigator(new Helpers.productoNewEditViewModel(sentCodigo));
            }
        }

        void helperGuardarIngreso()
        {
            /*
            fechaModel tempFechaActual = Shared.GlobalVars.returnFecha();
            string tempHoraActual = globalStringHora;


            newIngreso.Fecha = tempFechaActual;
            newIngreso.Hora = tempHoraActual;
            newIngreso.Usuario = Shared.GlobalVars.usuarioLogueado;

            foreach (ingresoProductoModel iProducto in newIngreso.IngresoProductosPerIngreso)
            {
                iProducto.Producto.PrecioIngreso = iProducto.PrecioPagado;
                iProducto.Producto.PrecioActual = iProducto.PrecioActual;
                iProducto.Producto.Stock += iProducto.Cantidad;
            }

            context.globalDb.ingresos.Local.Add(newIngreso);
            _ = context.globalDb.SaveChanges();

            cleanerIngreso();
            */

            Shared.Navigators.ContentTopNavigator.updateNavigator(new Helpers.pagarCompraViewModel(this));
        }



        // Checkers
        bool checkGuardarIngreso => newIngreso?.IngresoProductosPerIngreso.Count > 0;



        // Commands
        public Command ControlCommandNuevoProducto => new Command(
            (object parameter) => helperNuevoProducto());


        public Command ControlCommandGuardarIngreso => new Command(
            (object parameter) => helperGuardarIngreso(),
            (object parameter) => checkGuardarIngreso);
        #endregion // Shared



        #region Buscador
        // Timer
        readonly System.Windows.Threading.DispatcherTimer _searchTimer = new System.Windows.Threading.DispatcherTimer();

        void searchTimer_Click(object sender, EventArgs e)
        {
            buscCollectionViewSourceProductos.Refresh();
            if (_buscCollectionSourceProductos.View.Cast<object>().Count() == 1) { _ = buscCollectionViewSourceProductos.MoveCurrentToFirst(); _isOnlyOneProducto = true; } else { _isOnlyOneProducto = false; }

            _searchTimer.Stop();
        }

        void searchTimerRestart() { _searchTimer.Stop(); _searchTimer.Start(); }



        // Properties
        readonly CollectionViewSource _buscCollectionSourceProductos = new CollectionViewSource() { Source = context.globalAllProductos };
        public ICollectionView buscCollectionViewSourceProductos => _buscCollectionSourceProductos.View;

        bool _isOnlyOneProducto;

        bool _localBoolDescripcionCodigo = true;
        public bool localBoolDescripcionCodigo { get => _localBoolDescripcionCodigo; set { if (SetProperty(ref _localBoolDescripcionCodigo, value)) { OnPropertyChanged(); searchTimerRestart(); } } }

        public string buscButtonContent => localBoolDescripcionCodigo ? "Descripcion" : "Codigo";

        bool? _buscCheckBoxStockIsChecked;
        public bool? buscCheckBoxStockIsChecked { get => _buscCheckBoxStockIsChecked; set { if (SetProperty(ref _buscCheckBoxStockIsChecked, value)) { OnPropertyChanged(); searchTimerRestart(); } } }

        public string buscCheckBoxStockContent => buscCheckBoxStockIsChecked is null ? "Con/Sin Stock" : buscCheckBoxStockIsChecked == true ? "Con Stock" : "Sin Stock";

        bool? _buscCheckBoxIsActivoIsChecked;
        public bool? buscCheckBoxIsActivoIsChecked { get => _buscCheckBoxIsActivoIsChecked; set { if (SetProperty(ref _buscCheckBoxIsActivoIsChecked, value)) { OnPropertyChanged(); searchTimerRestart(); } } }

        public string buscCheckBoxIsActivoContent => buscCheckBoxIsActivoIsChecked is null ? "Activo/Inactivo" : buscCheckBoxIsActivoIsChecked == true ? "Activo" : "Inactivo";

        string _buscStringToSearch;
        public string buscStringToSearch { get => _buscStringToSearch; set { if (SetProperty(ref _buscStringToSearch, value)) { OnPropertyChanged(); searchTimerRestart(); } } }

        productoModel _buscDGSelectedProducto;
        public productoModel buscDGSelectedProducto { get => _buscDGSelectedProducto; set { if (SetProperty(ref _buscDGSelectedProducto, value)) { OnPropertyChanged(); } } }



        // Helpers
        void heleperDeleteIngresoProducto()
        {
            try
            {
                ingresoProductoModel tempIngresoProducto = newIngreso.IngresoProductosPerIngreso.Single(x => x.Producto == buscDGSelectedProducto);
                tempIngresoProducto.Producto.CantidadIngresado = 0;

                _ = newIngreso.IngresoProductosPerIngreso.Remove(tempIngresoProducto);

                newIngreso.updateModel();
            }
            catch { }
        }

        void helperBuscAgregarIngresoProducto()
        {
            ingresoProductoModel tempIngresoProducto = null;
            try { tempIngresoProducto = newIngreso.IngresoProductosPerIngreso.Single(x => x.Producto == buscDGSelectedProducto); } catch { }


            HelperWindow inputWindow = tempIngresoProducto is not null
                ? new HelperWindow(buscDGSelectedProducto.CantidadIngresado, tempIngresoProducto.PrecioPagado, tempIngresoProducto.PrecioActual)
                : new HelperWindow(buscDGSelectedProducto.CantidadIngresado, buscDGSelectedProducto.PrecioIngreso, buscDGSelectedProducto.PrecioActual);


            if (inputWindow.ShowDialog() == true)
            {
                if (tempIngresoProducto is not null)
                {
                    tempIngresoProducto.Cantidad = inputWindow.cantidad;
                    tempIngresoProducto.PrecioPagado = inputWindow.precioCompra;
                    tempIngresoProducto.PrecioActual = inputWindow.precioVenta;
                }
                else
                {
                    newIngreso.IngresoProductosPerIngreso.Add(new ingresoProductoModel() { Producto = buscDGSelectedProducto, Cantidad = inputWindow.cantidad, PrecioActual = inputWindow.precioVenta, PrecioPagado = inputWindow.precioCompra });
                }
                buscDGSelectedProducto.CantidadIngresado = inputWindow.cantidad;
                newIngreso.updateModel();
            }
        }



        // Commands
        public Command buscButtonCommand => new Command((object parameter) => localBoolDescripcionCodigo = !localBoolDescripcionCodigo);

        public Command buscIsOnlyOneCommand => new Command(
            (object parameter) => { helperBuscAgregarIngresoProducto(); },
            (object parameter) => _isOnlyOneProducto && _buscDGSelectedProducto is not null);

        public Command ctrlBuscadorDeleteCommand => new Command(
            (object parameter) => heleperDeleteIngresoProducto(),
            (object parameter) => buscDGSelectedProducto is not null);

        public Command ctrlBuscadorAddCommand => new Command(
            (object parameter) => { helperBuscAgregarIngresoProducto(); },
            (object parameter) => buscDGSelectedProducto is not null);
        #endregion // Buscador



        #region Listado
        // Properties
        ingresoProductoModel _listNewInrgesoProducto = new ingresoProductoModel();
        public ingresoProductoModel listNewIngresoProducto { get => _listNewInrgesoProducto; set { if (SetProperty(ref _listNewInrgesoProducto, value)) { OnPropertyChanged(); } } }

        ingresoProductoModel _listSelectedIngresoProducto;
        public ingresoProductoModel listSelectedIngresoProducto { get => _listSelectedIngresoProducto; set { if (SetProperty(ref _listSelectedIngresoProducto, value)) { OnPropertyChanged(); } } }

        string _listInputCodigo;
        public string listInputCodigo { get => _listInputCodigo; set { if (SetProperty(ref _listInputCodigo, value)) { OnPropertyChanged(); listNewIngresoProducto = new ingresoProductoModel(); } } }

        string _listFailedCodigo = "";



        // Cleaners
        void cleanerTries() { ingresoFallo = false; _listFailedCodigo = ""; }



        // Helpers
        void helperFindProducto(object sender = null)
        {
            string _tempInputCodigo = listInputCodigo.Trim();

            productoModel tempProd = null;

            try { tempProd = context.globalDb.productos.Local.Single(x => bCompareStrings(x.Codigo, _tempInputCodigo)); } catch { }


            if (tempProd is not null)
            {
                ingresoProductoModel tempIngresoProducto = null;
                try { tempIngresoProducto = newIngreso.IngresoProductosPerIngreso.Single(x => x.Producto == tempProd); } catch { }

                listNewIngresoProducto.Producto = tempProd;

                if (tempIngresoProducto is not null)
                {
                    listNewIngresoProducto.Cantidad = tempIngresoProducto.Cantidad;
                    listNewIngresoProducto.PrecioActual = tempIngresoProducto.PrecioActual;
                    listNewIngresoProducto.PrecioPagado = tempIngresoProducto.PrecioPagado;
                }
                else
                {
                    listNewIngresoProducto.PrecioActual = tempProd.PrecioActual;
                    listNewIngresoProducto.PrecioPagado = tempProd.PrecioIngreso;
                }

                Shared.GlobalVars.nextTarget(sender);

                cleanerTries();
            }
            else
            {
                listNewIngresoProducto = new ingresoProductoModel() { Cantidad = 1 };

                if (bCompareStrings(_listFailedCodigo, _tempInputCodigo))
                {
                    if (Shared.GlobalErrors.NewProduct())
                    {
                        helperNuevoProducto(_tempInputCodigo);
                        cleanerTries();
                    }
                }
                else
                {
                    _listFailedCodigo = _tempInputCodigo;
                    try { (sender as TextBox).SelectAll(); } catch { }
                }
            }
        }

        void helperListAgregarIngresoProducto(object sender)
        {
            if (listNewIngresoProducto.Producto is not null && listNewIngresoProducto.Cantidad > 0 && listNewIngresoProducto.PrecioActual > 0)
            {
                ingresoProductoModel tempIngresoProducto = null;

                try { tempIngresoProducto = newIngreso.IngresoProductosPerIngreso.Single(x => x.Producto == listNewIngresoProducto.Producto); } catch { }

                if (tempIngresoProducto is not null)
                {
                    tempIngresoProducto.Cantidad = listNewIngresoProducto.Cantidad;
                    tempIngresoProducto.PrecioActual = listNewIngresoProducto.PrecioActual;
                    tempIngresoProducto.PrecioPagado = listNewIngresoProducto.PrecioPagado;
                    tempIngresoProducto.updateModel();
                }
                else
                {
                    newIngreso.IngresoProductosPerIngreso.Add(listNewIngresoProducto);
                }

                newIngreso.updateModel();
                listNewIngresoProducto = new ingresoProductoModel();
                cleanerTries();
            }
            else
            {
                Shared.GlobalVars.nextTarget(sender);
            }
        }

        void helperListDeleteIngresoProducto()
        {
            listSelectedIngresoProducto.Producto.CantidadIngresado = 0;
            _ = newIngreso.IngresoProductosPerIngreso.Remove(listSelectedIngresoProducto);
            newIngreso.updateModel();
        }



        // Commands
        public Command textBoxCommandUpCantidad => new Command(
            (object parameter) => { if (listNewIngresoProducto.Cantidad < 1) { listNewIngresoProducto.Cantidad = 1; } else { listNewIngresoProducto.Cantidad += 1; } });
        public Command textBoxCommandDnCantidad => new Command(
            (object parameter) => { if (listNewIngresoProducto.Cantidad < 2) { listNewIngresoProducto.Cantidad = 1; } else { listNewIngresoProducto.Cantidad -= 1; } });


        public Command textBoxCommandFindProducto => new Command(
            (object parameter) => helperFindProducto(parameter),
            (object parameter) => listInputCodigo != null && !string.IsNullOrWhiteSpace(listInputCodigo));

        public Command listAgregarIngresoProducto => new Command(
            (object parameter) => helperListAgregarIngresoProducto(parameter));

        public Command listDeleteCommand => new Command(
            (object parameter) => { helperListDeleteIngresoProducto(); },
            (object parameter) => listSelectedIngresoProducto is not null);
        #endregion // Listado


        #region Properties









        bool _ingresoFallo;
        public bool ingresoFallo { get => _ingresoFallo; set { if (SetProperty(ref _ingresoFallo, value)) { OnPropertyChanged(); } } }



        #endregion // Properties
    }
}
