using System;

namespace IDQ.Domain.Models
{
    public class cajaConteoModel : Base.ModelBase
    {
        #region Private
        Double _Diferencia; string _Detalle; bool _Salida; cajaModel _Caja; usuarioModel _Usuario;
        #endregion // Private

        #region Public
        public Double Diferencia { get => _Diferencia; set { if (SetProperty(ref _Diferencia, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        public bool Salida { get => _Salida; set { if (SetProperty(ref _Salida, value)) { OnPropertyChanged(); } } }

        public int CajaID { get; set; }
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
