using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Collections.ObjectModel;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainVentasViewModel : Base.ViewModelBase
    {
        #region Initialize
        public mainVentasViewModel() { }
        #endregion // Initialize


        #region Variables
        public ObservableCollection<fechaModel> sourceCollectionFechas => context.globalAllFechas;
        #endregion // Variables
    }
}