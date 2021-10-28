using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class deudaModel : Base.ModelBase
    {
        #region Variables
        Decimal _TotalPagado;
        public Decimal TotalPagado { get => _TotalPagado; set { if (SetProperty(ref _TotalPagado, value)) { OnPropertyChanged(); } } }

        String _Hora;
        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        public int FechaSacadoId { get; private set; }
        fechaModel _FechaSacado;
        public virtual fechaModel FechaSacado { get => _FechaSacado; set { if (SetProperty(ref _FechaSacado, value)) { OnPropertyChanged(); } } }

        public int? FechaPagadoId { get; private set; }
        fechaModel _FechaPagado;
        public virtual fechaModel FechaPagado { get => _FechaPagado; set { if (SetProperty(ref _FechaPagado, value)) { OnPropertyChanged(); } } }

        deudorModel _Deudor;
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } }

        public int VentaId { get; private set; }
        ventaModel _Venta;
        public virtual ventaModel Venta { get => _Venta; set { if (SetProperty(ref _Venta, value)) { OnPropertyChanged(); } } }
        #endregion // Variables



        #region Navigation
        public virtual ICollection<deudaProductoModel> deudaProductosPerDeuda { get; private set; } = new ObservableCollection<deudaProductoModel>();
        #endregion // Navigation



        #region NotMapped
        public bool checkPagoDeuda(fechaModel sentFecha)
        {
            if (FechaPagado is null && deudaProductosPerDeuda.Count > 0 && deudaProductosPerDeuda.All(x => x.CantidadFaltante == 0)) { FechaPagado = sentFecha; return true; }
            return false;
        }

        [NotMapped]
        public Decimal faltanteTotal => Math.Round(deudaProductosPerDeuda.Sum(x => x.CantidadFaltante * x.precioFinal), 2);
        #endregion // NotMapped



        public Decimal updatePagarDeuda(Decimal sentCobro, fechaModel sentToday)
        {
            if (FechaPagado is null && deudaProductosPerDeuda.Count > 0 && deudaProductosPerDeuda.Any(x => x.PrecioPagado == 0))
            {
                if (sentCobro > faltanteTotal)
                {
                    sentCobro -= faltanteTotal;

                    foreach (deudaProductoModel item in deudaProductosPerDeuda.Where(x => x.CantidadFaltante > 0))
                    {
                        item.updatePrecioPagado(item.CantidadFaltante);
                        item.CantidadFaltante = 0;
                    }

                    FechaPagado = sentToday;
                }
                else
                {
                    foreach (deudaProductoModel item in deudaProductosPerDeuda.Where(x => x.CantidadFaltante > 0)) { if (sentCobro > 0) { sentCobro = item.updatePagarProductoDeuda(sentCobro); } }
                }
            }

            return sentCobro;
        }

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
