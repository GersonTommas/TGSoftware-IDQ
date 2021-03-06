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
        public HelperWindow(int sentCantidad, Decimal sentPrecioVenta = 0)
        {
            InitializeComponent(); DataContext = new HelperWindowViewModel(this, sentCantidad, sentPrecioVenta);
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
        public HelperWindowViewModel(HelperWindow sentWindow, int sentCantidad, Decimal sentPrecio)
        {
            thisWindow = sentWindow; cantidadVisibility = Visibility.Visible;
            Cantidad = sentCantidad; PrecioVenta = sentPrecio;
        }

        public HelperWindowViewModel(HelperWindow sentWindow, int sentCantidad, Decimal sentPrecioCompra, Decimal sentPrecioVenta)
        {
            thisWindow = sentWindow; ingresoVisibility = Visibility.Visible;
            Cantidad = sentCantidad; PrecioCompra = sentPrecioCompra; PrecioVenta = sentPrecioVenta;
        }
        #endregion // Initialize


        #region Variables
        int _Cantidad;
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PagadoTotal)); OnPropertyChanged(nameof(TotalVenta)); } } }

        Decimal _PrecioCompra;
        public Decimal PrecioCompra { get => _PrecioCompra; set { if (SetProperty(ref _PrecioCompra, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PagadoTotal)); OnPropertyChanged(nameof(PrecioSugerido)); } } }

        Decimal _PrecioVenta;
        public Decimal PrecioVenta { get => _PrecioVenta; set { if (SetProperty(ref _PrecioVenta, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(TotalVenta)); } } }

        public Decimal PagadoTotal => Cantidad * PrecioCompra;
        public Decimal PrecioSugerido => Math.Round(PrecioCompra * 1.3m, 2);

        public Decimal TotalVenta => Cantidad * PrecioVenta;


        public Visibility cantidadVisibility { get; } = Visibility.Collapsed;
        public Visibility ingresoVisibility { get; } = Visibility.Collapsed;
        #endregion // Variables


        #region Helpers
        void helperGuardar()
        {
            (thisWindow as HelperWindow).cantidad = Cantidad;
            thisWindow.DialogResult = true;
        }

        bool checkGuardar => cantidadVisibility == Visibility.Visible && Cantidad > 0;
        #endregion Helpers


        #region Commands
        public Command textBoxCommandUpCantidad => new Command(
            (object parameter) => { if (Cantidad < 1) { Cantidad = 1; } else { Cantidad++; } });

        public Command textBoxCommandDnCantidad => new Command(
            (object parameter) => { if (Cantidad < 2) { Cantidad = 1; } else { Cantidad--; } });

        public Command enterCommand => new Command(
            (object parameter) => { helperGuardar(); },
            (object parameter) => checkGuardar);

        public Command resultCommandCantidad => new Command(
            (object parameter) => { (thisWindow as HelperWindow).cantidad = Cantidad; thisWindow.DialogResult = true; },
            (object parameter) => Cantidad > 0);

        public Command resultCommandPrecioVenta => new Command(
            (object parameter) => { (thisWindow as HelperWindow).cantidad = Cantidad; (thisWindow as HelperWindow).precioCompra = PrecioCompra; (thisWindow as HelperWindow).precioVenta = PrecioVenta; thisWindow.DialogResult = true; },
            (object parameter) => Cantidad > 0 && PrecioCompra >= 0 && PrecioVenta > 0);

        public Command cancelCommand => new Command((object parameter) => thisWindow.DialogResult = false);
        #endregion // Commands
    }
}
