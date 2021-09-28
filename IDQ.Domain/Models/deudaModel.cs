using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class deudaModel : Base.ModelBase
    {
        #region Private
        Decimal _TotalPagado; fechaModel _FechaSacado, _FechaPagado; deudorModel _Deudor; String _Hora; ventaModel _Venta;
        #endregion // Private

        #region Public
        public Decimal TotalPagado { get => _TotalPagado; set { if (SetProperty(ref _TotalPagado, value)) { OnPropertyChanged(); } } }
        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        public int FechaSacadoID { get; set; }
        public virtual fechaModel FechaSacado { get => _FechaSacado; set { if (SetProperty(ref _FechaSacado, value)) { OnPropertyChanged(); } } }

        public int? FechaPagadoID { get; set; }
        public virtual fechaModel FechaPagado { get => _FechaPagado; set { if (SetProperty(ref _FechaPagado, value)) { OnPropertyChanged(); } } }

        public int DeudorID { get; set; }
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } }

        public int VentaID { get; set; }
        public virtual ventaModel Venta { get => _Venta; set { if (SetProperty(ref _Venta, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
        public virtual ICollection<deudaProductoModel> deudaProductosPerDeuda { get; private set; } = new ObservableCollection<deudaProductoModel>();
        #endregion // Navigation

        #region NotMapped
        public bool checkPagoDeuda(fechaModel sentFecha)
        {
                if (FechaPagado == null && deudaProductosPerDeuda.Count > 0 && deudaProductosPerDeuda.All(x => x.CantidadFaltante == 0)) { FechaPagado = sentFecha; return true; }
                return false;
        }
        #endregion // NotMapped
    }
}
