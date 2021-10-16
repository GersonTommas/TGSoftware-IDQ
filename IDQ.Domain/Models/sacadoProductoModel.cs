using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class sacadoProductoModel : Base.ModelBase
    {
        #region Variables
        int _Cantidad;
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); } } }

        Decimal _Precio;
        public Decimal Precio { get => _Precio; set { if (SetProperty(ref _Precio, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(PrecioTotal)); } } }

        public int ProductoID { get; set; }
        productoModel _Producto;
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        public int FechaSacadoID { get; set; }
        fechaModel _FechaSacado;
        public virtual fechaModel FechaSacado { get => _FechaSacado; set { if (SetProperty(ref _FechaSacado, value)) { OnPropertyChanged(); } } }

        public int? FechaPagadoID { get; set; }
        fechaModel _FechaPagado;
        public virtual fechaModel FechaPagado { get => _FechaPagado; set { if (SetProperty(ref _FechaPagado, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(BolPagado)); } } }
        #endregion // Variables


        #region NotMapped
        [NotMapped]
        public Decimal PrecioTotal => Math.Round(Cantidad * Precio, 2);
        [NotMapped]
        public bool BolPagado => FechaPagado is not null;
        #endregion // NotMapped


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
