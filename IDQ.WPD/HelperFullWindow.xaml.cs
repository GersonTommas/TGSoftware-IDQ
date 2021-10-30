using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for HelperFullWindow.xaml
    /// </summary>
    public partial class HelperFullWindow : Window, INotifyPropertyChanged
    {
        public productoModel resultProducto;
        public int resultCantidad = 1;

        public HelperFullWindow()
        {
            InitializeComponent(); /*DataContext = this;*/
            DataContext = new HelperFullWindowViewModel(this);
        }
        public HelperFullWindow(Base.ViewModelBase sentViewModel)
        {
            InitializeComponent(); /*DataContext = this;*/ Navigator.CurrentViewModel = sentViewModel;
            DataContext = new HelperFullWindowViewModel(this);
        }

        public HelperFullWindow(Base.ViewModelBase sentViewModel, ViewModels.VentasViewModel resultViewModel)
        {
            InitializeComponent(); /*DataContext = this;*/ Navigator.CurrentViewModel = sentViewModel; ResultViewModel = resultViewModel;
            DataContext = new HelperFullWindowViewModel(this);
        }


        public INavigator Navigator = new Navigator();

        public ViewModels.VentasViewModel ResultViewModel;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string PropertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            else
            {
                storage = value;
                return true;
            }
        }


        #region TextBox
        void FirstTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            _ = (sender as TextBox).Focus();
        }
        #endregion // TextBox
    }

    public class HelperFullWindowViewModel : Base.ViewModelBase
    {
        #region Initialize
        public HelperFullWindowViewModel() { }

        public HelperFullWindowViewModel(HelperFullWindow sentwindow)
        {
            thisWindow = sentwindow;
            initilizeSearchTimer();
            selectorListProductosSource.Source = context.globalAllProductos;

            try
            {
                selectorListProductos.SortDescriptions.Clear(); selectorListProductos.SortDescriptions.Add(new SortDescription("Descripcion", ListSortDirection.Ascending));
                selectorListProductos.Filter = delegate (object item)
                {
                    if (item is null) { return false; }
                    else
                    {
                        productoModel tempItem = item as productoModel;
                        return !string.IsNullOrWhiteSpace(strSearchProducto)
                            ? bolSelectorSoloStock
                                ? bolSearchDescripcionCodigo ? tempItem.stockVsMinimo != 1 && tempItem.Descripcion.ToLower().Contains(strSearchProducto.ToLower()) : tempItem.stockVsMinimo != 1 && tempItem.Codigo.ToLower().Contains(strSearchProducto.ToLower())
                                : bolSearchDescripcionCodigo ? tempItem.Descripcion.ToLower().Contains(strSearchProducto.ToLower()) : tempItem.Codigo.ToLower().Contains(strSearchProducto.ToLower())
                            : !bolSelectorSoloStock || tempItem.stockVsMinimo != 1;
                    }
                };
            }
            catch { }
        }
        #endregion // Initialize



        #region Timer
        readonly System.Windows.Threading.DispatcherTimer _searchTimer = new System.Windows.Threading.DispatcherTimer();
        void initilizeSearchTimer() { _searchTimer.Tick += new EventHandler(searchTimer_Click); _searchTimer.Interval = new TimeSpan(0, 0, 0, 0, 150); }
        void searchTimer_Click(object sender, EventArgs e) { searchTimerClick(); _searchTimer.Stop(); }

        void searchTimerClick()
        {
            selectorListProductos.Refresh();
            if (selectorListProductos is not null && selectorListProductosSource.View.Cast<object>().Count() == 1) { _ = selectorListProductos.MoveCurrentToFirst(); isOnlyOneProducto = true; } else { isOnlyOneProducto = false; }
        }
        void searchTimerRestart()
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }
        #endregion // Timer



        #region Variables
        productoModel _BuscadorSelectedProducto;
        public productoModel BuscadorSelectedProducto { get => _BuscadorSelectedProducto; set { if (SetProperty(ref _BuscadorSelectedProducto, value)) { OnPropertyChanged(); } } }

        bool _isOnlyOneProducto;
        public bool isOnlyOneProducto { get => _isOnlyOneProducto; set { if (SetProperty(ref _isOnlyOneProducto, value)) { OnPropertyChanged(); } } }

        string _strSearchProducto = "";
        public string strSearchProducto { get => _strSearchProducto; set { if (SetProperty(ref _strSearchProducto, value)) { OnPropertyChanged(); searchTimerRestart(); } } }

        bool _bolMantenerVentanaAbierta;
        public bool bolMantenerVentanaAbierta { get => _bolMantenerVentanaAbierta; set { if (SetProperty(ref _bolMantenerVentanaAbierta, value)) { OnPropertyChanged(); } } }

        bool _ventaFallo;
        public bool ventaFallo { get => _ventaFallo; set { if (SetProperty(ref _ventaFallo, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(windowBackground)); } } }

        bool _bolSelectorSoloStock;
        public bool bolSelectorSoloStock { get => _bolSelectorSoloStock; set { if (SetProperty(ref _bolSelectorSoloStock, value)) { OnPropertyChanged(); selectorListProductos.Refresh(); } } }

        bool _bolSearchDescripcionCodigo = true;
        public bool bolSearchDescripcionCodigo { get => _bolSearchDescripcionCodigo; set { if (SetProperty(ref _bolSearchDescripcionCodigo, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(strSearchDescripcionCodigo)); strSearchProducto = ""; } } }

        productoModel _selectedSelectorProducto;
        public productoModel selectedSelectorProducto { get => _selectedSelectorProducto; set { if (SetProperty(ref _selectedSelectorProducto, value)) { OnPropertyChanged(); } } }


        public string windowBackground => !ventaFallo ? Shared.GlobalVars.colorWindowBackgroundOK : Shared.GlobalVars.colorWindowBackkgroundNO;
        public string strSearchDescripcionCodigo => bolSearchDescripcionCodigo ? "Descripción" : "Código";


        readonly CollectionViewSource selectorListProductosSource = new CollectionViewSource() { /*Source = Variables.Inventario.Productos.Local.ToObservableCollection()*/ };
        public ICollectionView selectorListProductos => selectorListProductosSource.View;
        #endregion // Variables



        #region Commands
        public Command comAbrirProducto => new Command((object parameter) => { if (parameter is not null) { /*Views.addConversionView vTemp = new Views.addConversionView(parameter as productosModel); _ = vTemp.ShowDialog(); */} });

        public Command comSearchDescripcionCodigo => new Command((object parameter) => bolSearchDescripcionCodigo = !bolSearchDescripcionCodigo);

        public Command comLimpiar => new Command(
            (object parameter) => strSearchProducto = "",
            (object parameter) => !string.IsNullOrWhiteSpace(strSearchProducto));


        public Command ctrlBuscadorAddCommand => new Command(
            (object parameter) => { HelperWindow cantWindow = new HelperWindow(1, selectedSelectorProducto.PrecioActual); if (cantWindow.ShowDialog() == true) { (thisWindow as HelperFullWindow).resultCantidad = cantWindow.cantidad; (thisWindow as HelperFullWindow).resultProducto = selectedSelectorProducto; thisWindow.DialogResult = true; } },
            (object parameter) => selectedSelectorProducto is not null);

        public Command bComUnSoloProducto => new Command(
            (object parameter) => { HelperWindow cantWindow = new HelperWindow(1); if (cantWindow.ShowDialog() == true) { (thisWindow as HelperFullWindow).resultProducto = selectedSelectorProducto; thisWindow.DialogResult = true; } },
            (object parameter) => isOnlyOneProducto && selectedSelectorProducto is not null);

        public Command cancelCommand => new Command((object parameter) => thisWindow.DialogResult = false);
        #endregion // Commands
    }
}