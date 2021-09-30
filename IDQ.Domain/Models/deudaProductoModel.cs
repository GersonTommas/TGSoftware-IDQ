using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class deudaProductoModel : Base.ModelBase
    {
        #region Variables
        int _CantidadAdeudada;
        public int CantidadAdeudada { get => _CantidadAdeudada; set { if (SetProperty(ref _CantidadAdeudada, value)) { OnPropertyChanged(); } } }

        int _CantidadFaltante;
        public int CantidadFaltante { get => _CantidadFaltante; set { if (SetProperty(ref _CantidadFaltante, value)) { OnPropertyChanged(); } } }

        Decimal _Precio;
        public Decimal Precio { get => _Precio; set { if (SetProperty(ref _Precio, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(precioFinal)); } } }

        Decimal _PrecioPagado;
        public Decimal PrecioPagado { get => _PrecioPagado; set { if (SetProperty(ref _PrecioPagado, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        public int ProductoID { get; set; }
        productoModel _Producto;
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        public int DeudaID { get; set; }
        deudaModel _Deuda;
        public virtual deudaModel Deuda { get => _Deuda; set { if (SetProperty(ref _Deuda, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region NotMapped
        [NotMapped]
        public Decimal precioFinal => CantidadFaltante > 0
                                        ? Deuda?.Deudor != null
                                            ? Deuda.Deudor.Nivel switch
                                            {
                                                1 => Math.Round(Precio, 2),
                                                2 => Math.Round(Producto.PrecioActual, 2),
                                                _ => Math.Round(Producto.PrecioActual * 1.05m, 2),
                                            }
                                            : Math.Round(PrecioPagado, 2)
                                        : 0;
        [NotMapped]
        public Decimal TotalFaltante { get { OnPropertyChanged(nameof(precioFinal)); return Math.Round(precioFinal * CantidadFaltante, 2); } }
        #endregion // NotMapped


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
