using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class ventaModel : Base.ModelBase
    {
        #region Variables
        Decimal _PrecioTotal;
        public Decimal PrecioTotal { get => _PrecioTotal; set { if (SetProperty(ref _PrecioTotal, value)) { OnPropertyChanged(); } } }

        public int? CajaId { get; private set; }
        cajaModel _Caja;
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }

        String _Hora;
        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        deudorModel _Deudor; // Deprecated
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } } // Deprecated

        deudaModel _DeudaForVenta;
        public virtual deudaModel DeudaForVenta { get => _DeudaForVenta; set { if (SetProperty(ref _DeudaForVenta, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Navigation
        public virtual ICollection<ventaProductoModel> VentaProductosPerVenta { get; private set; } = new ObservableCollection<ventaProductoModel>();


        public virtual ICollection<deudorPagoModel> DeudaorPagosPerVenta { get; private set; } = new ObservableCollection<deudorPagoModel>(); // Deprecated
        #endregion // Navigation


        #region NotMapped
        [NotMapped]
        public int isVentaDeuda => DeudaForVenta is not null ? 1 : 0; //VentaProductosPerVenta.All(x => x.isProductoDeuda == 0) ? 0 : VentaProductosPerVenta.All(x => x.isProductoDeuda == 2) ? 2 : 1;
        [NotMapped]
        public int isVentaPagado => DeudaForVenta is not null ? DeudaForVenta.FechaPagado is not null ? 0 : 1 : 1;//VentaProductosPerVenta.All(x => x.BolPagado) ? 0 : VentaProductosPerVenta.All(x => x.BolPagado == false) ? 2 : 1;
        //[NotMapped] // Deprecated
        //public Decimal DeudaTotalVenta => VentaProductosPerVenta.Sum(x => x.TotalFaltante); // Deprecated
        #endregion // NotMapped
    }
}
