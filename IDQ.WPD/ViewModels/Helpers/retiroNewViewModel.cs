using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class retiroNewViewModel : Base.ViewModelBase
    {
        #region Initialize
        public INavigator RetiroMotivoNewNavigator => Shared.Navigators.RetiroMotivoNavigator;

        public retiroNewViewModel() { }
        #endregion // Initialize



        #region Properties
        public ObservableCollection<motivoRetiroModel> CollectionSourceMotivos => context.globalDb.retiroMotivos.Local.ToObservableCollection();
        public ObservableCollection<usuarioModel> CollectionSourceRetira => context.globalAllUsuarios;
        public ObservableCollection<usuarioModel> CollectionSourceAutoriza => context.globalAllUsuarios;

        motivoRetiroModel _selectedMotivo;
        public motivoRetiroModel selectedMotivo { get => _selectedMotivo; set { if (SetProperty(ref _selectedMotivo, value)) { OnPropertyChanged(); } } }

        Decimal _Efectivo;
        public Decimal Efectivo { get => _Efectivo; set { if (SetProperty(ref _Efectivo, value)) { OnPropertyChanged(); } } }

        Decimal _MercadoPago;
        public Decimal MercadoPago { get => _MercadoPago; set { if (SetProperty(ref _MercadoPago, value)) { OnPropertyChanged(); } } }

        string _Detalle;
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        usuarioModel _selectedUsuarioRetira;
        public usuarioModel selectedUsuarioRetira { get => _selectedUsuarioRetira; set { if (SetProperty(ref _selectedUsuarioRetira, value)) { OnPropertyChanged(); } } }

        usuarioModel _selectedUsuarioAutoriza;
        public usuarioModel selectedUsuarioAutoriza { get => _selectedUsuarioAutoriza; set { if (SetProperty(ref _selectedUsuarioAutoriza, value)) { OnPropertyChanged(); } } }
        #endregion // Properties



        #region Helpers
        void helperGuardar(object parameter)
        {
            if (parameter is PasswordBox passBox)
            {
                if (selectedUsuarioAutoriza.Contraseña != passBox.Password)
                {
                    Shared.GlobalErrors.Usuario();

                    passBox.SelectAll();
                }
                else
                {
                    fechaModel newFecha = context.returnFecha();
                    String newHora = globalStringHora;

                    retiroCajaModel newRetiro = new retiroCajaModel()
                    {
                        Fecha = newFecha,
                        Hora = newHora,
                        Caja = new cajaModel()
                        {
                            Fecha = newFecha,
                            Hora = newHora,
                            Efectivo = Efectivo,
                            MercadoPago = MercadoPago,
                            isDebito = true
                        },
                        Detalle = Detalle,
                        Motivo = selectedMotivo,
                        UsuarioAutoriza = selectedUsuarioAutoriza,
                        UsuarioRetira = selectedUsuarioRetira
                    };

                    context.globalCajaActual.Efectivo -= Efectivo;
                    context.globalCajaActual.MercadoPago -= MercadoPago;

                    context.globalDb.retiros.Local.Add(newRetiro);
                    _ = context.globalDb.SaveChanges();
                }
            }
        }
        #endregion // Helpers



        #region Commands
        public Command controlCommandGuardar => new Command(
            (object parameter) => helperGuardar(parameter),
            (object parameter) => (Efectivo > 0 || MercadoPago > 0) && selectedUsuarioRetira is not null && selectedUsuarioAutoriza is not null);

        public Command controlCommandNewMotivo => new Command((object parameter) => Shared.Navigators.RetiroMotivoNavigator.updateNavigator(new motivoNewViewModel()));

        public Command controlCommandCancelar => new Command((Object parameter) => Shared.Navigators.ContentTopNavigator.updateNavigator(null));
        #endregion // Commands
    }
}
