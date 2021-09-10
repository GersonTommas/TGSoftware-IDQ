using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainVentasViewModel : Base.ViewModelBase
    {
        public mainVentasViewModel() { }

        public ObservableCollection<fechaModel> sourceCollectionFechas => context.globalDb.fechas.Local.ToObservableCollection();
    }
}
