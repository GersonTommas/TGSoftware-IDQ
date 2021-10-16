using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrlSelector.xaml
    /// </summary>
    public partial class ctrlBuscador : UserControl, INotifyPropertyChanged
    {
        #region Initialize
        //readonly ctrlBuscadorViewModel thisDataContext;

        public ctrlBuscador()
        {
            InitializeComponent(); firstControl.DataContext = new ctrlBuscadorViewModel(this);// thisDataContext = DataContext as ctrlBuscadorViewModel; thisDataContext.thisControl = this;
        }
        #endregion // Initialize


        #region Variables
        public bool isOnlyOneProducto { get => (bool)GetValue(isOnlyOneProductoProperty); set { SetValue(isOnlyOneProductoProperty, value); OnPropChanged(); } }
        public object selectedItem { get => GetValue(selectedItemProperty); set { SetValue(selectedItemProperty, value); OnPropChanged(); } }
        public Visibility soloStockVisibility { get => (Visibility)GetValue(soloStockVisibilityProperty); set { SetValue(soloStockVisibilityProperty, value); OnPropChanged(); } }
        public bool hasSentCommand { get => (bool)GetValue(hasSentCommandProperty); set { SetValue(hasSentCommandProperty, value); OnPropChanged(); } }


        public static readonly DependencyProperty isOnlyOneProductoProperty = DependencyProperty.Register("isOnlyOneProducto", typeof(bool), typeof(ctrlBuscador), new PropertyMetadata(false));
        public static readonly DependencyProperty selectedItemProperty = DependencyProperty.Register("selectedItem", typeof(object), typeof(ctrlBuscador), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, null, false, UpdateSourceTrigger.PropertyChanged));
        public static readonly DependencyProperty soloStockVisibilityProperty = DependencyProperty.Register("soloStockVisibility", typeof(Visibility), typeof(ctrlBuscador), new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty hasSentCommandProperty = DependencyProperty.Register("hasSentCommand", typeof(bool), typeof(ctrlBuscador), new PropertyMetadata(false));
        #endregion // Variables


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        #endregion // PropertyChanged


        #region TextBox
        void FirstTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            _ = (sender as TextBox).Focus();
        }
        #endregion // TextBox
    }



    public class ctrlBuscadorViewModel : Base.ViewModelBase
    {
        #region Initialize
        public ctrlBuscador thisControl;

        public ctrlBuscadorViewModel() { }

        public ctrlBuscadorViewModel(ctrlBuscador sentControl)
        {
            thisControl = sentControl;
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
            if (selectorListProductos is not null && selectorListProductosSource.View.Cast<object>().Count() == 1) { _ = selectorListProductos.MoveCurrentToFirst(); thisControl.isOnlyOneProducto = true; } else { thisControl.isOnlyOneProducto = false; }
        }
        void searchTimerRestart()
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }
        #endregion // Timer



        #region Variables
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
        #endregion // Commands
    }
}
