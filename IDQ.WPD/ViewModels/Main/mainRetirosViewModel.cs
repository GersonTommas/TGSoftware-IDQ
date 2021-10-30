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
    public class mainRetirosViewModel : Base.ViewModelBase
    {
        #region Initialize
        public mainRetirosViewModel() { }
        #endregion // Initialize



        #region Properties
        public ObservableCollection<retiroCajaModel> CollectionSourceRetiros => context.globalDb.retiros.Local.ToObservableCollection();
        #endregion // Properties



        #region Commands
        public Command controlCommandNuevoRetiro => new Command(
            (object parameter) => { });
        #endregion // Commands
    }
}
