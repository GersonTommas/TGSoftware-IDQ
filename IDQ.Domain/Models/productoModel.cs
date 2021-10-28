using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class productoModel : Base.ModelBase
    {
        #region Variables
        int _StockInicial;
        public int StockInicial { get => _StockInicial; set { if (SetProperty(ref _StockInicial, value)) { OnPropertyChanged(); } } }

        int _Stock;
        public int Stock { get => _Stock; set { if (SetProperty(ref _Stock, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(stockVsMinimo)); } } }

        Decimal _PrecioIngreso;
        public Decimal PrecioIngreso { get => _PrecioIngreso; set { if (SetProperty(ref _PrecioIngreso, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        Decimal _PrecioActual;
        public Decimal PrecioActual { get => _PrecioActual; set { if (SetProperty(ref _PrecioActual, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        string _Codigo;
        public string Codigo { get => _Codigo; set { if (SetProperty(ref _Codigo, value)) { OnPropertyChanged(); } } }

        string _Descripcion;
        public string Descripcion { get => _Descripcion; set { if (SetProperty(ref _Descripcion, value)) { OnPropertyChanged(); } } }

        bool _Activo;
        public bool Activo { get => _Activo; set { if (SetProperty(ref _Activo, value)) { OnPropertyChanged(); } } }

        fechaModel _FechaModificado;
        public virtual fechaModel FechaModificado { get => _FechaModificado; set { if (SetProperty(ref _FechaModificado, value)) { OnPropertyChanged(); } } }

        tagModel _Tag;
        public virtual tagModel Tag { get => _Tag; set { if (SetProperty(ref _Tag, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(stockVsMinimo)); } } }

        medidaModel _Medida;
        public virtual medidaModel Medida { get => _Medida; set { if (SetProperty(ref _Medida, value)) { OnPropertyChanged(); } } }
        #endregion // Variables

        #region Navigation
        public virtual ICollection<deudaProductoModel> DeudaProductoPerProducto { get; private set; } = new ObservableCollection<deudaProductoModel>();
        public virtual ICollection<sacadoProductoModel> SacadoProductosPerProducto { get; private set; } = new ObservableCollection<sacadoProductoModel>();
        public virtual ICollection<ingresoProductoModel> IngresoProductosPerProducto { get; private set; } = new ObservableCollection<ingresoProductoModel>();
        public virtual ICollection<ventaProductoModel> VentaProductosPerProducto { get; private set; } = new ObservableCollection<ventaProductoModel>();
        public virtual ICollection<consumoProductoModel> ConsumoProductosPerProducto { get; private set; } = new ObservableCollection<consumoProductoModel>();
        public virtual ICollection<modificadoProductoModel> ModificadoProductosPerProducto { get; private set; } = new ObservableCollection<modificadoProductoModel>();

        [InverseProperty(nameof(abiertoProductoModel.ProductoSacado))]
        public virtual ICollection<abiertoProductoModel> AbiertoSacadoPerProducto { get; private set; } = new ObservableCollection<abiertoProductoModel>();
        [InverseProperty(nameof(abiertoProductoModel.ProductoAgregado))]
        public virtual ICollection<abiertoProductoModel> AbiertoAgregadoPerProducto { get; private set; } = new ObservableCollection<abiertoProductoModel>();
        #endregion // Navigation

        #region NotMapped
        [NotMapped]
        public int stockVsMinimo => Tag is not null ? Stock < 1 ? 1 : Stock < Tag.Minimo ? 2 : Stock == Tag.Minimo ? 3 : 4 : 0;
        bool _Agregado;
        [NotMapped]
        public bool Agregado { get => _Agregado; set { if (_Agregado != value) { _Agregado = value; OnPropertyChanged(); } } }
        int _CantidadIngresado;
        [NotMapped]
        public int CantidadIngresado { get => _CantidadIngresado; set { if (SetProperty(ref _CantidadIngresado, value)) { OnPropertyChanged(); } } }
        #endregion // NotMapped

        public override void updateModel()
        {
            OnPropertyChanged(nameof(Tag));
            OnPropertyChanged(nameof(Medida));
            base.updateModel();
        }
    }
}