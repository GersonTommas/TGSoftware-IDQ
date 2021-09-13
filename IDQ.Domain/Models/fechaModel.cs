using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class fechaModel : Base.ModelBase
    {
        #region Private
        String _Fecha;
        #endregion // Private

        #region Public
        public String Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, Convert.ToDateTime(value).ToString("yyyy/MM/dd"))) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
        public virtual ICollection<abiertoProductoModel> AbiertoProductosPerFecha { get; private set; } = new ObservableCollection<abiertoProductoModel>();
        public virtual ICollection<cajaModel> CajasPerFecha { get; private set; } = new ObservableCollection<cajaModel>();
        public virtual ICollection<consumoProductoModel> ConsumosProductosPerFecha { get; private set; } = new ObservableCollection<consumoProductoModel>();
        public virtual ICollection<deudorPagoModel> DeudorPagosPerFecha { get; private set; } = new ObservableCollection<deudorPagoModel>();
        public virtual ICollection<ingresoModel> IngresosPerFecha { get; private set; } = new ObservableCollection<ingresoModel>();
        public virtual ICollection<modificadoProductoModel> ModificadosProductosPerFecha { get; private set; } = new ObservableCollection<modificadoProductoModel>();
        public virtual ICollection<productoModel> ProductosModificadosPerFecha { get; private set; } = new ObservableCollection<productoModel>();
        public virtual ICollection<retiroCajaModel> RetirosPerFecha { get; private set; } = new ObservableCollection<retiroCajaModel>();
        public virtual ICollection<ventaModel> VentasPerFecha { get; private set; } = new ObservableCollection<ventaModel>();
        public virtual ICollection<ventaProductoModel> VentaProductosPagadosPerFecha { get; private set; } = new ObservableCollection<ventaProductoModel>();

        [InverseProperty(nameof(cajaConteoModel.FechaApertura))]
        public virtual ICollection<cajaConteoModel> CajaConteosAperturaPerFecha { get; private set; } = new ObservableCollection<cajaConteoModel>();
        [InverseProperty(nameof(cajaConteoModel.FechaCierre))]
        public virtual ICollection<cajaConteoModel> CajaConteosCierrePerFecha { get; private set; } = new ObservableCollection<cajaConteoModel>();

        [InverseProperty(nameof(sacadoProductoModel.FechaSacado))]
        public virtual ICollection<sacadoProductoModel> SacadoProductosSacadosPerFecha { get; private set; } = new ObservableCollection<sacadoProductoModel>();
        [InverseProperty(nameof(sacadoProductoModel.FechaPagado))]
        public virtual ICollection<sacadoProductoModel> SacadoProductosPagadosPerFecha { get; private set; } = new ObservableCollection<sacadoProductoModel>();
        #endregion // Navigation

        #region NotMapped
        [NotMapped]
        public int TotalCantidadVentasDiario => VentasPerFecha.Count;
        [NotMapped]
        public Double TotalPesosVentasDiario => VentasPerFecha.Sum(x => x.PrecioTotal);

        [NotMapped]
        public int TotalCantidadConsumosDiario => ConsumosProductosPerFecha.Count;

        public void updateTotalVentasDiario()
        {
            OnPropertyChanged(nameof(TotalCantidadVentasDiario));
            OnPropertyChanged(nameof(TotalPesosVentasDiario));
        }
        public void updateTotalConsumosDiario()
        {
            OnPropertyChanged(nameof(TotalCantidadConsumosDiario));
        }

        public void updateThis()
        {
            OnPropertyChanged(nameof(fechaModel));
        }
        #endregion // NotMapped

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
