using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.Domain.Models
{
    public class medidaModel : Base.ModelBase
    {
        #region Properties
        int _Tipo; // Deprecated
        public int Tipo { get => _Tipo; set { if (SetProperty(ref _Tipo, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(TipoShort)); OnPropertyChanged(nameof(fullMedida)); } } } // Deprecated

        medidaSelectorModel _TipoSelector;
        public virtual medidaSelectorModel TipoSelector { get => _TipoSelector; set { if (SetProperty(ref _TipoSelector, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(fullMedida)); } } }

        string _Medida;
        public string Medida { get => _Medida; set { if (SetProperty(ref _Medida, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(fullMedida)); } } }

        bool _Activo;
        public bool Activo { get => _Activo; set { if (SetProperty(ref _Activo, value)) { OnPropertyChanged(); } } }
        #endregion // Properties


        #region Navigation
        public virtual ICollection<productoModel> ProductosPerMedida { get; private set; } = new ObservableCollection<productoModel>();
        #endregion // Navigation


        #region NotMapped
        [NotMapped] // Deprecated
        public string TipoShort // Deprecated
        {
            get => Tipo switch
            {
                1 => "cm",
                2 => "cc",
                3 => "g",
                4 => "Kg",
                5 => "L",
                6 => "ml",
                7 => "u",
                8 => "Par",
                9 => "w",
                10 => "Kw",
                11 => "v",
                12 => "Talle",
                13 => "mg",
                14 => "cl",
                _ => "",
            };
            set
            {
                Tipo = value switch
                {
                    "cm" => 1,
                    "cc" => 2,
                    "g" => 3,
                    "Kg" => 4,
                    "L" => 5,
                    "ml" => 6,
                    "u" => 7,
                    "Par" => 8,
                    "w" => 9,
                    "Kw" => 10,
                    "v" => 11,
                    "Talle" => 12,
                    "mg" => 13,
                    "cl" => 14,
                    _ => 0,
                }; OnPropertyChanged();
            }
        }

        [NotMapped]
        public string fullMedida => TipoSelector is not null ? Medida + TipoSelector.Tipo : Medida; // Medida + TipoShort;
        #endregion // NotMapped


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}

