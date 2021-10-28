using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class ingresoProductoModel : Base.ModelBase
    {
        #region Public
        int _Cantidad;
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); } } }

        Decimal _PrecioPagado;
        public Decimal PrecioPagado { get => _PrecioPagado; set { if (SetProperty(ref _PrecioPagado, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); OnPropertyChanged(nameof(PrecioSugerido)); } } }

        Decimal _PrecioActual;
        public Decimal PrecioActual { get => _PrecioActual; set { if (SetProperty(ref _PrecioActual, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        productoModel _Producto;
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        ingresoModel _Ingreso;
        public virtual ingresoModel Ingreso { get => _Ingreso; set { if (SetProperty(ref _Ingreso, value)) { OnPropertyChanged(); } } }
        #endregion // Public


        #region NotMapped
        [NotMapped]
        public Decimal PrecioTotal => Cantidad * PrecioPagado;

        [NotMapped]
        public Decimal PrecioSugerido => Math.Round(PrecioPagado * 1.3m, 2);
        #endregion // NotMapped


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}