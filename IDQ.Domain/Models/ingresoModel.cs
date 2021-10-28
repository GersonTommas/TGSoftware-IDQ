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
        //Decimal _PagadoPesos; // Deprecated
        public Decimal PagadoPesos { get; private set; }// { get => _PagadoPesos; set { if (SetProperty(ref _PagadoPesos, Math.Round(value, 2))) { OnPropertyChanged(); } } } // Deprecated

        //Decimal _PagadoMP; // Deprecated
        public Decimal PagadoMP { get; private set; } //{ get => _PagadoMP; set { if (SetProperty(ref _PagadoMP, Math.Round(value, 2))) { OnPropertyChanged(); } } } // Deprecated

        Decimal _PrecioTotal;
        public Decimal PrecioTotal { get => _PrecioTotal; set { if (SetProperty(ref _PrecioTotal, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        String _Hora;
        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        string _Detalle;
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        proveedorModel _Proveedor;
        public virtual proveedorModel Proveedor { get => _Proveedor; set { if (SetProperty(ref _Proveedor, value)) { OnPropertyChanged(); } } }

        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int? CajaId { get; private set; }
        cajaModel _Caja;
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }
        #endregion // Variables

        #region Navigation
        public virtual ICollection<ingresoProductoModel> IngresoProductosPerIngreso { get; private set; } = new ObservableCollection<ingresoProductoModel>();
        #endregion // Navigation


        #region NotMapped
        [NotMapped] // Deprecated
        public int ingresosCantidadProductosPerIngreso => IngresoProductosPerIngreso.Count; // Deprecated
        #endregion // NotMapped

        public override void updateModel()
        {
            PrecioTotal = IngresoProductosPerIngreso.Sum(x => x.PrecioPagado * x.Cantidad);
            base.updateModel();
        }
    }
}

