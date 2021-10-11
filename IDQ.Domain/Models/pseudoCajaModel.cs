using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.Domain.Models
{
    public class pseudoCajaModel : Base.ModelBase
    {
        #region Properties
        Decimal _Efectivo;
        public Decimal Efectivo { get => _Efectivo; set { if (SetProperty(ref _Efectivo, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(difEfectivo)); OnPropertyChanged(nameof(difTotal)); } } }

        Decimal _MercadoPago;
        public Decimal MercadoPago { get => _MercadoPago; set { if (SetProperty(ref _MercadoPago, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(difMercadoPago)); OnPropertyChanged(nameof(difTotal)); } } }

        Decimal _CajaEfectivo;
        public Decimal CajaEfectivo { get => _CajaEfectivo; set { if (SetProperty(ref _CajaEfectivo, value)) { OnPropertyChanged(); } } }

        Decimal _CajaMercadoPago;
        public Decimal CajaMercadoPago { get => _CajaMercadoPago; set { if (SetProperty(ref _CajaMercadoPago, value)) { OnPropertyChanged(); } } }

        Decimal _AgregadoEfectivo;
        public Decimal AgregadoEfectivo { get => _AgregadoEfectivo; set { if (SetProperty(ref _AgregadoEfectivo, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(difEfectivo)); OnPropertyChanged(nameof(difTotal)); } } }

        Decimal _AgregadoMercadoPago;
        public Decimal AgregadoMercadoPago { get => _AgregadoMercadoPago; set { if (SetProperty(ref _AgregadoMercadoPago, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(difMercadoPago)); OnPropertyChanged(nameof(difTotal)); } } }

        string _Detalles;
        public string Detalles { get => _Detalles; set { if (SetProperty(ref _Detalles, value)) { OnPropertyChanged(); } } }

        fechaModel _Fecha;
        public virtual fechaModel Fecha { get => _Fecha; set { if (SetProperty(ref _Fecha, value)) { OnPropertyChanged(); } } }

        String _Hora;
        public String Hora { get => _Hora; set { if (SetProperty(ref _Hora, value)) { OnPropertyChanged(); } } }
        #endregion // Properties


        #region Navigation Properties
        [InverseProperty(nameof(conteoModel.CajaEntrada))]
        public virtual conteoModel ConteoEntrada { get; set; }

        [InverseProperty(nameof(conteoModel.CajaSalida))]
        public virtual conteoModel ConteoSalida { get; set; }
        #endregion // Navigation Properties


        #region NotMapped
        [NotMapped]
        public Decimal difEfectivo => CajaEfectivo - Efectivo;
        [NotMapped]
        public Decimal difMercadoPago => CajaMercadoPago - MercadoPago;
        [NotMapped]
        public Decimal difTotal => difEfectivo + difMercadoPago + AgregadoEfectivo + AgregadoMercadoPago;
        #endregion // NotMapped
    }
}
