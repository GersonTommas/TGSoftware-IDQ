using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class ingresoProductoModel : Base.ModelBase
    {
        #region Private
        int _Cantidad; Decimal _PrecioPagado, _PrecioActual; productoModel _Producto; ingresoModel _Ingreso;
        #endregion // Private


        #region Public
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); } } }
        public Decimal PrecioPagado { get => _PrecioPagado; set { if (SetProperty(ref _PrecioPagado, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); OnPropertyChanged(nameof(PrecioSugerido)); } } }
        public Decimal PrecioActual { get => _PrecioActual; set { if (SetProperty(ref _PrecioActual, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        public int ProductoID { get; set; }
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        public int IngresoID { get; set; }
        public virtual ingresoModel Ingreso { get => _Ingreso; set { if (SetProperty(ref _Ingreso, value)) { OnPropertyChanged(); } } }
        #endregion // Public


        #region NotMapped
        [NotMapped]
        public Decimal PrecioTotal => Math.Round(Cantidad * PrecioPagado, 2);

        [NotMapped]
        public Decimal PrecioSugerido => Math.Round(PrecioPagado * 1.3m, 2);
        #endregion // NotMapped

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}