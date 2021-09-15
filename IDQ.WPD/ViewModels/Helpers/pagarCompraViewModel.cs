using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class pagarCompraViewModel : Base.ViewModelBase
    {
        public pagarCompraViewModel() { }

        public ObservableCollection<proveedorModel> sourceCollectionProveedores => context.globalDb.proveedores.Local.ToObservableCollection();
    }
}
