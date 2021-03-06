using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class modificadoProductoModel : Base.ModelBase
    {
        #region Variables
        int _Cantidad;
        public int Cantidad { get => _Cantidad; set { if (SetProperty(ref _Cantidad, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(stockFinal)); } } }

        productoModel _Producto;
        public virtual productoModel Producto { get => _Producto; set { if (SetProperty(ref _Producto, value)) { OnPropertyChanged(); } } }

        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Variables

        [NotMapped]
        public int stockFinal => Producto is not null ? Producto.Stock + Cantidad : 0;

        public override void updateModel()
        {
            OnPropertyChanged(nameof(stockFinal));
        }
    }
}
