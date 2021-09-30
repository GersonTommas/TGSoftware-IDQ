using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class ingresoModel : Base.ModelBase
    {
        #region Variables
        Decimal _PagadoPesos;
        public Decimal PagadoPesos { get => _PagadoPesos; set { if (SetProperty(ref _PagadoPesos, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        Decimal _PagadoMP;
        public Decimal PagadoMP { get => _PagadoMP; set { if (SetProperty(ref _PagadoMP, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        Decimal _PrecioTotal;
        public Decimal PrecioTotal { get => _PrecioTotal; set { if (SetProperty(ref _PrecioTotal, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        String _Hora;
        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        string _Detalle;
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        public int ProveedorID { get; set; }
        proveedorModel _Proveedor;
        public virtual proveedorModel Proveedor { get => _Proveedor; set { if (SetProperty(ref _Proveedor, value)) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }
        #endregion // Variables

        #region Navigation
        public virtual ICollection<ingresoProductoModel> IngresoProductosPerIngreso { get; private set; } = new ObservableCollection<ingresoProductoModel>();
        #endregion // Navigation


        #region NotMapped
        [NotMapped]
        public int ingresosCantidadProductosPerIngreso => IngresoProductosPerIngreso.Count;
        #endregion // NotMapped

        public override void updateModel()
        {
            PrecioTotal = IngresoProductosPerIngreso.Sum(x => x.PrecioActual * x.Cantidad);
            base.updateModel();
        }
    }
}

