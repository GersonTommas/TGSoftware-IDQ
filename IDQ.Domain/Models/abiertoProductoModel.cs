namespace IDQ.Domain.Models
{
    public class abiertoProductoModel : Base.ModelBase
    {
        #region Variables
        int _CantidadSacado;
        public int CantidadSacado { get => _CantidadSacado; set { if (SetProperty(ref _CantidadSacado, value)) { OnPropertyChanged(); } } }

        int _CantidadAgregado;
        public int CantidadAgregado { get => _CantidadAgregado; set { if (SetProperty(ref _CantidadAgregado, value)) { OnPropertyChanged(); } } }

        public int ProductoSacadoId { get; private set; }
        productoModel _ProductoSacado;
        public virtual productoModel ProductoSacado { get => _ProductoSacado; set { if (SetProperty(ref _ProductoSacado, value)) { OnPropertyChanged(); } } }

        public int ProductoAgregadoId { get; private set; }
        productoModel _ProductoAgregado;
        public virtual productoModel ProductoAgregado { get => _ProductoAgregado; set { if (SetProperty(ref _ProductoAgregado, value)) { OnPropertyChanged(); } } }

        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
