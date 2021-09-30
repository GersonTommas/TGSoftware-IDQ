using System;

namespace IDQ.Domain.Models
{
    public class puestoModel : Base.ModelBase
    {
        #region Variables
        int _HorasMensuales;
        public int HorasMensuales { get => _HorasMensuales; set { if (SetProperty(ref _HorasMensuales, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(NmSueldoMensual)); } } }

        Decimal _Sueldo;
        public Decimal Sueldo { get => _Sueldo; set { if (SetProperty(ref _Sueldo, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(NmSueldoMensual)); } } }

        string _Nombre;
        public string Nombre { get => _Nombre; set { if (SetProperty(ref _Nombre, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Navigation

        #endregion // Navigation

        #region NotMapped
        public Decimal NmSueldoMensual => Math.Round(Sueldo * HorasMensuales, 2);
        #endregion // NotMapped


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
