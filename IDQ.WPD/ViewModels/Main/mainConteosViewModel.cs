using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Collections.ObjectModel;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainConteosViewModel : Base.ViewModelBase
    {
        #region Initialize
        public mainConteosViewModel() { }
        #endregion // Initialize


        #region Properties
        public ObservableCollection<fechaModel> CollectionSourceFechas => context.globalAllFechas;
        #endregion // Properties
    }
}
