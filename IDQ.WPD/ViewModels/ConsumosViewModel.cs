using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IDQ.WPF.ViewModels
{
    public class ConsumosViewModel : Base.ViewModelBase
    {
        public ConsumosViewModel() { }


        #region Variables
        string _strCodigoFailed;
        int _intCodigoFailedCount;


        string _inputCodigo;
        public string inputCodigo { get => _inputCodigo; set { if (SetProperty(ref _inputCodigo, value)) { OnPropertyChanged(); if (newConsumo.Producto != null) { newConsumo.Producto = null; newConsumo.Precio = 0; } } } }


        public consumoProductoModel newConsumo { get; } = new consumoProductoModel() { Fecha = Shared.GlobalVars.returnFecha(), Cantidad = 1 };
        #endregion // Variables



        #region Helpers
        void helperFindProducto(object sender = null)
        {
            try
            {
                newConsumo.Producto = context.globalDb.productos.Local.Single(x => x.Codigo.ToLower() == inputCodigo.ToLower());
                newConsumo.Precio = newConsumo.Producto.PrecioActual;
                Shared.GlobalVars.nextTarget(sender); _strCodigoFailed = null; _intCodigoFailedCount = 0;
            }
            catch
            {
                newConsumo.Producto = null;
                if (!string.IsNullOrWhiteSpace(_strCodigoFailed) && _strCodigoFailed.ToLower() == _inputCodigo.ToLower())
                {
                    if (_intCodigoFailedCount >= 1)
                    {
                        if (Shared.GlobalVars.messageError.NewProduct())
                        {/*
                            if (gOpenAddProducto(strCodigo))*/
                            {
                                helperFindProducto(sender);
                            }
                        }
                    }
                    else
                    {
                        _intCodigoFailedCount++;
                        if (sender != null) { (sender as TextBox).SelectAll(); }
                    }
                }
                else
                {
                    _strCodigoFailed = _inputCodigo;
                    _intCodigoFailedCount++;
                    if (sender != null) { (sender as TextBox).SelectAll(); }
                }
            }
        }

        void helperGuardar()
        {
            if (checkGuardar)
            {
                newConsumo.Producto.Stock -= newConsumo.Cantidad;
                _ = context.globalDb.consumosProductos.Add(newConsumo);
                _ = context.globalDb.SaveChanges();
                newConsumo.Fecha.updateTotalConsumosDiario();
                thisWindow.DialogResult = true;
            }
        }

        bool checkGuardar => newConsumo != null && newConsumo.Producto != null && newConsumo.Cantidad > 0;
        #endregion // Helpers



        #region Commands
        public Command comIngresoManual => new Command(
                    (object parameter) => { /*gHelperSelectorView = new Views.helperSelectorView(); if (gHelperSelectorView.ShowDialog().Value) { strCodigo = gHelperSelectorView.sendProduct.Codigo; helperFindProducto(); }*/ });

        public Command comProducto => new Command(
            (object parameter) => helperFindProducto(parameter),
            (object parameter) => !string.IsNullOrWhiteSpace(inputCodigo));

        public Command comGuardar => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
