using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class deudorModel : Base.ModelBase
    {
        #region Variables
        int _Nivel;
        public int Nivel { get => _Nivel; set { if (SetProperty(ref _Nivel, value)) { OnPropertyChanged(); } } }

        Decimal _Resto;
        public Decimal Resto { get => _Resto; set { if (SetProperty(ref _Resto, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(doubleFaltanteTotal)); } } }

        string _Nombre;
        public string Nombre { get => _Nombre; set { if (SetProperty(ref _Nombre, value)) { OnPropertyChanged(); } } }

        string _Detalles;
        public string Detalles { get => _Detalles; set { if (SetProperty(ref _Detalles, value)) { OnPropertyChanged(); } } }

        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Navigation
        public virtual ICollection<cajaModel> cajasPerDeudor { get; private set; } = new ObservableCollection<cajaModel>();
        public virtual ICollection<deudaModel> deudasPerDeudor { get; private set; } = new ObservableCollection<deudaModel>();
        public virtual ICollection<deudaProductoModel> deudaProductosPerDeudor { get; private set; } = new ObservableCollection<deudaProductoModel>();
        public virtual ICollection<ventaModel> VentasPerDeudor { get; private set; } = new ObservableCollection<ventaModel>();
        
        public virtual ICollection<ventaProductoModel> VentaProductosPerDeudor { get; private set; } = new ObservableCollection<ventaProductoModel>(); // Deprecated
        public virtual ICollection<deudorPagoModel> DeudorPagosPerDeudor { get; private set; } = new ObservableCollection<deudorPagoModel>(); // Deprecated
        #endregion // Navigation


        #region NotMapped
        [NotMapped]
        public Decimal doubleDeudaTotal => Math.Round(deudasPerDeudor.Where(x => x.FechaPagado is null).Sum(x => x.faltanteTotal), 2); //Math.Round(VentasPerDeudor.Sum(x => x.DeudaTotalVenta), 2);
        [NotMapped]
        public Decimal doubleFaltanteTotal => Math.Round(doubleDeudaTotal - Resto, 2);
        #endregion // NotMapped

        public Decimal updatePagarAllDeudas(Decimal sentCobro, fechaModel sentToday)
        {
            foreach (deudaModel item in deudasPerDeudor.Where(x => x.FechaPagado is null))
            {
                sentCobro = item.updatePagarDeuda(sentCobro, sentToday);
            }

            if (deudasPerDeudor.Any(x => x.FechaPagado is null))
            {
                Resto = sentCobro;
                sentCobro = 0;
            }

            return sentCobro;
        }


        public override void updateModel()
        {
            OnPropertyChanged(nameof(doubleDeudaTotal));
            OnPropertyChanged(nameof(doubleFaltanteTotal));
        }
    }
}
