using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class conteoModel : Base.ModelBase
    {
        #region Properties
        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }

        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        public int? CajaEntradaId { get; set; }
        pseudoCajaModel _CajaEntrada;
        public virtual pseudoCajaModel CajaEntrada { get => _CajaEntrada; set { if (SetProperty(ref _CajaEntrada, value)) { OnPropertyChanged(); } } }

        public int? CajaSalidaId { get; set; }
        pseudoCajaModel _CajaSalida;
        public virtual pseudoCajaModel CajaSalida { get => _CajaSalida; set { if (SetProperty(ref _CajaSalida, value)) { OnPropertyChanged(); } } }
        #endregion // Properties


        #region NotMapped
        [NotMapped]
        public bool conteoAbierto => CajaSalida is null;
        #endregion // NotMapped
    }
}
