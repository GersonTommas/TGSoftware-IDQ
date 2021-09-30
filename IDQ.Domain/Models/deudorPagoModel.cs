using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IDQ.Domain.Models
{
    public class deudorPagoModel : Base.ModelBase
    {
        #region Variables
        public int FechaID { get; set; }
        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int DeudorID { get; set; }
        deudorModel _Deudor;
        public virtual deudorModel Deudor { get => _Deudor; set { if (SetProperty(ref _Deudor, value)) { OnPropertyChanged(); } } }

        public int CajaID { get; set; }
        cajaModel _Caja;
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Navigation
        public virtual ICollection<ventaModel> VentaPerDeudorPago { get; private set; } = new ObservableCollection<ventaModel>();
        public virtual ICollection<ventaProductoModel> VentaProductosPerDeudorPago { get; private set; } = new ObservableCollection<ventaProductoModel>();
        #endregion // Navigation


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
