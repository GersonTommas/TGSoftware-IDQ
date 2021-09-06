using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class modificadoProductoModel : Base.ModelBase
    {
        #region Private
        int _Cantidad; productoModel _Producto; fechaModel _Fecha; usuarioModel _Usuario;
        #endregion // Private

        #region Public
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(stockFinal)); } } }

        public int ProductoID { get; set; }
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        [NotMapped]
        public int stockFinal => Producto != null ? Producto.Stock + Cantidad : 0;

        public override void updateModel()
        {
            OnPropertyChanged(nameof(stockFinal));
        }
    }
}
