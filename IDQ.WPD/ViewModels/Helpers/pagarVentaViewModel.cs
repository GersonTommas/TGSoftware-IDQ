using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class pagarVentaViewModel : Base.ViewModelBase
    {
        #region Initailize
        readonly VentasViewModel thisVenta;

        public pagarVentaViewModel() { }
        public pagarVentaViewModel(VentasViewModel sentVenta)
        {
            thisVenta = sentVenta;
            ventaTotal = thisVenta.newVenta.PrecioTotal;

            selectedDeudor = null;
        }
        #endregion // Initialize


        #region Properties
        Decimal _ventaTotal;
        public Decimal ventaTotal { get => _ventaTotal; set { if (SetProperty(ref _ventaTotal, value)) { OnPropertyChanged(); updateVuelto(); } } }

        Decimal _pagoEfectivo;
        public Decimal pagoEfectivo { get => _pagoEfectivo; set { if (SetProperty(ref _pagoEfectivo, value)) { OnPropertyChanged(); updateVuelto(); } } }

        Decimal _pagoMP;
        public Decimal pagoMP { get => _pagoMP; set { if (SetProperty(ref _pagoMP, value)) { OnPropertyChanged(); updateVuelto(); } } }

        public Decimal Vuelto => !isPagarDeuda ? (pagoEfectivo + pagoMP - ventaTotal) : selectedDeudor is not null ? (pagoEfectivo + pagoMP - ventaTotal - selectedDeudor.doubleDeudaTotal) : 0;

        public string vueltoString => isPagarDeuda && Vuelto <= 0 ? "Deuda Restante" : "Vuelto";

        bool _isPagarDeuda;
        public bool isPagarDeuda { get => _isPagarDeuda; set { if (SetProperty(ref _isPagarDeuda, value)) { OnPropertyChanged(); updateVuelto(); } } }

        bool _deudorVisibility;
        public bool deudorVisibility { get => _deudorVisibility; set { if (SetProperty(ref _deudorVisibility, value)) { OnPropertyChanged(); } } }

        deudorModel _selectedDeudor;
        public deudorModel selectedDeudor { get => _selectedDeudor; set { if (SetProperty(ref _selectedDeudor, value)) { OnPropertyChanged(); updateVuelto(); } } }

        public ObservableCollection<deudorModel> CollectionSourceDeudores => context.globalAllDeudores;
        #endregion // Properties


        #region Helpers
        void updateVuelto()
        {
            OnPropertyChanged(nameof(Vuelto)); OnPropertyChanged(nameof(vueltoString));
        }

        void helperGuardar()
        {
            thisVenta.helperGuardarVenta(new cajaModel() { Efectivo = pagoEfectivo, Fecha = Shared.GlobalVars.returnFecha(), Hora = globalStringHora, MercadoPago = pagoMP, Vuelto = Vuelto }, selectedDeudor, isPagarDeuda);
            Shared.Navigators.ContentTopNavigator.updateNavigator(null);
        }

        bool checkGuardar => selectedDeudor is not null || Vuelto >= 0;
        #endregion // Helpers


        #region Commands
        public Command controlCommandNuevoDeudor => new Command((object parameter) => { Shared.Navigators.VentaDeudorNavigator.updateNavigator(this); });

        public Command buttonCommandToggleDeudor => new Command(
            (object parameter) =>
            {
                if (deudorVisibility)
                {
                    selectedDeudor = null;
                    isPagarDeuda = false;
                }

                deudorVisibility = !deudorVisibility;
            });

        public Command controlCommandGuardarVenta => new Command(
            (object parameter) => { helperGuardar(); },
            (object parameter) => checkGuardar);


        public Command controlCommandCancelar => new Command((object parameter) => Shared.Navigators.ContentTopNavigator.updateNavigator(null));
        #endregion // Commands
    }
}
