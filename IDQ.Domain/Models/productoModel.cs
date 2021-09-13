using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class productoModel : Base.ModelBase
    {
        #region Private
        int _StockInicial, _Stock; Double _PrecioActual, _PrecioIngreso; string _Codigo, _Descripcion; fechaModel _FechaModificado; bool _Activo; tagModel _Tag; medidaModel _Medida;
        bool _Agregado = false;
        #endregion // Private

        #region Public
        public int StockInicial { get => _StockInicial; set { if (SetProperty(ref _StockInicial, value)) { OnPropertyChanged(); } } }
        public int Stock { get => _Stock; set { if (SetProperty(ref _Stock, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(stockVsMinimo)); } } }
        public Double PrecioIngreso { get => _PrecioIngreso; set { if (SetProperty(ref _PrecioIngreso, Math.Round(value, 2))) { OnPropertyChanged(); } } }
        public Double PrecioActual { get => _PrecioActual; set { if (SetProperty(ref _PrecioActual, Math.Round(value, 2))) { OnPropertyChanged(); } } }

        public string Codigo { get => _Codigo; set { if (SetProperty(ref _Codigo, value)) { OnPropertyChanged(); } } }
        public string Descripcion { get => _Descripcion; set { if (SetProperty(ref _Descripcion, value)) { OnPropertyChanged(); } } }

        public bool Activo { get => _Activo; set { if (SetProperty(ref _Activo, value)) { OnPropertyChanged(); } } }

        public int? FechaModificadoID { get; set; }
        public virtual fechaModel FechaModificado { get => _FechaModificado; set { if (SetProperty(ref _FechaModificado, value)) { OnPropertyChanged(); } } }

        public int TagID { get; set; }
        public virtual tagModel Tag { get => _Tag; set { if (SetProperty(ref _Tag, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(stockVsMinimo)); } } }

        public int MedidaID { get; set; }
        public virtual medidaModel Medida { get => _Medida; set { if (SetProperty(ref _Medida, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        #region Navigation
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
        public int stockVsMinimo => Tag != null ? Stock < 1 ? 1 : Stock < Tag.Minimo ? 2 : Stock == Tag.Minimo ? 3 : 4 : 0;
        [NotMapped]
        public bool Agregado { get => _Agregado; set { if (_Agregado != value) { _Agregado = value; OnPropertyChanged(); } } }
        #endregion // NotMapped

        public override void updateModel()
        {
            OnPropertyChanged(nameof(Tag));
            OnPropertyChanged(nameof(Medida));
            base.updateModel();
        }
    }
}