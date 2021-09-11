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
    public class mainIngresosViewModel : Base.ViewModelBase
    {
        public mainIngresosViewModel() { }

        public ObservableCollection<fechaModel> sourceCollectionFechas => context.globalAllFechas;
    }
}
