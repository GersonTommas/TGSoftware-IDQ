using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class cajaModel : Base.ModelBase
    {
        #region Variables
        Decimal _Efectivo;
        public Decimal Efectivo { get => _Efectivo; set { if (SetProperty(ref _Efectivo, Math.Round(value, 2))) { OnPropertyChanged(); privUpdateVenta(); } } }

        Decimal _MercadoPago;
        public Decimal MercadoPago { get => _MercadoPago; set { if (SetProperty(ref _MercadoPago, Math.Round(value, 2))) { OnPropertyChanged(); privUpdateVenta(); } } }

        Decimal _Vuelto;
        public Decimal Vuelto { get => _Vuelto; set { if (SetProperty(ref _Vuelto, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        String _Hora;
        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        ventaModel _VentaForCaja;
        public virtual ventaModel VentaForCaja { get => _VentaForCaja; set { if (SetProperty(ref _VentaForCaja, value)) { OnPropertyChanged(); } } }

        deudorModel _DeudorForCaja;
        public virtual deudorModel DeudorForCaja { get => _DeudorForCaja; set { if (SetProperty(ref _DeudorForCaja, value)) { OnPropertyChanged(); } } }

        cajaConteoModel _CajaConteoForCaja;
        [InverseProperty(nameof(cajaConteoModel.Caja))]
        public virtual cajaConteoModel CajaConteoForCaja { get => _CajaConteoForCaja; set { if (SetProperty(ref _CajaConteoForCaja, value)) { OnPropertyChanged(); } } }
        cajaConteoModel _CajaConteoCierreForCaja;
        [InverseProperty(nameof(cajaConteoModel.CajaCierre))]
        public virtual cajaConteoModel CajaConteoCierreForCaja { get => _CajaConteoCierreForCaja; set { if (SetProperty(ref _CajaConteoCierreForCaja, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Navigation
        public virtual ICollection<ventaProductoModel> VentaProductosPerCaja { get; private set; } = new ObservableCollection<ventaProductoModel>();
        public virtual ICollection<retiroCajaModel> RetirosCajaPerCaja { get; private set; } = new ObservableCollection<retiroCajaModel>();
        public virtual ICollection<deudorPagoModel> DeudorPagosPerCaja { get; private set; } = new ObservableCollection<deudorPagoModel>();
        #endregion // Navigation


        #region Helpers
        void privUpdateVenta()
        {
            if (VentaForCaja is not null)
            {
                OnPropertyChanged(nameof(doubleEfectivoTotal));
                OnPropertyChanged(nameof(doubleTotalTotal));
            }
        }
        #endregion // Helpers


        #region NotMapped
        [NotMapped]
        public Decimal doubleEfectivoTotal => Efectivo - Vuelto;
        [NotMapped]
        public Decimal doubleTotalTotal => Efectivo + MercadoPago - Vuelto;
        #endregion // NotMapped


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}