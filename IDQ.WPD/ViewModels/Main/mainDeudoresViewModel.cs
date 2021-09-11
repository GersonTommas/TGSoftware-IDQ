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
    public class mainDeudoresViewModel : Base.ViewModelBase
    {
        public mainDeudoresViewModel() { }

        bool _hidePaid;
        public bool hidePaid { get => _hidePaid; set { if (SetProperty(ref _hidePaid, value)) { OnPropertyChanged(); } } }

        public ObservableCollection<deudorModel> sourceCollectionDeudores => context.globalAllDeudores;
    }
}
