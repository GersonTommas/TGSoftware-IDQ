using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Collections.ObjectModel;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainIngresosViewModel : Base.ViewModelBase
    {
        #region Initialize
        public mainIngresosViewModel() { }
        #endregion // Initialize


        #region Variables
        public ObservableCollection<fechaModel> sourceCollectionFechas => context.globalAllFechas;
        #endregion // Variables
    }
}
