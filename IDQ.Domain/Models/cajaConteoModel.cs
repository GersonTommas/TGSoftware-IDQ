using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDQ.Domain.Models
{
    public class cajaConteoModel : Base.ModelBase
    {
        #region Private
        Double _DiferenciaApertura, _EfectivoApertura, _MercadoPagoApertura, _DiferenciaCierre, _EfectivoCierre, _MercadoPagoCierre; string _Detalle; bool _Salida; cajaModel _Caja, _CajaCierre; usuarioModel _Usuario; fechaModel _FechaApertura, _FechaCierre; String _HoraApertura;
        String _HoraCierre;
        #endregion // Private

        #region Public
        public int FechaAperturaID { get; set; }
        public virtual fechaModel FechaApertura { get => _FechaApertura; set { if (SetProperty(ref _FechaApertura, value)) { OnPropertyChanged(); } } }

        public int? FechaCierreID { get; set; }
        public virtual fechaModel FechaCierre { get => _FechaCierre; set { if (SetProperty(ref _FechaCierre, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(conteoAbierto)); } } }

        public String HoraApertura { get => _HoraApertura; set { if (SetProperty(ref _HoraApertura, value)) { OnPropertyChanged(); } } }
        public String HoraCierre { get => _HoraCierre; set { if (SetProperty(ref _HoraCierre, value)) { OnPropertyChanged(); } } }

        public Double EfectivoApertura { get => _EfectivoApertura; set { if (SetProperty(ref _EfectivoApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difEfectivoApertura)); OnPropertyChanged(nameof(difTotalApertura)); } } }
        public Double MercadoPagoApertura { get => _MercadoPagoApertura; set { if (SetProperty(ref _MercadoPagoApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difMercadoPagoApertura)); OnPropertyChanged(nameof(difTotalApertura)); } } }
        public Double DiferenciaApertura { get => _DiferenciaApertura; set { if (SetProperty(ref _DiferenciaApertura, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difTotalApertura)); } } }

        public Double EfectivoCierre { get => _EfectivoCierre; set { if (SetProperty(ref _EfectivoCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difEfectivoCierre)); OnPropertyChanged(nameof(difTotalCierre)); } } }
        public Double MercadoPagoCierre { get => _MercadoPagoCierre; set { if (SetProperty(ref _MercadoPagoCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difMercadoPagoCierre)); OnPropertyChanged(nameof(difTotalCierre)); } } }
        public Double DiferenciaCierre { get => _DiferenciaCierre; set { if (SetProperty(ref _DiferenciaCierre, Math.Round(value, 2))) { OnPropertyChanged(); OnPropertyChanged(nameof(difTotalCierre)); } } }

        public string Detalle { get => _Detalle; set { if (SetProperty(ref _Detalle, value)) { OnPropertyChanged(); } } }

        public int CajaID { get; set; }
        public virtual cajaModel Caja { get => _Caja; set { if (SetProperty(ref _Caja, value)) { OnPropertyChanged(); } } }

        public int? CajaCierreID { get; set; }
        public virtual cajaModel CajaCierre { get => _CajaCierre; set { if (SetProperty(ref _CajaCierre, value)) { OnPropertyChanged(); } } }

        public int UsuarioID { get; set; }
        public virtual usuarioModel Usuario { get => _Usuario; set { if (SetProperty(ref _Usuario, value)) { OnPropertyChanged(); } } }
        #endregion // Public

        [NotMapped]
        public Double difEfectivoApertura => Caja.CajaActual - EfectivoApertura;
        [NotMapped]
        public Double difMercadoPagoApertura => Caja.MercadoPago - MercadoPagoApertura;
        [NotMapped]
        public Double difTotalApertura => difEfectivoApertura + difMercadoPagoApertura + DiferenciaApertura;

        [NotMapped]
        public Double difEfectivoCierre => CajaCierre.CajaActual - EfectivoCierre;
        [NotMapped]
        public Double difMercadoPagoCierre => CajaCierre.MercadoPago - MercadoPagoCierre;
        [NotMapped]
        public Double difTotalCierre => difEfectivoCierre + difMercadoPagoCierre + DiferenciaCierre;

        [NotMapped]

        public bool conteoAbierto => FechaCierre == null;

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
