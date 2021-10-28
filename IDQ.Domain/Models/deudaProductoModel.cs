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
        public int CantidadFaltante { get => _CantidadFaltante; set { if (SetProperty(ref _CantidadFaltante, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(TotalFaltante)); } } }

        Decimal _Precio;
        public Decimal Precio { get => _Precio; set { if (SetProperty(ref _Precio, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(precioFinal)); } } }

        Decimal _PrecioPagado;
        public Decimal PrecioPagado { get => _PrecioPagado; set { if (SetProperty(ref _PrecioPagado, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        productoModel _Producto;
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        deudaModel _Deuda;
        public virtual deudaModel Deuda { get => _Deuda; set { if (SetProperty(ref _Deuda, value)) { OnPropertyChanged(); } } }

        deudorModel _Deudor;
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region NotMapped
        [NotMapped]
        public Decimal precioFinal => Math.Round(updatePrecioFinal(CantidadFaltante, Deuda?.Deudor, Precio, Producto, PrecioPagado), 2);
        //[NotMapped]
        //public Decimal precioFinal => CantidadFaltante > 0
        //                                ? Deuda?.Deudor is not null
        //                                    ? Deuda.Deudor.Nivel switch
        //                                    {
        //                                        1 => Math.Round(Precio, 2),
        //                                        2 => Math.Round(Producto.PrecioActual, 2),
        //                                        _ => Math.Round(Producto.PrecioActual * 1.05m, 2),
        //                                    }
        //                                    : Math.Round(PrecioPagado, 2)
        //                                : 0;
        [NotMapped]
        public Decimal TotalFaltante { get { OnPropertyChanged(nameof(precioFinal)); return Math.Round(precioFinal * CantidadFaltante, 2); } }

        public void updatePrecioPagado(int sentCantidad)
        {
            PrecioPagado = PrecioPagado == 0 ? precioFinal : (PrecioPagado + (precioFinal * sentCantidad)) / (sentCantidad + 1);
        }

        public Decimal updatePagarProductoDeuda(Decimal tempCobro)
        {
            if (tempCobro >= TotalFaltante)
            {
                tempCobro -= TotalFaltante;
                updatePrecioPagado(CantidadFaltante);
                CantidadFaltante = 0;
            }
            else
            {
                if (tempCobro >= precioFinal)
                {
                    int tempCant = (int)Math.Floor(tempCobro / precioFinal);

                    if (tempCant > 1)
                    {
                        tempCobro -= tempCant * precioFinal;
                        updatePrecioPagado(tempCant);
                        CantidadFaltante -= tempCant;
                    }
                }
            }
            return tempCobro;
        }
        #endregion // NotMapped


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
