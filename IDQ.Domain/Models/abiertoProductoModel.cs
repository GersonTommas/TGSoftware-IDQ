namespace IDQ.Domain.Models
{
    public class abiertoProductoModel : Base.ModelBase
    {
        #region Private
        int _CantidadSacado, _CantidadAgregado; productoModel _ProductoSacado, _ProductoAgregado; fechaModel _Fecha; usuarioModel _Usuario;
        #endregion // Private

        #region Public
        public int CantidadSacado { get => _CantidadSacado; set { if (SetProperty(ref _CantidadSacado, value)) { OnPropertyChanged(); } } }
        public int CantidadAgregado { get => _CantidadAgregado; set { if (SetProperty(ref _CantidadAgregado, value)) { OnPropertyChanged(); } } }

        public int ProductoSacadoID { get; set; }
        public virtual productoModel ProductoSacado { get => _ProductoSacado; set { if (SetProperty(ref _ProductoSacado, value)) { OnPropertyChanged(); } } }

        public int ProductoAgregadoID { get; set; }
        public virtual productoModel ProductoAgregado { get => _ProductoAgregado; set { if (SetProperty(ref _ProductoAgregado, value)) { OnPropertyChanged(); } } }

        public int FechaID { get; set; }
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        public override void updateModel()
        {
            base.updateModel();
        }
    }
}
