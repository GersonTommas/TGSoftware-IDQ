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
        int _Nivel; Double _Resto, _DeudaTotal; string _Nombre, _Detalles; usuarioModel _Usuario;
        #endregion // Private

        #region Public
        public int Nivel { get => _Nivel; set { if (SetProperty(ref _Nivel, value)) { OnPropertyChanged(); } } }
        public Double Resto { get => _Resto; set { if (SetProperty(ref _Resto, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(doubleFaltanteTotal)); } } }

        public string Nombre { get => _Nombre; set { if (SetProperty(ref _Nombre, value)) { OnPropertyChanged(); } } }

        public string Detalles { get => _Detalles; set { if (SetProperty(ref _Detalles, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
        public virtual ICollection<ventaModel> VentasPerDeudor { get; private set; } = new ObservableCollection<ventaModel>();
        public virtual ICollection<ventaProductoModel> VentaProductosPerDeudor { get; private set; } = new ObservableCollection<ventaProductoModel>();
        public virtual ICollection<deudorPagoModel> DeudorPagosPerDeudor { get; private set; } = new ObservableCollection<deudorPagoModel>();
        #endregion // Navigation

        #region NotMapped
        [NotMapped]
        public Double doubleDeudaTotal => Math.Round(VentasPerDeudor.Sum(x => x.DeudaTotalVenta), 2);
        [NotMapped]
        public Double doubleFaltanteTotal => Math.Round(doubleDeudaTotal - Resto, 2);

        public override void updateModel()
        {
            OnPropertyChanged(nameof(doubleDeudaTotal));
            OnPropertyChanged(nameof(doubleFaltanteTotal));
        }
        #endregion // NotMapped
    }
}
