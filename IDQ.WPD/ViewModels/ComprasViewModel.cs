using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace IDQ.WPF.ViewModels
{
    public class ComprasViewModel : Base.ViewModelBase
    {
        #region Initialize
        public ComprasViewModel() { }
        #endregion // Initialize


        #region Variables
        ingresoModel _newIngreso = new ingresoModel();
        public ingresoModel newIngreso { get => _newIngreso; set { if (SetProperty(ref _newIngreso, value)) { OnPropertyChanged(); } } }

        productoModel _selectedProducto;
        productoModel selectedProducto { get => _selectedProducto; set { if (SetProperty(ref _selectedProducto, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Helpers
        void helperCleanIngreso()
        {
            newIngreso = new ingresoModel();
            List<productoModel> _tempProductosAgregados = context.globalAllProductos.Where(x => x.CantidadIngresado > 0).ToList();
            foreach (productoModel producto in _tempProductosAgregados)
            {
                producto.CantidadIngresado = 0;
            }
        }

        void heleperDeleteIngresoProducto()
        {
            try
            {
                ingresoProductoModel tempIngresoProducto = newIngreso.IngresoProductosPerIngreso.Single(x => x.Producto == selectedProducto);
                _ = newIngreso.IngresoProductosPerIngreso.Remove(tempIngresoProducto);

                newIngreso.updateModel();
            }
            catch { }
        }

        void helperAgregarIngresoProducto()
        {
            HelperWindow inputWindow = new HelperWindow(selectedProducto.CantidadIngresado, selectedProducto.PrecioIngreso, selectedProducto.PrecioActual);

            if (inputWindow.ShowDialog() == true)
            {
                if (selectedProducto.CantidadIngresado > 0)
                {
                    ingresoProductoModel _setIngresoProducto = null;

                    try { _setIngresoProducto = newIngreso.IngresoProductosPerIngreso.Single(x => x.Producto == selectedProducto); } catch { }

                    if (_setIngresoProducto != null)
                    {
                        _setIngresoProducto.Cantidad = inputWindow.cantidad;
                        _setIngresoProducto.PrecioPagado = inputWindow.precioCompra;
                        _setIngresoProducto.PrecioActual = inputWindow.precioVenta;
                    }
                }
                else
                {
                    newIngreso.IngresoProductosPerIngreso.Add(new ingresoProductoModel() { Producto = selectedProducto, Cantidad = inputWindow.cantidad, PrecioActual = inputWindow.precioVenta, PrecioPagado = inputWindow.precioCompra });
                }
                selectedProducto.CantidadIngresado = inputWindow.cantidad;
                newIngreso.updateModel();
            }
        }

        void helperGuardarIngreso()
        {
            newIngreso.Fecha = Shared.GlobalVars.returnFecha();
            newIngreso.Hora = Shared.GlobalVars.strHora;
            newIngreso.Usuario = Shared.GlobalVars.usuarioLogueado;

            context.globalDb.ingresos.Local.Add(newIngreso);
            _ = context.globalDb.SaveChanges();

            helperCleanIngreso();
        }
        #endregion // Helpers


        #region Checkers
        bool checkGuardarIngreso => newIngreso?.IngresoProductosPerIngreso.Count > 0;
        #endregion // Checkers


        #region Commands
        public Command ControlCommandGuardarIngreso => new Command(
            (object parameter) => helperGuardarIngreso(),
            (object parameter) => checkGuardarIngreso);

        public Command ctrlBuscadorDeleteCommand => new Command(
            (object parameter) => heleperDeleteIngresoProducto(),
            (object parameter) => selectedProducto != null);

        public Command ctrlBuscadorAddCommand => new Command(
            (object parameter) => { helperAgregarIngresoProducto(); },
            (object parameter) => selectedProducto != null);
        #endregion // Commands
    }
}
