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
    public class pagarDeudaViewModel : Base.ViewModelBase
    {
        #region Initialize
        public pagarDeudaViewModel() { Shared.Navigators.ContentTopNavigator.updateNavigator(null); }

        public pagarDeudaViewModel(deudorModel sentDeudor)
        {
            if (sentDeudor is null) { Shared.Navigators.ContentTopNavigator.updateNavigator(null); }
            else { Deudor = sentDeudor; }
        }
        #endregion // Initialize


        #region Properties
        //public ObservableCollection<proveedorModel> CollectionSourceProveedores => context.globalDb.proveedores.Local.ToObservableCollection();

        Decimal _Efectivo;
        public Decimal Efectivo { get => _Efectivo; set { if (SetProperty(ref _Efectivo, value)) { OnPropertyChanged(); } } }

        Decimal _MercadoPago;
        public Decimal MercadoPago { get => _MercadoPago; set { if (SetProperty(ref _MercadoPago, value)) { OnPropertyChanged(); } } }

        public Decimal Vuelto => Deudor is not null ? Efectivo + MercadoPago - Deudor.doubleFaltanteTotal : 0;
        public Decimal Resto => Deudor is not null ? Deudor.doubleFaltanteTotal - Efectivo - MercadoPago : 0;

        public deudorModel Deudor { get; set; }
        #endregion // Properties


        #region Helpers
        void helperGuardar()
        {
            fechaModel tempToday = Shared.GlobalVars.returnFecha();
            String tempNow = globalStringHora;

            Decimal tempVuelto = Deudor.updatePagarAllDeudas(Efectivo + MercadoPago + Deudor.Resto, tempToday);

            deudorPagoModel newPago = new deudorPagoModel() { Caja = new cajaModel() { Efectivo = Efectivo, Fecha = tempToday, Hora = tempNow, MercadoPago = MercadoPago, Vuelto = tempVuelto }, Deudor = Deudor, Fecha = tempToday };

            context.globalDb.deudorPagos.Local.Add(newPago);
            _ = context.globalDb.SaveChanges();
        }

        bool checkGuardar => true;
        #endregion // Helpers


        #region Commands
        public Command controlCommandCancelar => new Command((object parameter) => Shared.Navigators.ContentTopNavigator.updateNavigator(null));

        public Command buttonCommandGuardar => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
