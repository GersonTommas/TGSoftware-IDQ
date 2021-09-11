using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IDQ.Domain.Models
{
    public class deudorPagoModel : Base.ModelBase
    {
        cajaModel _Caja; deudorModel _Deudor; fechaModel _Fecha;

        public int FechaID { get; set; }
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int DeudorID { get; set; }
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } }

        public int CajaID { get; set; }
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }


        public virtual ICollection<ventaModel> VentaPerDeudorPago { get; private set; } = new ObservableCollection<ventaModel>();
        public virtual ICollection<ventaProductoModel> VentaProductosPerDeudorPago { get; private set; } = new ObservableCollection<ventaProductoModel>();
    }
}
