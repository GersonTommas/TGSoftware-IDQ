using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels.Main.Productos;
using System;
using System.ComponentModel;
using System.Windows.Data;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainProductosViewModel : Base.ViewModelBase
    {
        #region Initialize
        //public INavigator Navigator { get; set; } = new Navigator();

        public mainProductosViewModel()
        {
            //try
            //{
            //    Navigator.CurrentViewModel = new productosBasicViewModel();
            //    initilizeSearchTimer();

            //    collectionAllProductos.Filter += delegate (object item)
            //    {
            //        if (item is null) { return false; }
            //        else
            //        {
            //            productoModel tempItem = item as productoModel;
            //            return !string.IsNullOrWhiteSpace(textBoxStringBusqueda)
            //                ? checkBoxBoolActive is not null
            //                    ? buttonBoolBusqueda
            //                        ? tempItem.Activo == checkBoxBoolActive && tempItem.Descripcion.ToLower().Contains(textBoxStringBusqueda.ToLower())
            //                        : tempItem.Activo == checkBoxBoolActive && tempItem.Codigo.ToLower().Contains(textBoxStringBusqueda.ToLower())
            //                    : buttonBoolBusqueda
            //                        ? tempItem.Descripcion.ToLower().Contains(textBoxStringBusqueda.ToLower())
            //                        : tempItem.Codigo.ToLower().Contains(textBoxStringBusqueda.ToLower())
            //                : checkBoxBoolActive is not null ? tempItem.Activo == checkBoxBoolActive : true;
            //        }
            //    };
            //    collectionAllProductos.SortDescriptions.Clear(); collectionAllProductos.SortDescriptions.Add(new SortDescription(nameof(productoModel.Descripcion), ListSortDirection.Ascending));
            //    _ = collectionAllProductos.MoveCurrentToFirst();
            //}
            //catch { }
        }
        #endregion // Initialize


        //#region Search
        //readonly System.Windows.Threading.DispatcherTimer _searchTimer = new System.Windows.Threading.DispatcherTimer();
        //void initilizeSearchTimer() { _searchTimer.Tick += new EventHandler(searchTimer_Click); _searchTimer.Interval = new TimeSpan(0, 0, 0, 0, 150); }
        //void searchTimer_Click(object sender, EventArgs e) { searchTimerClick(); _searchTimer.Stop(); }

        //void searchTimerRestart()
        //{
        //    _searchTimer.Stop();
        //    _searchTimer.Start();
        //}

        //void searchTimerClick()
        //{
        //    collectionAllProductos.Refresh();
        //}
        //#endregion // Search


        #region Properties
        productoModel _selectedProducto;
        public productoModel selectedProducto { get => _selectedProducto; set { if (SetProperty(ref _selectedProducto, value)) { OnPropertyChanged(); } } }



        //readonly CollectionViewSource collectionAllProductosSource = new CollectionViewSource() { Source = context.globalAllProductos };
        //public ICollectionView collectionAllProductos => collectionAllProductosSource.View;

        //bool _buttonBoolVistas;
        //public bool buttonBoolVistas { get => _buttonBoolVistas; set { if (SetProperty(ref _buttonBoolVistas, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(buttonStringVistas)); swithchNavigator(); } } }
        //public string buttonStringVistas => buttonBoolVistas ? "Basica" : "Avanzada";


        //bool _buttonBoolBusqueda = true;
        //public bool buttonBoolBusqueda { get => _buttonBoolBusqueda; set { if (SetProperty(ref _buttonBoolBusqueda, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(buttonStringBusqueda)); textBoxStringBusqueda = ""; searchTimerRestart(); } } }
        //public string buttonStringBusqueda => buttonBoolBusqueda ? "Descripción" : "Codigo";


        //bool? _checkBoxBoolActive;
        //public bool? checkBoxBoolActive { get => _checkBoxBoolActive; set { if (SetProperty(ref _checkBoxBoolActive, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(checkBoxStringActive)); textBoxStringBusqueda = ""; searchTimerRestart(); } } }
        //public string checkBoxStringActive => checkBoxBoolActive is null ? "Todo" : checkBoxBoolActive == false ? "Solo Inactivos" : "Solo Activos";


        //string _textBoxStringBusqueda;
        //public string textBoxStringBusqueda { get => _textBoxStringBusqueda; set { if (SetProperty(ref _textBoxStringBusqueda, value)) { OnPropertyChanged(); searchTimerRestart(); } } }
        #endregion // Properties


        #region Helpers
        //void swithchNavigator()
        //{
        //    Navigator.CurrentViewModel = buttonBoolVistas ? new productosAdvancedViewModel() : new productosBasicViewModel();
        //}
        #endregion // Helpers


        #region Commands
        //public Command buttonCommandVistas => new Command((object parameter) => buttonBoolVistas = !buttonBoolVistas);

        //public Command buttonCommandBusqueda => new Command((object parameter) => Shared.Navigators.ContentTopNavigator.updateNavigator(null));

        public Command buttonCommandNewProducto => new Command((object parameter) => Shared.Navigators.ContentTopNavigator.updateNavigator(new Helpers.productoNewEditViewModel()));

        public Command buttonCommandModificarStock => new Command(
            (object parameter) => { Shared.Navigators.ContentTopNavigator.updateNavigator(new Helpers.stockEditViewModel(selectedProducto)); },
            (object parameter) => selectedProducto is not null);

        public Command butttonCommandEditProducto => new Command(
            (object parameter) => Shared.Navigators.ContentTopNavigator.updateNavigator(new Helpers.productoNewEditViewModel(selectedProducto)),
            (object parameter) => selectedProducto is not null);
        #endregion // Commands
    }
}
