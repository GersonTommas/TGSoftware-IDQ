using IDQ.Domain.Models;
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
        public HelperFullWindow()
        {
            InitializeComponent(); DataContext = this;
        }
        public HelperFullWindow(Base.ViewModelBase sentViewModel)
        {
            InitializeComponent(); DataContext = this; Navigator.CurrentViewModel = sentViewModel;
        }

        public HelperFullWindow(Base.ViewModelBase sentViewModel, ViewModels.VentasViewModel resultViewModel)
        {
            InitializeComponent(); DataContext = this; Navigator.CurrentViewModel = sentViewModel; ResultViewModel = resultViewModel;
        }


        public INavigator Navigator = new Navigator();

        public ViewModels.VentasViewModel ResultViewModel;

        productoModel _BuscadorSelectedProducto;
        public productoModel BuscadorSelectedProducto { get => _BuscadorSelectedProducto; set { if (SetProperty(ref _BuscadorSelectedProducto, value)) { OnPropertyChanged(); } } }

        bool _BuscadorisOnlyOne;
        public bool BuscadorisOnlyOne { get => _BuscadorisOnlyOne; set { if (SetProperty(ref _BuscadorisOnlyOne, value)) { OnPropertyChanged(); } } }



        public Command ctrlBuscadorAddCommand => new Command(
            (object parameter) => { ResultViewModel.newVentaProducto.Producto = BuscadorSelectedProducto; this.Close(); },
            (object parameter) => BuscadorisOnlyOne);


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
    }
}