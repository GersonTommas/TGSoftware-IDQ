using System;

namespace IDQ.Domain.Models
{
    public class jornadaModel : Base.ModelBase
    {
        #region Public
        int _HorasTrabajadas;
        public int HorasTrabajadas { get => _HorasTrabajadas; set { if (SetProperty(ref _HorasTrabajadas, value)) { OnPropertyChanged(); } } }

        int _HorasExtra;
        public int HorasExtra { get => _HorasExtra; set { if (SetProperty(ref _HorasExtra, value)) { OnPropertyChanged(); } } }

        String _AñoMes;
        public String AñoMes { get => _AñoMes; set { if (SetProperty(ref _AñoMes, Convert.ToDateTime(value).ToString("yyyy/MM"))) { OnPropertyChanged(); } } }

        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Public


        #region Navigation
        #endregion // Navigation


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}