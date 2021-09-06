﻿using System;

namespace IDQ.Domain.Models
{
    public class retiroCajaModel : Base.ModelBase
    {
        #region Private
        String _Hora; cajaModel _Caja; string _Detalle; bool _Pendiente; motivoRetiroModel _Motivo; fechaModel _Fecha; usuarioModel _UsuarioAutoriza, _UsuarioRetira; proveedorModel _Proveedor;
        #endregion // Private

        #region Public
        public int CajaID { get; set; }
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }

        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        public bool Pendiente { get => _Pendiente; set { if (SetProperty(ref _Pendiente, value)) { OnPropertyChanged(); } } }

        public int MotivoID { get; set; }
        public virtual motivoRetiroModel Motivo { get => _Motivo; set { if (SetProperty(ref _Motivo, value)) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int? ProveedorID { get; set; }
        public virtual proveedorModel Proveedor { get => _Proveedor; set { if (SetProperty(ref _Proveedor, value)) { OnPropertyChanged(); } } }

        public int UsuarioAutorizaID { get; set; }
        public virtual usuarioModel UsuarioAutoriza { get => _UsuarioAutoriza; set { if (SetProperty(ref _UsuarioAutoriza, value)) { OnPropertyChanged(); } } }

        public int UsuarioRetiraID { get; set; }
        public virtual usuarioModel UsuarioRetira { get => _UsuarioRetira; set { if (SetProperty(ref _UsuarioRetira, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}

