using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class ventaProductoModel : Base.ModelBase
    {
        #region Private
        int _Cantidad, _CantidadDeuda, _CantidadFaltante; Decimal _Precio, _PrecioPagado; productoModel _Producto; ventaModel _Venta; deudorModel _Deudor; fechaModel _FechaPagado;
        #endregion // Private

        #region Public
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); } } }
        public int CantidadDeuda { get => _CantidadDeuda; set { if (SetProperty(ref _CantidadDeuda, value)) { OnPropertyChanged(); } } } // Deprecated
        public int CantidadFaltante { get => _CantidadFaltante; set { if (SetProperty(ref _CantidadFaltante, value)) { OnPropertyChanged(); } } } // Deprecated

        public Decimal Precio { get => _Precio; set { if (SetProperty(ref _Precio, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); } } }
        public Decimal PrecioPagado { get => _PrecioPagado; set { if (SetProperty(ref _PrecioPagado, Math.Round(value, 2))) { OnPropertyChanged(); } } } // Deprecated

        public int ProductoID { get; set; }
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        public int VentaID { get; set; }
        public virtual ventaModel Venta { get => _Venta; set { if (SetProperty(ref _Venta, value)) { OnPropertyChanged(); } } }

        public int? FechaPagadoID { get; set; }
        public virtual fechaModel FechaPagado { get => _FechaPagado; set { if (SetProperty(ref _FechaPagado, value)) { OnPropertyChanged(); } } } // Deprecated

        public int? DeudorID { get; set; }
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } } // Deprecated
        #endregion // Public

        #region Navigation
        public virtual ICollection<cajaModel> CajasPerVentaProducto { get; private set; } = new ObservableCollection<cajaModel>();
        public virtual ICollection<deudorPagoModel> deudorPagosPerVentaProducto { get; private set; } = new ObservableCollection<deudorPagoModel>();
        #endregion // Navigation


        #region NotMapped
        [NotMapped]
        public Decimal PrecioTotal => Math.Round(Cantidad * Precio, 2);

        [NotMapped]
        public int isProductoDeuda => CantidadDeuda == 0 ? 0 : CantidadDeuda < Cantidad ? 1 : 2; // Deprecated
        [NotMapped]
        public int isDeudaPagada => CantidadFaltante == 0 ? 0 : CantidadFaltante != CantidadDeuda ? 1 : 2; // Deprecated
        [NotMapped]
        public bool BolPagado => CantidadFaltante == 0; // Deprecated

        [NotMapped]
        public Decimal PrecioFinal => Deudor != null
                                        ? !BolPagado
                                            ? Deudor.Nivel switch
                                            {
                                                1 => Math.Round(Precio, 2),
                                                2 => Math.Round(Producto.PrecioActual, 2),
                                                _ => Math.Round(Producto.PrecioActual * 1.05m, 2),
                                            }
                                            : Math.Round(PrecioPagado, 2)
                                        : 0; // Deprecated
        [NotMapped]
        public Decimal TotalFaltante { get { OnPropertyChanged(nameof(PrecioFinal)); return Math.Round(PrecioFinal * CantidadFaltante, 2); } } // Deprecated
        #endregion // NotMapped

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
