using IDQ.Domain.Models;
using IDQ.WPF.Enumerators;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels.Helpers;
using System;
using System.Windows;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for HelperWindow.xaml
    /// </summary>
    public partial class HelperWindow : Window
    {
        public int cantidad;
        public double precioCompra;
        public double precioVenta;

        #region Initialize
        public HelperWindow(int sentCantidad)
        {
            InitializeComponent(); DataContext = new HelperWindowViewModel(this, sentCantidad);
        }
        public HelperWindow(int sentCantidad, double sentPrecioCompra, double sentPrecioVenta)
        {
            InitializeComponent(); DataContext = new HelperWindowViewModel(this, sentCantidad, sentPrecioCompra, sentPrecioVenta);
        }
        #endregion // Initialize
    }



    class HelperWindowViewModel : Base.ViewModelBase
    {
        #region Initialize
        public HelperWindowViewModel() { }
        public HelperWindowViewModel(HelperWindow sentWindow, int sentCantidad)
        {
            thisWindow = sentWindow; cantidadVisibility = Visibility.Visible;
            Cantidad = sentCantidad;
        }

        public HelperWindowViewModel(HelperWindow sentWindow, int sentCantidad, double sentPrecioCompra, double sentPrecioVenta)
        {
            thisWindow = sentWindow; ingresoVisibility = Visibility.Visible;
            Cantidad = sentCantidad; PrecioCompra = sentPrecioCompra; PrecioVenta = sentPrecioVenta;
        }
        #endregion // Initialize


        #region Variables
        int _Cantidad;
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PagadoTotal)); } } }

        double _PrecioCompra;
        public double PrecioCompra { get => _PrecioCompra; set { if (SetProperty(ref _PrecioCompra, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PagadoTotal)); OnPropertyChanged(nameof(PrecioSugerido)); } } }

        double _PrecioVenta;
        public double PrecioVenta { get => _PrecioVenta; set { if (SetProperty(ref _PrecioVenta, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        public double PagadoTotal => Cantidad * PrecioCompra;
        public double PrecioSugerido => Math.Round(PrecioCompra * 1.3, 2);


        public Visibility cantidadVisibility { get; } = Visibility.Collapsed;
        public Visibility ingresoVisibility { get; } = Visibility.Collapsed;
        #endregion // Variables


        #region Commands
        public Command resultCommandCantidad => new Command(
            (object parameter) => { },
            (object parameter) => Cantidad > 0);

        public Command resultCommandPrecioVenta => new Command(
            (object parameter) => { },
            (object parameter) => Cantidad > 0 && PrecioCompra >= 0 && PrecioVenta > 0);

        public Command cancelCommand => new Command((object parameter) => thisWindow.DialogResult = false);
        #endregion // Commands
    }
}
