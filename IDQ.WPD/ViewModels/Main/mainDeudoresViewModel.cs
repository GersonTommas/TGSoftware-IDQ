using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels.Main.Deudores;
using System.Collections.ObjectModel;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainDeudoresViewModel : Base.ViewModelBase
    {
        #region Initialize
        public INavigator Navigator { get; } = new Navigator();

        public mainDeudoresViewModel()
        {
            Navigator.CurrentViewModel = new deudoresListaViewModel();
        }
        #endregion // Initialize


        #region Variables
        bool _hidePaid;
        public bool hidePaid { get => _hidePaid; set { if (SetProperty(ref _hidePaid, value)) { OnPropertyChanged(); } } }

        bool _isLista = true;
        public string buttonStringListaFecha => _isLista ? "Fecha" : "Lista";

        //ObservableCollection<fechaModel> collectionSourceFechas => context.globalAllFechas;

        deudorModel _passDeudor;
        public deudorModel passDeudor { get => _passDeudor; set { if (SetProperty(ref _passDeudor, value)) { OnPropertyChanged(); } } }

        bool _isAgrupadoPorFecha;
        public bool isAgrupadoPorFecha { get => _isAgrupadoPorFecha; set { if (SetProperty(ref _isAgrupadoPorFecha, value)) { OnPropertyChanged(); } } }

        public ObservableCollection<deudorModel> sourceCollectionDeudores => context.globalAllDeudores;
        #endregion // Variables


        #region Commands
        public Command buttonCommandListaFecha => new Command(
            (object parameter) => { Navigator.CurrentViewModel = _isLista ? new deudoresFechaViewModel() : new deudoresListaViewModel(); _isLista = !_isLista; OnPropertyChanged(nameof(buttonStringListaFecha)); });
        #endregion // Commands
    }
}
