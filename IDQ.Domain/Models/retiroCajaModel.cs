using System;

namespace IDQ.Domain.Models
{
    public class retiroCajaModel : Base.ModelBase
    {
        #region Variables
        public int CajaID { get; set; }
        cajaModel _Caja;
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }

        String _Hora;
        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        string _Detalle;
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        bool _Pendiente;
        public bool Pendiente { get => _Pendiente; set { if (SetProperty(ref _Pendiente, value)) { OnPropertyChanged(); } } }

        public int MotivoID { get; set; }
        motivoRetiroModel _Motivo;
        public virtual motivoRetiroModel Motivo { get => _Motivo; set { if (SetProperty(ref _Motivo, value)) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int? ProveedorID { get; set; }
        proveedorModel _Proveedor;
        public virtual proveedorModel Proveedor { get => _Proveedor; set { if (SetProperty(ref _Proveedor, value)) { OnPropertyChanged(); } } }

        public int UsuarioAutorizaID { get; set; }
        usuarioModel _UsuarioAutoriza;
        public virtual usuarioModel UsuarioAutoriza { get => _UsuarioAutoriza; set { if (SetProperty(ref _UsuarioAutoriza, value)) { OnPropertyChanged(); } } }

        public int UsuarioRetiraID { get; set; }
        usuarioModel _UsuarioRetira;
        public virtual usuarioModel UsuarioRetira { get => _UsuarioRetira; set { if (SetProperty(ref _UsuarioRetira, value)) { OnPropertyChanged(); } } }
        #endregion // Variables

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}

