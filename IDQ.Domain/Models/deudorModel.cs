using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class deudorModel : Base.ModelBase
    {
        #region Private
        int _Nivel; Decimal _Resto; string _Nombre, _Detalles; usuarioModel _Usuario;
        #endregion // Private

        #region Public
        public int Nivel { get => _Nivel; set { if (SetProperty(ref _Nivel, value)) { OnPropertyChanged(); } } }
        public Decimal Resto { get => _Resto; set { if (SetProperty(ref _Resto, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(doubleFaltanteTotal)); } } }

        public string Nombre { get => _Nombre; set { if (SetProperty(ref _Nombre, value)) { OnPropertyChanged(); } } }

        public string Detalles { get => _Detalles; set { if (SetProperty(ref _Detalles, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
        public virtual ICollection<cajaModel> cajasPerDeudor { get; private set; } = new ObservableCollection<cajaModel>();
        public virtual ICollection<deudaModel> deudasPerDeudor { get; private set; } = new ObservableCollection<deudaModel>();
        public virtual ICollection<ventaModel> VentasPerDeudor { get; private set; } = new ObservableCollection<ventaModel>();
        
        public virtual ICollection<ventaProductoModel> VentaProductosPerDeudor { get; private set; } = new ObservableCollection<ventaProductoModel>(); // Deprecated
        public virtual ICollection<deudorPagoModel> DeudorPagosPerDeudor { get; private set; } = new ObservableCollection<deudorPagoModel>(); // Deprecated
        #endregion // Navigation

        #region NotMapped
        [NotMapped]
        public Decimal doubleDeudaTotal => Math.Round(VentasPerDeudor.Sum(x => x.DeudaTotalVenta), 2);
        [NotMapped]
        public Decimal doubleFaltanteTotal => Math.Round(doubleDeudaTotal - Resto, 2);

        public override void updateModel()
        {
            OnPropertyChanged(nameof(doubleDeudaTotal));
            OnPropertyChanged(nameof(doubleFaltanteTotal));
        }
        #endregion // NotMapped
    }
}
