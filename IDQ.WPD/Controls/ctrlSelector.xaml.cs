﻿using IDQ.Domain.Models;
using IDQ.EntityFramework;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrlSelector.xaml
    /// </summary>
    public partial class ctrlSelector : UserControl, INotifyPropertyChanged
    {
        public ctrlSelector()
        {
            InitializeComponent(); (DataContext as ctrlSelectorViewModel).thisControl = this;
        }

        public bool isOnlyOneProducto { get => (bool)GetValue(isOnlyOneProductoProperty); set { SetValue(isOnlyOneProductoProperty, value); OnPropChanged(); } }

        public static readonly DependencyProperty isOnlyOneProductoProperty = DependencyProperty.Register("isOnlyOneProducto", typeof(bool), typeof(ctrlSelector), new PropertyMetadata(false));



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        #endregion // PropertyChanged

        void FirstTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            _ = (sender as TextBox).Focus();
        }
    }



    public class ctrlSelectorViewModel : Base.ViewModelBase
    {
        #region Initialize
        public ctrlSelector thisControl;

        public ctrlSelectorViewModel()
        {
            initilizeSearchTimer();
            selectorListProductosSource.Source = context.globalAllProductos;
            OnPropChanged(nameof(selectorListProductos));


            selectorListProductos.SortDescriptions.Clear(); selectorListProductos.SortDescriptions.Add(new SortDescription("Descripcion", ListSortDirection.Ascending));

            selectorListProductos.Filter = delegate (object item)
            {
                if (item == null) { return false; }
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
        #endregion // Initialize



        #region Variables
        readonly System.Windows.Threading.DispatcherTimer _searchTimer = new System.Windows.Threading.DispatcherTimer();
        void initilizeSearchTimer() { _searchTimer.Tick += new EventHandler(searchTimer_Click); _searchTimer.Interval = new TimeSpan(0, 0, 0, 0, 150); }
        void searchTimer_Click(object sender, EventArgs e) { searchTimerClick(); _searchTimer.Stop(); }

        void searchTimerClick()
        {
            selectorListProductos.Refresh();
            if (selectorListProductos != null && selectorListProductosSource.View.Cast<object>().Count() == 1) { _ = selectorListProductos.MoveCurrentToFirst(); thisControl.isOnlyOneProducto = true; } else { thisControl.isOnlyOneProducto = false; }
        }
        void searchTimerRestart()
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        string _strSearchProducto = "";
        public string strSearchProducto { get => _strSearchProducto; set { if (_strSearchProducto != value) { _strSearchProducto = value; OnPropChanged(); searchTimerRestart(); } } }

        bool _bolMantenerVentanaAbierta = false;
        public bool bolMantenerVentanaAbierta { get => _bolMantenerVentanaAbierta; set { if (_bolMantenerVentanaAbierta != value) { _bolMantenerVentanaAbierta = value; OnPropChanged(); } } }

        bool _ventaFallo = false;
        public bool ventaFallo { get => _ventaFallo; set { if (_ventaFallo != value) { _ventaFallo = value; OnPropChanged(); OnPropChanged(nameof(windowBackground)); } } }

        bool _bolSelectorSoloStock = false;
        public bool bolSelectorSoloStock { get => _bolSelectorSoloStock; set { if (_bolSelectorSoloStock != value) { _bolSelectorSoloStock = value; OnPropChanged(); selectorListProductos.Refresh(); } } }

        bool _bolSearchDescripcionCodigo = true;
        public bool bolSearchDescripcionCodigo { get => _bolSearchDescripcionCodigo; set { if (_bolSearchDescripcionCodigo != value) { _bolSearchDescripcionCodigo = value; OnPropChanged(); OnPropChanged(nameof(strSearchDescripcionCodigo)); } } }

        productoModel _selectedSelectorProducto;
        public productoModel selectedSelectorProducto { get => _selectedSelectorProducto; set { if (_selectedSelectorProducto != value) { _selectedSelectorProducto = value; OnPropChanged(); } } }


        public string windowBackground => !ventaFallo ? Shared.GlobalVars.colorWindowBackgroundOK : Shared.GlobalVars.colorWindowBackkgroundNO;
        public string strSearchDescripcionCodigo => bolSearchDescripcionCodigo ? "Descripción" : "Código";


        readonly CollectionViewSource selectorListProductosSource = new CollectionViewSource() { /*Source = Variables.Inventario.Productos.Local.ToObservableCollection()*/ };
        public ICollectionView selectorListProductos => selectorListProductosSource.View;
        #endregion // Variables



        #region Commands
        public Command comAbrirProducto => new Command((object parameter) => { if (parameter != null) { /*Views.addConversionView vTemp = new Views.addConversionView(parameter as productosModel); _ = vTemp.ShowDialog(); */} });

        public Command comSearchDescripcionCodigo => new Command((object parameter) => { bolSearchDescripcionCodigo = !bolSearchDescripcionCodigo; OnPropChanged(nameof(strSearchDescripcionCodigo)); strSearchProducto = ""; });

        public Command comLimpiar => new Command(
            (object parameter) => strSearchProducto = "",
            (object parameter) => !string.IsNullOrWhiteSpace(strSearchProducto));
        #endregion // Commands


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        #endregion // PropertyChanged
    }
}
