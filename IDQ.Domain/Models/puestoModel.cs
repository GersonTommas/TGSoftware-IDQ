using System;

namespace IDQ.Domain.Models
{
    public class puestoModel : Base.ModelBase
    {
        #region Private
        int _HorasMensuales; Decimal _Sueldo; string _Nombre;
        #endregion // Private

        #region Public
        public int HorasMensuales { get => _HorasMensuales; set { if (SetProperty(ref _HorasMensuales, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(NmSueldoMensual)); } } }

        public Decimal Sueldo { get => _Sueldo; set { if (SetProperty(ref _Sueldo, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(NmSueldoMensual)); } } }

        public string Nombre { get => _Nombre; set { if (SetProperty(ref _Nombre, value)) { OnPropertyChanged(); } } }
        #endregion // Public

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
