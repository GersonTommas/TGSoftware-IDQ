using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class pagarCompraViewModel : Base.ViewModelBase
    {
        #region Initialize
        public pagarCompraViewModel() { Shared.Navigators.ContentTopNavigator.updateNavigator(null); }
        public pagarCompraViewModel(ComprasViewModel sentCompra)
        {
            if (sentCompra is not null)
            {
                _sentCompra = sentCompra;
                Total = sentCompra.newIngreso.PrecioTotal;
            }
            else
            {
                Shared.Navigators.ContentTopNavigator.updateNavigator(null);
            }
        }
        #endregion // Initialize



        #region Properties
        public ObservableCollection<proveedorModel> sourceCollectionProveedores => context.globalDb.proveedores.Local.ToObservableCollection();

        proveedorModel _selectedProveedor;
        public proveedorModel selectedProveedor { get => _selectedProveedor; set { if (SetProperty(ref _selectedProveedor, value)) { OnPropertyChanged(); } } }

        ComprasViewModel _sentCompra;
        public ComprasViewModel sentCompra => _sentCompra;

        Decimal _Total;
        public Decimal Total { get => _Total; set { if (SetProperty(ref _Total, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(Vuelto)); } } }

        Decimal _Efectivo;
        public Decimal Efectivo { get => _Efectivo; set { if (SetProperty(ref _Efectivo, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(Vuelto)); } } }

        Decimal _MercadoPago;
        public Decimal MercadoPago { get => _MercadoPago; set { if (SetProperty(ref _MercadoPago, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(Vuelto)); } } }

        public Decimal Vuelto => Efectivo + MercadoPago - Total;
        #endregion // Properties



        #region Helpers
        void helperGuardar()
        {
            sentCompra.helperPagar(selectedProveedor, Efectivo, MercadoPago, Vuelto);

            Shared.Navigators.ContentTopNavigator.updateNavigator(null);
        }
        #endregion // Helpers



        #region Checkers
        bool checkerGuardar => selectedProveedor is not null;
        #endregion // Checkers



        #region Commands
        public Command controlCommandGuardar => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkerGuardar);

        public Command controlCommandCancelar => new Command((object parameter) => Shared.Navigators.ContentTopNavigator.updateNavigator(null));
        #endregion // Commands
    }
}
