using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class ventaModel : Base.ModelBase
    {
        #region Private
        String _Hora; Decimal _PrecioTotal; cajaModel _Caja; fechaModel _Fecha; usuarioModel _Usuario; deudorModel _Deudor; deudaModel _DeudaForVenta;
        #endregion // Private

        #region Public
        public Decimal PrecioTotal { get => _PrecioTotal; set { if (SetProperty(ref _PrecioTotal, value)) { OnPropertyChanged(); } } }

        public int? CajaId { get; set; }
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }

        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        public int? DeudorID { get; set; }
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } }


        public virtual deudaModel DeudaForVenta { get => _DeudaForVenta; set { if (SetProperty(ref _DeudaForVenta, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
        public virtual ICollection<ventaProductoModel> VentaProductosPerVenta { get; private set; } = new ObservableCollection<ventaProductoModel>();


        public virtual ICollection<deudorPagoModel> DeudaorPagosPerVenta { get; private set; } = new ObservableCollection<deudorPagoModel>(); // Deprecated
        #endregion // Navigation

        #region NotMapped
        [NotMapped]
        public int isVentaDeuda => VentaProductosPerVenta.All(x => x.isProductoDeuda == 0) ? 0 : VentaProductosPerVenta.All(x => x.isProductoDeuda == 2) ? 2 : 1;
        [NotMapped]
        public int isVentaPagado => VentaProductosPerVenta.All(x => x.BolPagado) ? 0 : VentaProductosPerVenta.All(x => x.BolPagado == false) ? 2 : 1;
        [NotMapped]
        public Decimal DeudaTotalVenta => Math.Round(VentaProductosPerVenta.Sum(x => x.TotalFaltante), 2);
        #endregion // NotMapped
    }
}
