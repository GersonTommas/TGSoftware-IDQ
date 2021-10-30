using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System.Collections.ObjectModel;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainDeudoresViewModel : Base.ViewModelBase
    {
        #region Initialize
        public INavigator Navigator { get; } = new Navigator();

        public mainDeudoresViewModel() { }
        #endregion // Initialize


        #region Variables
        bool _hidePaid;
        public bool hidePaid { get => _hidePaid; set { if (SetProperty(ref _hidePaid, value)) { OnPropertyChanged(); } } }

        deudorModel _passDeudor;
        public deudorModel passDeudor { get => _passDeudor; set { if (SetProperty(ref _passDeudor, value)) { OnPropertyChanged(); } } }

        bool _isAgrupadoPorFecha;
        public bool isAgrupadoPorFecha { get => _isAgrupadoPorFecha; set { if (SetProperty(ref _isAgrupadoPorFecha, value)) { OnPropertyChanged(); } } }

        public ObservableCollection<deudorModel> sourceCollectionDeudores => context.globalAllDeudores;
        #endregion // Variables



        #region Helpers
        void helperPagarDeuda()
        {

        }

        void helperEditarDeudor(deudorModel sentDeudor)
        {
            Shared.Navigators.ContentTopNavigator.updateNavigator(null); // Miss
        }
        #endregion // Helpers



        #region Commands
        public Command controlCommandPagarDeuda => new Command(
            (object parameter) => helperPagarDeuda(),
            (object parameter) => passDeudor is not null);

        public Command controlCommandNuevoDeudor => new Command(
            (object parameter) => helperEditarDeudor(null));

        public Command controlCommandEditarDeudor => new Command(
            (object parameter) => helperEditarDeudor(passDeudor),
            (object parameter) => passDeudor is not null);
        #endregion // Commands
    }
}
