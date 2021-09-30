using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IDQ.Domain.Models
{
    public class motivoRetiroModel : Base.ModelBase
    {
        #region Variables
        string _Motivo;
        public string Motivo { get => _Motivo; set { if (SetProperty(ref _Motivo, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Navigation
        public virtual ICollection<retiroCajaModel> Retiros { get; private set; } = new ObservableCollection<retiroCajaModel>();
        #endregion // Navigation


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
