using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class tagModel : Base.ModelBase
    {
        #region Variables
        int _Minimo;
        public int Minimo { get => _Minimo; set { if (SetProperty(ref _Minimo, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(fullTag)); } } }

        string _Tag;
        public string Tag { get => _Tag; set { if (SetProperty(ref _Tag, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(fullTag)); } } }

        bool _Activo;
        public bool Activo { get => _Activo; set { if (SetProperty(ref _Activo, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Computed Values
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual string fullTag => $"{Tag} {Minimo}";
        #endregion // Computed Values


        #region Navigation
        public virtual ICollection<productoModel> ProductosPerTag { get; private set; } = new ObservableCollection<productoModel>();
        #endregion // Navigation


        #region Not Mapped
        [NotMapped]
        public string FullTag => Tag + " " + Minimo.ToString(); // Deprecated?
        #endregion // Not Mapped


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
