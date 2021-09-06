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
        cajaModel _Caja; String _Hora; fechaModel _Fecha; usuarioModel _Usuario; deudorModel _Deudor;
        #endregion // Private

        #region Public
        public int CajaId { get; set; }
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }

        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, Convert.ToDateTime(value).ToString("HH:mm:ss"))) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        public int? DeudorID { get; set; }
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
        public virtual ICollection<ventaProductoModel> VentaProductosPerVenta { get; private set; } = new ObservableCollection<ventaProductoModel>();
        #endregion // Navigation

        #region NotMapped
        [NotMapped]
        public Double PrecioTotal => Math.Round(VentaProductosPerVenta.Sum(x => x.PrecioTotal), 2);
        [NotMapped]
        public int isVentaDeuda => VentaProductosPerVenta.All(x => x.isProductoDeuda == 0) ? 0 : VentaProductosPerVenta.All(x => x.isProductoDeuda == 2) ? 2 : 1;
        [NotMapped]
        public int isVentaPagado => VentaProductosPerVenta.All(x => x.BolPagado) ? 0 : VentaProductosPerVenta.All(x => x.BolPagado == false) ? 2 : 1;
        [NotMapped]
        public Double DeudaTotalVenta => Math.Round(VentaProductosPerVenta.Sum(x => x.TotalFaltante), 2);
        #endregion // NotMapped

        public override void updateModel()
        {
            OnPropertyChanged(nameof(PrecioTotal));
        }
    }
}
