using IDQ.Domain.Models;
using IDQ.Domain.Services;
using IDQ.EntityFramework;
using IDQ.EntityFramework.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class stockEditViewModel : Base.ViewModelBase
    {
        #region Initialize
        public stockEditViewModel() { }

        public stockEditViewModel(productoModel sentProducto)
        {
            newStockProducto.Producto = sentProducto;
        }
        #endregion // Initialize


        #region Variables
        public ObservableCollection<usuarioModel> listUsersSource => context.globalAllUsuarios;

        public modificadoProductoModel newStockProducto { get; } = new modificadoProductoModel() { Fecha = Shared.GlobalVars.returnFecha() };
        #endregion // Variables


        #region Helpers
        void helperGuardar(object sender)
        {
            if (sender is PasswordBox passBox)
            {
                if (passBox.Password is not null)
                {
                    //string pass = passBox.Password;
                    if (newStockProducto.Usuario.Contraseña == passBox.Password)
                    {
                        IDataService<modificadoProductoModel> dataService = new GenericDataService<modificadoProductoModel>();
                        newStockProducto.Producto.Stock += newStockProducto.Cantidad;
                        _ = dataService.Create(newStockProducto);
                        //_ = context.globalDb.modificadoProductos.Add(newStockProducto);

                        //_ = context.globalDb.SaveChanges();

                        Shared.Navigators.ContentTopNavigator.updateNavigator(null);
                    }
                    else { Shared.GlobalVars.messageError.LogIn(); }
                }
            }
        }

        bool checkGuardar => newStockProducto.Cantidad != 0 && newStockProducto.Producto is not null && newStockProducto.Usuario is not null;
        #endregion // Helpers



        #region Commands
        public Command controlCancelar => new Command((object parameter) => Shared.Navigators.ContentTopNavigator.updateNavigator(null));

        public Command controlGuardarCommand => new Command(
            (object parameter) => helperGuardar(parameter),
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
