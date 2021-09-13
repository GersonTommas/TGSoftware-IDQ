using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Windows;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class abrirBolsaViewModel : Base.ViewModelBase
    {
        #region Initialize
        public abrirBolsaViewModel() { }


        public void setInitilize(productoModel sentProducto, Window sentWindow)
        {
            thisWindow = sentWindow;
            newConversion.ProductoSacado = sentProducto;
        }
        #endregion // Initialize


        #region Variables
        public abiertoProductoModel newConversion { get; } = new abiertoProductoModel() { CantidadSacado = 1, Fecha = Shared.GlobalVars.returnFecha(), Usuario = Shared.GlobalVars.usuarioLogueado };
        #endregion // Variables


        #region Helpers
        void helperSeleccionarProducto()
        {/*
            gHelperSelectorView = new Views.helperSelectorView();
            if (gHelperSelectorView.ShowDialog().Value)
            {
                selectedAbierto.ProductoAgregado = gHelperSelectorView.sendProduct;
            }*/
        }

        void helperGuardar()
        {
            newConversion.ProductoSacado.Stock -= newConversion.CantidadSacado;
            newConversion.ProductoAgregado.Stock += newConversion.CantidadAgregado;
            _ = context.globalDb.abiertoProductos.Add(newConversion);

            _ = context.globalDb.SaveChanges();

            thisWindow.DialogResult = true;
        }

        bool checkGuardar => newConversion.ProductoSacado != null && newConversion.ProductoAgregado != null && newConversion.CantidadAgregado > 0 && newConversion.CantidadSacado > 0;
        #endregion // Helpers


        #region Commands
        public Command comSeleccionarProducto => new Command((object parameter) => helperSeleccionarProducto());

        public Command controlCommandGuardar => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
