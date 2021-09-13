using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class cajaModel : Base.ModelBase
    {
        #region Private
        Double _CajaActual, _MercadoPago, _Vuelto; String _Hora; fechaModel _Fecha; cajaConteoModel _CajaConteoForCaja, _CajaConteoCierreForCaja; ventaModel _VentaForCaja;
        #endregion // Private

        #region Public
        public Double CajaActual { get => _CajaActual; set { if (SetProperty(ref _CajaActual, Math.Round(value, 2))) { OnPropertyChanged(); privUpdateVenta(); } } }
        public Double MercadoPago { get => _MercadoPago; set { if (SetProperty(ref _MercadoPago, Math.Round(value, 2))) { OnPropertyChanged(); privUpdateVenta(); } } }
        public Double Vuelto { get => _Vuelto; set { if (SetProperty(ref _Vuelto, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public virtual ventaModel VentaForCaja { get => _VentaForCaja; set { if (SetProperty(ref _VentaForCaja, value)) { OnPropertyChanged(); } } }


        [InverseProperty(nameof(cajaConteoModel.Caja))]
        public virtual cajaConteoModel CajaConteoForCaja { get => _CajaConteoForCaja; set { if (SetProperty(ref _CajaConteoForCaja, value)) { OnPropertyChanged(); } } }
        [InverseProperty(nameof(cajaConteoModel.CajaCierre))]
        public virtual cajaConteoModel CajaConteoCierreForCaja { get => _CajaConteoCierreForCaja; set { if (SetProperty(ref _CajaConteoCierreForCaja, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
        public virtual ICollection<ventaProductoModel> VentaProductosPerCaja { get; private set; } = new ObservableCollection<ventaProductoModel>();
        public virtual ICollection<retiroCajaModel> RetirosCajaPerCaja { get; private set; } = new ObservableCollection<retiroCajaModel>();
        public virtual ICollection<deudorPagoModel> DeudorPagosPerCaja { get; private set; } = new ObservableCollection<deudorPagoModel>();
        #endregion // Navigation

        #region Helpers
        void privUpdateVenta()
        {
            if (VentaForCaja != null)
            {
                /*
                OnPropertyChanged(nameof(VentaForCaja.TotalPagado));
                OnPropertyChanged(nameof(VentaForCaja.Vuelto));
                */
                OnPropertyChanged(nameof(doubleEfectivoTotal));
            }
        }
        #endregion // Helpers

        #region NotMapped
        [NotMapped]
        public Double doubleEfectivoTotal => CajaActual - Vuelto;
        [NotMapped]
        public Double doubleTotalTotal => CajaActual + MercadoPago - Vuelto;
        #endregion // NotMapped

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}