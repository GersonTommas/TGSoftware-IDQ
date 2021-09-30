using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class cajaConteoModel : Base.ModelBase
    {
        #region Variables
        public int FechaAperturaID { get; set; }
        fechaModel _FechaApertura;
        public virtual fechaModel FechaApertura { get => _FechaApertura; set { if (SetProperty(ref _FechaApertura, value)) { OnPropertyChanged(); } } }

        public int? FechaCierreID { get; set; }
        fechaModel _FechaCierre;
        public virtual fechaModel FechaCierre { get => _FechaCierre; set { if (SetProperty(ref _FechaCierre, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(conteoAbierto)); } } }

        String _HoraApertura;
        public String HoraApertura { get => _HoraApertura; set { if (SetProperty(ref _HoraApertura, value)) { OnPropertyChanged(); } } }

        String _HoraCierre;
        public String HoraCierre { get => _HoraCierre; set { if (SetProperty(ref _HoraCierre, value)) { OnPropertyChanged(); } } }

        Decimal _EfectivoApertura;
        public Decimal EfectivoApertura { get => _EfectivoApertura; set { if (SetProperty(ref _EfectivoApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difEfectivoApertura)); OnPropertyChanged(nameof(difTotalApertura)); } } }

        Decimal _MercadoPagoApertura;
        public Decimal MercadoPagoApertura { get => _MercadoPagoApertura; set { if (SetProperty(ref _MercadoPagoApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difMercadoPagoApertura)); OnPropertyChanged(nameof(difTotalApertura)); } } }

        Decimal _DiferenciaApertura;
        public Decimal DiferenciaApertura { get => _DiferenciaApertura; set { if (SetProperty(ref _DiferenciaApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difTotalApertura)); } } }

        Decimal _EfectivoCierre;
        public Decimal EfectivoCierre { get => _EfectivoCierre; set { if (SetProperty(ref _EfectivoCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difEfectivoCierre)); OnPropertyChanged(nameof(difTotalCierre)); } } }

        Decimal _MercadoPagoCierre;
        public Decimal MercadoPagoCierre { get => _MercadoPagoCierre; set { if (SetProperty(ref _MercadoPagoCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difMercadoPagoCierre)); OnPropertyChanged(nameof(difTotalCierre)); } } }

        Decimal _DiferenciaCierre;
        public Decimal DiferenciaCierre { get => _DiferenciaCierre; set { if (SetProperty(ref _DiferenciaCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difTotalCierre)); } } }

        string _Detalle;
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        public int CajaID { get; set; }
        cajaModel _Caja;
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }

        public int? CajaCierreID { get; set; }
        cajaModel _CajaCierre;
        public virtual cajaModel CajaCierre { get => _CajaCierre; set { if (SetProperty(ref _CajaCierre, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        usuarioModel _Usuario;
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region NotMapped
        [NotMapped]
        public Decimal? difEfectivoApertura => Caja?.Efectivo - EfectivoApertura;
        [NotMapped]
        public Decimal? difMercadoPagoApertura => Caja?.MercadoPago - MercadoPagoApertura;
        [NotMapped]
        public Decimal? difTotalApertura => difEfectivoApertura + difMercadoPagoApertura + DiferenciaApertura;

        [NotMapped]
        public Decimal difEfectivoCierre => CajaCierre.Efectivo - EfectivoCierre;
        [NotMapped]
        public Decimal difMercadoPagoCierre => CajaCierre.MercadoPago - MercadoPagoCierre;
        [NotMapped]
        public Decimal difTotalCierre => difEfectivoCierre + difMercadoPagoCierre + DiferenciaCierre;

        [NotMapped]
        public bool conteoAbierto => FechaCierre == null;
        #endregion // NotMapped


        public override void updateModel()
        {
            OnPropertyChanged(nameof(difEfectivoApertura));
            OnPropertyChanged(nameof(difMercadoPagoApertura));
            OnPropertyChanged(nameof(difTotalApertura));

            OnPropertyChanged(nameof(difEfectivoCierre));
            OnPropertyChanged(nameof(difMercadoPagoCierre));
            OnPropertyChanged(nameof(difTotalCierre));
            base.updateModel();
        }
    }
}
