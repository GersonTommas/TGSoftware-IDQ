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
        public Decimal precioCompra;
        public Decimal precioVenta;

        #region Initialize
        public HelperWindow(int sentCantidad)
        {
            InitializeComponent(); DataContext = new HelperWindowViewModel(this, sentCantidad);
        }
        public HelperWindow(int sentCantidad, Decimal sentPrecioCompra, Decimal sentPrecioVenta)
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

        public HelperWindowViewModel(HelperWindow sentWindow, int sentCantidad, Decimal sentPrecioCompra, Decimal sentPrecioVenta)
        {
            thisWindow = sentWindow; ingresoVisibility = Visibility.Visible;
            Cantidad = sentCantidad; PrecioCompra = sentPrecioCompra; PrecioVenta = sentPrecioVenta;
        }
        #endregion // Initialize


        #region Variables
        int _Cantidad;
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PagadoTotal)); } } }

        Decimal _PrecioCompra;
        public Decimal PrecioCompra { get => _PrecioCompra; set { if (SetProperty(ref _PrecioCompra, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PagadoTotal)); OnPropertyChanged(nameof(PrecioSugerido)); } } }

        Decimal _PrecioVenta;
        public Decimal PrecioVenta { get => _PrecioVenta; set { if (SetProperty(ref _PrecioVenta, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        public Decimal PagadoTotal => Cantidad * PrecioCompra;
        public Decimal PrecioSugerido => Math.Round(PrecioCompra * 1.3m, 2);


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
