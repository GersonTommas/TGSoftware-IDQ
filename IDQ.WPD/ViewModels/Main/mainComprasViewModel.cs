using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Collections.ObjectModel;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainComprasViewModel : Base.ViewModelBase
    {
        #region Initialize
        public mainComprasViewModel() { }
        #endregion // Initialize


        #region Variables
        public ObservableCollection<fechaModel> sourceCollectionFechas => context.globalAllFechas;
        #endregion // Variables
    }
}
