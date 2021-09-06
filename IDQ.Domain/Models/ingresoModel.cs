using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class ingresoModel : Base.ModelBase
    {
        #region Private
        Double _PagadoPesos, _PagadoMP; String _Hora; string _Detalle; proveedorModel _Proveedor; usuarioModel _Usuario; fechaModel _Fecha;
        #endregion // Private


        #region Public
        public Double PagadoPesos { get => _PagadoPesos; set { if (SetProperty(ref _PagadoPesos, Math.Round(value, 2))) { OnPropertyChanged(); } } }
        public Double PagadoMP { get => _PagadoMP; set { if (SetProperty(ref _PagadoMP, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        public int ProveedorID { get; set; }
        public virtual proveedorModel Proveedor { get => _Proveedor; set { if (SetProperty(ref _Proveedor, value)) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
        public virtual ICollection<ingresoProductoModel> IngresoProductosPerIngreso { get; private set; } = new ObservableCollection<ingresoProductoModel>();
        #endregion // Navigation


        #region NotMapped
        [NotMapped]
        public Double PrecioTotal => Math.Round(IngresoProductosPerIngreso.Sum(x => x.PrecioTotal), 2);
        [NotMapped]
        public int ingresosCantidadProductosPerIngreso => IngresoProductosPerIngreso.Count();
        #endregion // NotMapped

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}

