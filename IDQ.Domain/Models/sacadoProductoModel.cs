using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class sacadoProductoModel : Base.ModelBase
    {
        #region Private
        int _Cantidad; Double _Precio; productoModel _Producto; fechaModel _FechaSacado, _FechaPagado; usuarioModel _Usuario;
        #endregion // Private


        #region Public
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); } } }
        public Double Precio { get => _Precio; set { if (SetProperty(ref _Precio, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); } } }

        public int ProductoID { get; set; }
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        public int FechaSacadoID { get; set; }
        public virtual fechaModel FechaSacado { get => _FechaSacado; set { if (SetProperty(ref _FechaSacado, value)) { OnPropertyChanged(); } } }

        public int? FechaPagadoID { get; set; }
        public virtual fechaModel FechaPagado { get => _FechaPagado; set { if (SetProperty(ref _FechaPagado, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(BolPagado)); } } }
        #endregion // Public


        #region NotMapped
        [NotMapped]
        public Double PrecioTotal => Math.Round(Cantidad * Precio, 2);
        [NotMapped]
        public bool BolPagado => FechaPagado != null;
        #endregion // NotMapped

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
