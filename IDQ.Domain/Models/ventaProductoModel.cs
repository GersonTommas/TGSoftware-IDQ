﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class ventaProductoModel : Base.ModelBase
    {
        #region Variables
        int _Cantidad;
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); } } }

        Decimal _Precio;
        public Decimal Precio { get => _Precio; set { if (SetProperty(ref _Precio, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); } } }

        public int ProductoID { get; set; }
        productoModel _Producto;
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        public int VentaID { get; set; }
        ventaModel _Venta;
        public virtual ventaModel Venta { get => _Venta; set { if (SetProperty(ref _Venta, value)) { OnPropertyChanged(); } } }


        public int? FechaPagadoID { get; set; } // Deprecated
        public virtual fechaModel FechaPagado { get; set; } // Deprecated

        public int? DeudorID { get; set; } // Deprecated
        public virtual deudorModel Deudor { get; set; } // Deprecated

        public int CantidadDeuda { get; set; } // Deprecated

        public int CantidadFaltante { get; set; } // Deprecated

        public Decimal PrecioPagado { get; set; } // Deprecated
        #endregion // Variables


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
