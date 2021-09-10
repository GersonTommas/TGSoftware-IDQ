using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class stockEditViewModel : Base.ViewModelBase
    {
        public stockEditViewModel()
        {
            _newStockProducto = new modificadoProductoModel() { Fecha = Shared.GlobalVars.returnFecha() };
        }

        public void setInitialize(productoModel sentProducto, Window sentWindow = null)
        {
            newStockProducto.Producto = sentProducto; thisWindow = sentWindow;
        }

        public ObservableCollection<usuarioModel> listUsersSource = context.globalDb.usuarios.Local.ToObservableCollection();

        modificadoProductoModel _newStockProducto;
        public modificadoProductoModel newStockProducto { get => _newStockProducto; set { if (SetProperty(ref _newStockProducto, value)) { OnPropertyChanged(); } } }


        #region Helpers
        void helperGuardar(object sender)
        {
            if (sender is PasswordBox passBox)
            {
                if (passBox.Password != null)
                {
                    string pass = passBox.Password;
                    if (newStockProducto.Usuario.Contraseña == pass)
                    {
                        _ = context.globalDb.modificadoProductos.Add(newStockProducto);
                        newStockProducto.Producto.Stock += newStockProducto.Cantidad;
                        _ = context.globalDb.SaveChanges();

                        if (thisWindow != null) { thisWindow.DialogResult = true; }
                    }
                    else { Shared.GlobalVars.messageError.LogIn(); }
                }
            }
        }

        bool checkGuardar => newStockProducto.Cantidad != 0 && newStockProducto.Producto != null && newStockProducto.Usuario != null;
        #endregion // Helpers



        #region Commands
        public Command controlCancelar => new Command((object parameter) => thisWindow.DialogResult = false);

        public Command controlGuardarCommand => new Command(
            (object parameter) => helperGuardar(parameter),
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
