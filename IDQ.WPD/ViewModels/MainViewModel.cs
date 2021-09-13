using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels.Main;
using System;

namespace IDQ.WPF.ViewModels
{
    public class MainViewModel : Base.ViewModelBase
    {
        #region Initialize
        public INavigator Navigator { get; set; } = new Navigator();
        public INavigator mainProductosNavigator { get; } = new Navigator();
        public INavigator mainVentasNavigator { get; } = new Navigator();
        public INavigator mainIngresosNavigator { get; } = new Navigator();
        public INavigator mainDeudasNavigator { get; } = new Navigator();

        public MainViewModel()
        {
            Navigator.CurrentViewModel = new mainProductosViewModel();
            mainProductosNavigator.CurrentViewModel = new mainProductosViewModel();
            mainVentasNavigator.CurrentViewModel = new mainVentasViewModel();
            mainIngresosNavigator.CurrentViewModel = new mainIngresosViewModel();
            mainDeudasNavigator.CurrentViewModel = new mainDeudoresViewModel();
        }
        #endregion // Initialize


        #region Variables
        public usuarioModel usuarioActivo => Shared.GlobalVars.usuarioLogueado;
        public cajaModel cajaActual => context.globalCajaActual;
        #endregion // Variables


        #region Commands
        public Command xComTest => new Command((object parameter) => { xTestWindow wTest = new xTestWindow(); wTest.Show(); });

        public static Command comTest => new((object parameter) =>
        {
            _ = context.globalDb.fechas.Add(new fechaModel { Fecha = DateTime.Today.ToString(@"yyyy/MM/dd") });
            _ = context.globalDb.SaveChanges();

        });
        #endregion // Commands
    }
}