using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class cajaConteoModel : Base.ModelBase // Deprecated
    {
        #region Variables
        public int FechaAperturaID { get; set; } // Deprecated
        fechaModel _FechaApertura; // Deprecated
        public virtual fechaModel FechaApertura { get => _FechaApertura; set { if (SetProperty(ref _FechaApertura, value)) { OnPropertyChanged(); } } } // Deprecated

        public int? FechaCierreID { get; set; } // Deprecated
        fechaModel _FechaCierre; // Deprecated
        public virtual fechaModel FechaCierre { get => _FechaCierre; set { if (SetProperty(ref _FechaCierre, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(conteoAbierto)); } } } // Deprecated

        String _HoraApertura; // Deprecated
        public String HoraApertura { get => _HoraApertura; set { if (SetProperty(ref _HoraApertura, value)) { OnPropertyChanged(); } } } // Deprecated

        String _HoraCierre; // Deprecated
        public String HoraCierre { get => _HoraCierre; set { if (SetProperty(ref _HoraCierre, value)) { OnPropertyChanged(); } } } // Deprecated

        Decimal _EfectivoApertura; // Deprecated
        public Decimal EfectivoApertura { get => _EfectivoApertura; set { if (SetProperty(ref _EfectivoApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difEfectivoApertura)); OnPropertyChanged(nameof(difTotalApertura)); } } } // Deprecated

        Decimal _MercadoPagoApertura; // Deprecated
        public Decimal MercadoPagoApertura { get => _MercadoPagoApertura; set { if (SetProperty(ref _MercadoPagoApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difMercadoPagoApertura)); OnPropertyChanged(nameof(difTotalApertura)); } } } // Deprecated

        Decimal _DiferenciaApertura; // Deprecated
        public Decimal DiferenciaApertura { get => _DiferenciaApertura; set { if (SetProperty(ref _DiferenciaApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difTotalApertura)); } } } // Deprecated

        Decimal _EfectivoCierre; // Deprecated
        public Decimal EfectivoCierre { get => _EfectivoCierre; set { if (SetProperty(ref _EfectivoCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difEfectivoCierre)); OnPropertyChanged(nameof(difTotalCierre)); } } } // Deprecated

        Decimal _MercadoPagoCierre; // Deprecated
        public Decimal MercadoPagoCierre { get => _MercadoPagoCierre; set { if (SetProperty(ref _MercadoPagoCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difMercadoPagoCierre)); OnPropertyChanged(nameof(difTotalCierre)); } } } // Deprecated

        Decimal _DiferenciaCierre; // Deprecated
        public Decimal DiferenciaCierre { get => _DiferenciaCierre; set { if (SetProperty(ref _DiferenciaCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difTotalCierre)); } } } // Deprecated

        string _Detalle; // Deprecated
        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } } // Deprecated

        public int CajaID { get; set; } // Deprecated
        cajaModel _Caja; // Deprecated
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } } // Deprecated

        public int? CajaCierreID { get; set; } // Deprecated
        cajaModel _CajaCierre; // Deprecated
        public virtual cajaModel CajaCierre { get => _CajaCierre; set { if (SetProperty(ref _CajaCierre, value)) { OnPropertyChanged(); } } } // Deprecated

        public int UsuarioID { get; set; } // Deprecated
        usuarioModel _Usuario; // Deprecated
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } } // Deprecated

        //public bool Salida { get; set; } // remove when finished
        #endregion // Variables


        #region NotMapped
        [NotMapped]
        public Decimal? difEfectivoApertura => Caja?.Efectivo - EfectivoApertura; // Deprecated
        [NotMapped]
        public Decimal? difMercadoPagoApertura => Caja?.MercadoPago - MercadoPagoApertura; // Deprecated
        [NotMapped]
        public Decimal? difTotalApertura => difEfectivoApertura + difMercadoPagoApertura + DiferenciaApertura; // Deprecated

        [NotMapped]
        public Decimal difEfectivoCierre => CajaCierre.Efectivo - EfectivoCierre; // Deprecated
        [NotMapped]
        public Decimal difMercadoPagoCierre => CajaCierre.MercadoPago - MercadoPagoCierre; // Deprecated
        [NotMapped]
        public Decimal difTotalCierre => difEfectivoCierre + difMercadoPagoCierre + DiferenciaCierre; // Deprecated

        [NotMapped]
        public bool conteoAbierto => FechaCierre is null; // Deprecated
        #endregion // NotMapped


        public override void updateModel() // Deprecated
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
