using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IDQ.Domain.Models
{
    public class proveedorModel : Base.ModelBase
    {
        #region Variables
        string _Nombre;
        public string Nombre { get => _Nombre; set { if (SetProperty(ref _Nombre, value)) { OnPropertyChanged(); } } }

        string _Direccion;
        public string Direccion { get => _Direccion; set { if (SetProperty(ref _Direccion, value)) { OnPropertyChanged(); } } }

        string _NumeroDeCliente;
        public string NumeroDeCliente { get => _NumeroDeCliente; set { if (SetProperty(ref _NumeroDeCliente, value)) { OnPropertyChanged(); } } }

        string _Detalles;
        public string Detalles { get => _Detalles; set { if (SetProperty(ref _Detalles, value)) { OnPropertyChanged(); } } }

        int? _Telefono;
        public int? Telefono { get => _Telefono; set { if (SetProperty(ref _Telefono, value)) { OnPropertyChanged(); } } }

        int? _Celular;
        public int? Celular { get => _Celular; set { if (SetProperty(ref _Celular, value)) { OnPropertyChanged(); } } }

        bool _Activo;
        public bool Activo { get => _Activo; set { if (SetProperty(ref _Activo, value)) { OnPropertyChanged(); } } }
        #endregion // Variables

        #region Navigation
        public virtual ICollection<ingresoModel> IngresosPerProveedor { get; private set; } = new ObservableCollection<ingresoModel>();
        public virtual ICollection<retiroCajaModel> RetirosCajaPerProveedor { get; private set; } = new ObservableCollection<retiroCajaModel>();
        #endregion // Navigation

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
