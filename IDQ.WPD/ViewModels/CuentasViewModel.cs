using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.WPF.ViewModels
{
    public class CuentasViewModel : Base.ViewModelBase
    {
        #region Initialize
        public CuentasViewModel() { }
        #endregion // Initialize


        #region Variables
        public ObservableCollection<usuarioModel> collectionSourceUsuarios => context.globalAllUsuarios;
        #endregion // Variables


        #region Commands
        #endregion // Commands
    }
}
