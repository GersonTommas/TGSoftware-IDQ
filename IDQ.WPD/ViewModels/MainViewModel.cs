using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels.Main;
using System;

namespace IDQ.WPF.ViewModels
{
    public class MainViewModel : Base.ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
        public INavigator mainProductosNavigator { get; } = new Navigator();
        public INavigator mainVentasNavigator { get; } = new Navigator();
        public INavigator mainIngresosNavigator { get; } = new Navigator();
        public INavigator mainDeudasNavigator { get; } = new Navigator();

        public MainViewModel()
        {
            initilizeClock();
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Productos);
            mainProductosNavigator.CurrentViewModel = new mainProductosViewModel();
            mainVentasNavigator.CurrentViewModel = new mainVentasViewModel();
            mainIngresosNavigator.CurrentViewModel = new mainIngresosViewModel();
            mainDeudasNavigator.CurrentViewModel = new mainDeudoresViewModel();
        }

        public usuarioModel usuarioActivo => Shared.GlobalVars.usuarioLogueado;
        public cajaModel cajaActual => context.globalCajaActual;

        #region Clock
        readonly System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        void initilizeClock() { Timer.Tick += new EventHandler(Timer_Click); Timer.Interval = new TimeSpan(0, 0, 1); Timer.Start(); }
        void Timer_Click(object sender, EventArgs e) { OnPropertyChanged(nameof(strClock)); }

        public string strClock => DateTime.Now.ToString(format: "HH:mm:ss");
        #endregion // Clock

        public Command xComTest => new Command((object parameter) => { xTestWindow wTest = new xTestWindow(); wTest.Show(); });

        public static Command comTest => new((object parameter) =>
        {
            _ = context.globalDb.fechas.Add(new fechaModel { Fecha = DateTime.Today.ToString(@"yyyy/MM/dd") });
            _ = context.globalDb.SaveChanges();

        });
    }
}
