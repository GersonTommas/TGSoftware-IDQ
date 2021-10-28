using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrlBuscador.xaml
    /// </summary>
    public partial class ctrlBuscador : UserControl, INotifyPropertyChanged
    {
        #region Initialize
        public ctrlBuscador()
        {
            InitializeComponent();
            _searchTimer.Tick += new EventHandler(searchTimer_Click); _searchTimer.Interval = new TimeSpan(0, 0, 0, 0, 150);

            try
            {

                localCollectionViewSourceProductos.SortDescriptions.Clear(); localCollectionViewSourceProductos.SortDescriptions.Add(new SortDescription(nameof(productoModel.Descripcion), ListSortDirection.Ascending));
                localCollectionViewSourceProductos.Filter = delegate (object item)
                {
                    productoModel tempItem = item as productoModel;

                    if (hasStockOption)
                    {
                        if (localBoolConStock == true && tempItem.Stock < 1) { return false; }
                        else if (localBoolConStock == false && tempItem.Stock > 0) { return false; }
                    }
                    if (hasActivoOption)
                    {
                        if (localBoolIsActivo == true && !tempItem.Activo) { return false; }
                        else if (localBoolIsActivo == false && tempItem.Activo) { return false; }
                    }

                    if (localBoolDescripcionCodigo)
                    { if (!String.IsNullOrWhiteSpace(localStringToSearch) && !tempItem.Descripcion.Contains(localStringToSearch, StringComparison.OrdinalIgnoreCase)) { return false; } }
                    else { if (!String.IsNullOrWhiteSpace(localStringToSearch) && !tempItem.Codigo.Contains(localStringToSearch, StringComparison.OrdinalIgnoreCase)) { return false; } }
                    return true;
                };
            }
            catch { }

            DataContext = this;
        }
        #endregion // Initialize



        #region Timer
        readonly System.Windows.Threading.DispatcherTimer _searchTimer = new System.Windows.Threading.DispatcherTimer();

        void searchTimer_Click(object sender, EventArgs e)
        {
            localCollectionViewSourceProductos.Refresh();
            if (_localCollectionSourceProductos.View.Cast<object>().Count() == 1) { _ = localCollectionViewSourceProductos.MoveCurrentToFirst(); isOnlyOneProducto = true; } else { isOnlyOneProducto = false; }

            _searchTimer.Stop();
        }

        void searchTimerRestart() { _searchTimer.Stop(); _searchTimer.Start(); }
        #endregion // Timer



        #region Local
        readonly CollectionViewSource _localCollectionSourceProductos = new CollectionViewSource() { Source = context.globalAllProductos };
        public ICollectionView localCollectionViewSourceProductos => _localCollectionSourceProductos.View;


        string _localStringToSearch;
        public string localStringToSearch { get => _localStringToSearch; set { if (_localStringToSearch != value) { _localStringToSearch = value; OnPropChanged(); searchTimerRestart(); } } }

        bool _localBoolDescripcionCodigo = true;
        public bool localBoolDescripcionCodigo { get => _localBoolDescripcionCodigo; set { if (_localBoolDescripcionCodigo != value) { _localBoolDescripcionCodigo = value; OnPropChanged(); OnPropChanged(nameof(localButtonContentDescripcion)); searchTimerRestart(); } } }

        bool? _localBoolConStock;
        public bool? localBoolConStock { get => _localBoolConStock; set { if (_localBoolConStock != value) { _localBoolConStock = value; OnPropChanged(); OnPropChanged(nameof(localStockContent)); searchTimerRestart(); } } }

        bool? _localBoolIsActivo;
        public bool? localBoolIsActivo { get => _localBoolIsActivo; set { if (_localBoolIsActivo != value) { _localBoolIsActivo = value; OnPropChanged(); OnPropChanged(nameof(localActivoContent)); searchTimerRestart(); } } }

        public string localButtonContentDescripcion => localBoolDescripcionCodigo ? "Descripción" : "Código";
        public string localStockContent => localBoolConStock == null ? "Con/Sin Stock" : localBoolConStock == true ? "Con Stock" : "Sin Stock";
        public string localActivoContent => localBoolIsActivo == null ? "Activo/Inactivo" : localBoolIsActivo == true ? "Activo" : "Inactivo";


        public Command localCommandLimpiar => new Command((object parameter) => localStringToSearch = "");
        public Command localCommandToggleButton => new Command((object parameter) => localBoolDescripcionCodigo = !localBoolDescripcionCodigo);
        #endregion // Local



        #region Properties
        public bool isOnlyOneProducto { get => (bool)GetValue(isOnlyOneProductoProperty); set { SetValue(isOnlyOneProductoProperty, value); OnPropChanged(); } }
        public bool hasSentCommand { get => (bool)GetValue(hasSentCommandProperty); set { SetValue(hasSentCommandProperty, value); OnPropChanged(); } }
        public bool hasStockOption { get => (bool)GetValue(hasStockOptionProperty); set { SetValue(hasStockOptionProperty, value); OnPropChanged(); } }
        public bool hasActivoOption { get => (bool)GetValue(hasActivoOptionProperty); set { SetValue(hasActivoOptionProperty, value); OnPropChanged(); } }
        public bool hasCantidadIngresado { get => (bool)GetValue(hasCantidadIngresadoProperty); set { SetValue(hasCantidadIngresadoProperty, value); OnPropChanged(); } }

        public Command oneProductoCommand { get => (Command)GetValue(oneProductoCommandProperty); set { SetValue(oneProductoCommandProperty, value); OnPropChanged(); } }
        public Command DGBackspaceCommand { get => (Command)GetValue(DGBackspaceCommandProperty); set { SetValue(DGBackspaceCommandProperty, value); OnPropChanged(); } }
        public Command DGDeleteCommand { get => (Command)GetValue(DGDeleteCommandProperty); set { SetValue(DGDeleteCommandProperty, value); OnPropChanged(); } }
        public Command DGEnterCommand { get => (Command)GetValue(DGEnterCommandProperty); set { SetValue(DGEnterCommandProperty, value); OnPropChanged(); } }
        public Command DGF5Command { get => (Command)GetValue(DGF5CommandProperty); set { SetValue(DGF5CommandProperty, value); OnPropChanged(); } }

        public productoModel DGSelectedProducto { get => (productoModel)GetValue(DGSelectedProductoProperty); set { SetValue(DGSelectedProductoProperty, value); OnPropChanged(); } }



        public static readonly DependencyProperty isOnlyOneProductoProperty = DependencyProperty.Register("isOnlyOneProducto", typeof(bool), typeof(ctrlBuscador), new PropertyMetadata(false));
        public static readonly DependencyProperty hasSentCommandProperty = DependencyProperty.Register("hasSentCommand", typeof(bool), typeof(ctrlBuscador), new PropertyMetadata(false));
        public static readonly DependencyProperty hasStockOptionProperty = DependencyProperty.Register("hasStockOption", typeof(bool), typeof(ctrlBuscador), new PropertyMetadata(false));
        public static readonly DependencyProperty hasActivoOptionProperty = DependencyProperty.Register("hasActivoOption", typeof(bool), typeof(ctrlBuscador), new PropertyMetadata(false));
        public static readonly DependencyProperty hasCantidadIngresadoProperty = DependencyProperty.Register("hasCantidadIngresado", typeof(bool), typeof(ctrlBuscador), new PropertyMetadata(false));

        public static readonly DependencyProperty oneProductoCommandProperty = DependencyProperty.Register("oneProductoCommand", typeof(Command), typeof(ctrlBuscador), new PropertyMetadata(null));
        public static readonly DependencyProperty DGBackspaceCommandProperty = DependencyProperty.Register("DGBackspaceCommand", typeof(Command), typeof(ctrlBuscador), new PropertyMetadata(null));
        public static readonly DependencyProperty DGDeleteCommandProperty = DependencyProperty.Register("DGDeleteCommand", typeof(Command), typeof(ctrlBuscador), new PropertyMetadata(null));
        public static readonly DependencyProperty DGEnterCommandProperty = DependencyProperty.Register("DGEnterCommand", typeof(Command), typeof(ctrlBuscador), new PropertyMetadata(null));
        public static readonly DependencyProperty DGF5CommandProperty = DependencyProperty.Register("DGF5Command", typeof(Command), typeof(ctrlBuscador), new PropertyMetadata(null));

        public static readonly DependencyProperty DGSelectedProductoProperty = DependencyProperty.Register("DGSelectedProducto", typeof(productoModel), typeof(ctrlBuscador), new PropertyMetadata(null));
        //public static readonly DependencyProperty DGSelectedProductoProperty = DependencyProperty.Register("DGSelectedProducto", typeof(productoModel), typeof(ctrlBuscador), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, null, false, UpdateSourceTrigger.PropertyChanged));
        #endregion // Properties



        #region TextBox
        void FirstTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            _ = (sender as TextBox).Focus();
        }
        #endregion // TextBox



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion // PropertyChanged
    }
}