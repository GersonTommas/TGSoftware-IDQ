using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class usuarioModel : Base.ModelBase
    {
        #region Variables
        int _Nivel;
        public int Nivel { get => _Nivel; set { if (SetProperty(ref _Nivel, value)) { OnPropertyChanged(); } } }

        Decimal _Resto;
        public Decimal Resto { get => _Resto; set { if (SetProperty(ref _Resto, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        string _Nombre;
        public string Nombre { get => _Nombre; set { if (SetProperty(ref _Nombre, value)) { OnPropertyChanged(); } } }

        string _Apellido;
        public string Apellido { get => _Apellido; set { if (SetProperty(ref _Apellido, value)) { OnPropertyChanged(); } } }

        string _Usuario;
        public string Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        string _Detalle;
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        string _Contraseña;
        public string Contraseña { get => _Contraseña; set { if (SetProperty(ref _Contraseña, value)) { OnPropertyChanged(); } } }

        public string FechaSalida { get; set; } // Deprecated
        public string FechaIngreso { get; set; } // Deprecated

        fechaModel _FechaDeIngreso;
        public virtual fechaModel FechaDeIngreso { get => _FechaDeIngreso; set { if (SetProperty(ref _FechaDeIngreso, value)) { OnPropertyChanged(); } } } // New

        fechaModel _FechaDeEgreso;
        public virtual fechaModel FechaDeEgreso { get => _FechaDeEgreso; set { if (SetProperty(ref _FechaDeEgreso, value)) { OnPropertyChanged(); } } } // New

        bool _Activo;
        public bool Activo { get => _Activo; set { if (SetProperty(ref _Activo, value)) { OnPropertyChanged(); } } }
        #endregion // Variables

        #region Navigation
        public virtual ICollection<conteoModel> ConteosPerUsuario { get; private set; } = new ObservableCollection<conteoModel>();
        public virtual ICollection<cajaConteoModel> CajaConteosPerUsuario { get; private set; } = new ObservableCollection<cajaConteoModel>(); // Deprecated
        public virtual ICollection<deudorModel> DeudoresPerUsuario { get; private set; } = new ObservableCollection<deudorModel>();
        public virtual ICollection<sacadoProductoModel> SacadoProductosPerUsuario { get; private set; } = new ObservableCollection<sacadoProductoModel>();
        public virtual ICollection<ingresoModel> IngresosPerUsuario { get; private set; } = new ObservableCollection<ingresoModel>();
        public virtual ICollection<ventaModel> VentasPerUsuario { get; private set; } = new ObservableCollection<ventaModel>();
        public virtual ICollection<modificadoProductoModel> ModificadoProductosPerUsuario { get; private set; } = new ObservableCollection<modificadoProductoModel>();
        public virtual ICollection<abiertoProductoModel> AbiertoProductosPerUsuario { get; private set; } = new ObservableCollection<abiertoProductoModel>();

        [InverseProperty(nameof(retiroCajaModel.UsuarioAutoriza))]
        public virtual ICollection<retiroCajaModel> RetirosAutorizaPerUsuario { get; private set; } = new ObservableCollection<retiroCajaModel>();
        [InverseProperty(nameof(retiroCajaModel.UsuarioRetira))]
        public virtual ICollection<retiroCajaModel> RetirosRetiraPerUsuario { get; private set; } = new ObservableCollection<retiroCajaModel>();
        #endregion // Navigation

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
