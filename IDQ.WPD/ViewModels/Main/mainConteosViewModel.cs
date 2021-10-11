using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
