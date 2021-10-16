using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IDQ.Domain.Models
{
    public class fechaModel : Base.ModelBase
    {
        #region Variables
        String _Fecha;
        public String Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, Convert.ToDateTime(value).ToString("yyyy/MM/dd"))) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Navigation
        public virtual ICollection<abiertoProductoModel> AbiertoProductosPerFecha { get; private set; } = new ObservableCollection<abiertoProductoModel>();
        public virtual ICollection<cajaModel> CajasPerFecha { get; private set; } = new ObservableCollection<cajaModel>();
        public virtual ICollection<consumoProductoModel> ConsumosProductosPerFecha { get; private set; } = new ObservableCollection<consumoProductoModel>();
        public virtual ICollection<conteoModel> ConteosPerFecha { get; private set; } = new ObservableCollection<conteoModel>(); // New
        public virtual ICollection<deudorPagoModel> DeudorPagosPerFecha { get; private set; } = new ObservableCollection<deudorPagoModel>(); // Deprecated
        public virtual ICollection<ingresoModel> IngresosPerFecha { get; private set; } = new ObservableCollection<ingresoModel>();
        public virtual ICollection<modificadoProductoModel> ModificadosProductosPerFecha { get; private set; } = new ObservableCollection<modificadoProductoModel>();
        public virtual ICollection<productoModel> ProductosModificadosPerFecha { get; private set; } = new ObservableCollection<productoModel>();
        public virtual ICollection<pseudoCajaModel> pseudoCajasPerFecha { get; private set; } = new ObservableCollection<pseudoCajaModel>(); // New
        public virtual ICollection<retiroCajaModel> RetirosPerFecha { get; private set; } = new ObservableCollection<retiroCajaModel>();
        public virtual ICollection<ventaModel> VentasPerFecha { get; private set; } = new ObservableCollection<ventaModel>();
        public virtual ICollection<ventaProductoModel> VentaProductosPagadosPerFecha { get; private set; } = new ObservableCollection<ventaProductoModel>(); // Deprecated

        [InverseProperty(nameof(cajaConteoModel.FechaApertura))]
        public virtual ICollection<cajaConteoModel> CajaConteosAperturaPerFecha { get; private set; } = new ObservableCollection<cajaConteoModel>(); // Deprecated
        [InverseProperty(nameof(cajaConteoModel.FechaCierre))]
        public virtual ICollection<cajaConteoModel> CajaConteosCierrePerFecha { get; private set; } = new ObservableCollection<cajaConteoModel>(); // Deprecated


        [InverseProperty(nameof(deudaModel.FechaSacado))]
        public virtual ICollection<deudaModel> DeudasSacadoPerFecha { get; private set; } = new ObservableCollection<deudaModel>();
        [InverseProperty(nameof(deudaModel.FechaPagado))]
        public virtual ICollection<deudaModel> DeudasPagadoPerFecha { get; private set; } = new ObservableCollection<deudaModel>();

        [InverseProperty(nameof(sacadoProductoModel.FechaSacado))]
        public virtual ICollection<sacadoProductoModel> SacadoProductosSacadosPerFecha { get; private set; } = new ObservableCollection<sacadoProductoModel>(); // Deprecated
        [InverseProperty(nameof(sacadoProductoModel.FechaPagado))]
        public virtual ICollection<sacadoProductoModel> SacadoProductosPagadosPerFecha { get; private set; } = new ObservableCollection<sacadoProductoModel>(); // Deprecated

        [InverseProperty(nameof(usuarioModel.FechaDeIngreso))]
        public virtual ICollection<usuarioModel> UsuariosPerFechaIngreso { get; private set; } = new ObservableCollection<usuarioModel>(); // New
        [InverseProperty(nameof(usuarioModel.FechaDeEgreso))]
        public virtual ICollection<usuarioModel> UsuariosPerFechaEgreso { get; private set; } = new ObservableCollection<usuarioModel>(); // New
        #endregion // Navigation


        #region NotMapped
        [NotMapped]
        public int TotalCantidadVentasDiario => VentasPerFecha.Count;
        [NotMapped]
        //public Decimal TotalPesosVentasDiario => VentasPerFecha.Sum(x => x.PrecioTotal);
        public Decimal TotalPesosVentasDiario => VentasPerFecha.Sum(x => x.Caja is not null ? x.Caja.Efectivo - x.Caja.Vuelto : 0);
        [NotMapped]
        public Decimal TotalMPVentasDiario => VentasPerFecha.Sum(x => x.Caja is not null ? x.Caja.MercadoPago : 0);

        [NotMapped]
        public int TotalCantidadConsumosDiario => ConsumosProductosPerFecha.Count;

        public void updateTotalVentasDiario()
        {
            OnPropertyChanged(nameof(TotalCantidadVentasDiario));
            OnPropertyChanged(nameof(TotalPesosVentasDiario));
            OnPropertyChanged(nameof(TotalMPVentasDiario));
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
