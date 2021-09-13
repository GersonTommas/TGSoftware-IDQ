using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for LogInCajaView.xaml
    /// </summary>
    public partial class LogInCajaView : UserControl
    {
        #region Initialize
        public LogInCajaView() { InitializeComponent(); }
        #endregion // Initialize
    }


    public class LogInCajaViewModel : Base.ViewModelBase
    {
        #region Initialize
        readonly INavigator Navigator = new Navigator();

        public LogInCajaViewModel() { newCajaConteo = new cajaConteoModel(); helperLogIn(); }

        public LogInCajaViewModel(INavigator sentNavigator, Window sentWindow, bool cierre = false)
        {
            Navigator = sentNavigator; thisWindow = sentWindow;
            newCajaConteo = new cajaConteoModel();
            helperLogIn();

            try
            {
                cajaConteoModel tempCajaConteo = context.globalDb.cajaConteos.Local.Single(x => x.conteoAbierto && x.Usuario == Shared.GlobalVars.usuarioLogueado);

                if (cierre)
                {
                    if (tempCajaConteo != null)
                    {
                        _cierreCajaConteo = tempCajaConteo;
                        isCajaCierre = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("Hay una caja abierta para el usuario " + Shared.GlobalVars.usuarioLogueado.Usuario + ". Desea cerrarla y abrir una nueva?", "Caja Abierta", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        fechaModel _fecha = Shared.GlobalVars.returnFecha(); String _hora = Shared.GlobalVars.strHora;

                        tempCajaConteo.CajaCierre = new cajaModel();

                        tempCajaConteo.CajaCierre.CajaActual = context.globalCajaActual.CajaActual;
                        tempCajaConteo.CajaCierre.Fecha = _fecha;
                        tempCajaConteo.CajaCierre.Hora = _hora;
                        tempCajaConteo.CajaCierre.MercadoPago = context.globalCajaActual.MercadoPago;

                        tempCajaConteo.Detalle += "AUTOMATICO - Se cierra caja sin conteo.";
                        tempCajaConteo.FechaCierre = _fecha; tempCajaConteo.HoraCierre = _hora;

                        _ = context.globalDb.SaveChanges();
                    }
                    else
                    {
                        helperSaltear();
                    }
                }
            }
            catch
            {
                if (cierre)
                {
                    if (MessageBox.Show("No existe una Caja Abierta para el usuario " + Shared.GlobalVars.usuarioLogueado.Usuario + ". Desea crear una caja solo de cierre?", "Caja Cerrada", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        fechaModel _fecha = Shared.GlobalVars.returnFecha(); String _hora = Shared.GlobalVars.strHora;

                        _cierreCajaConteo = new cajaConteoModel();

                        _cierreCajaConteo.Caja = new cajaModel();
                        _cierreCajaConteo.Caja.CajaActual = context.globalCajaActual.CajaActual;
                        _cierreCajaConteo.Caja.Fecha = _fecha;
                        _cierreCajaConteo.Caja.Hora = _hora;
                        _cierreCajaConteo.Caja.MercadoPago = context.globalCajaActual.MercadoPago;

                        _cierreCajaConteo.Detalle = "AUTOMATICO - Se abre una caja SOLO para realizar CIERRE.";
                        _cierreCajaConteo.FechaApertura = _fecha;
                        _cierreCajaConteo.HoraApertura = _hora;
                        _cierreCajaConteo.Usuario = Shared.GlobalVars.usuarioLogueado;

                        isCajaCierre = true;
                    }
                    else
                    {
                        helperSaltear();
                    }
                }
            }
        }

        void helperLogIn()
        {
            newCajaConteo.Caja = new cajaModel();
            newCajaConteo.Caja.CajaActual = context.globalCajaActual.CajaActual;
            newCajaConteo.Caja.MercadoPago = context.globalCajaActual.MercadoPago;
            newCajaConteo.Usuario = Shared.GlobalVars.usuarioLogueado;
        }
        #endregion // Initialize



        #region Variables
        readonly cajaConteoModel _cierreCajaConteo;
        readonly bool isCajaCierre;

        int _BillUno, _BillDos, _BillCinco, _BillDiez, _BillVeinte, _BillCincuenta, _BillCien, _BillDoscientos, _BillQuinientos, _BillMil, _BillDosMil, _BillCincoMil, _BillDiezMil;

        public int BillUno { get => _BillUno; set { if (SetProperty(ref _BillUno, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosUno)); helperUpdatePesos(); } } }
        public Double PesosUno => BillUno;
        public int BillDos { get => _BillDos; set { if (SetProperty(ref _BillDos, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDos)); helperUpdatePesos(); } } }
        public Double PesosDos => BillDos * 2;
        public int BillCinco { get => _BillCinco; set { if (SetProperty(ref _BillCinco, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosCinco)); helperUpdatePesos(); } } }
        public Double PesosCinco => BillCinco * 5;
        public int BillDiez { get => _BillDiez; set { if (SetProperty(ref _BillDiez, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDiez)); helperUpdatePesos(); } } }
        public Double PesosDiez => BillDiez * 10;
        public int BillVeinte { get => _BillVeinte; set { if (SetProperty(ref _BillVeinte, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosVeinte)); helperUpdatePesos(); } } }
        public Double PesosVeinte => BillVeinte * 20;
        public int BillCincuenta { get => _BillCincuenta; set { if (SetProperty(ref _BillCincuenta, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosCincuenta)); helperUpdatePesos(); } } }
        public Double PesosCincuenta => BillCincuenta * 50;
        public int BillCien { get => _BillCien; set { if (SetProperty(ref _BillCien, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosCien)); helperUpdatePesos(); } } }
        public Double PesosCien => BillCien * 100;
        public int BillDoscientos { get => _BillDoscientos; set { if (SetProperty(ref _BillDoscientos, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDoscientos)); helperUpdatePesos(); } } }
        public Double PesosDoscientos => BillDoscientos * 200;
        public int BillQuinientos { get => _BillQuinientos; set { if (SetProperty(ref _BillQuinientos, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosQuinientos)); helperUpdatePesos(); } } }
        public Double PesosQuinientos => BillQuinientos * 500;
        public int BillMil { get => _BillMil; set { if (SetProperty(ref _BillMil, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosMil)); helperUpdatePesos(); } } }
        public Double PesosMil => BillMil * 1000;
        public int BillDosMil { get => _BillDosMil; set { if (SetProperty(ref _BillDosMil, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDosMil)); helperUpdatePesos(); } } }
        public Double PesosDosMil => BillDosMil * 2000;
        public int BillCincoMil { get => _BillCincoMil; set { if (SetProperty(ref _BillCincoMil, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosCincoMil)); helperUpdatePesos(); } } }
        public Double PesosCincoMil => BillCincoMil * 5000;
        public int BillDiezMil { get => _BillDiezMil; set { if (SetProperty(ref _BillDiezMil, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDiezMil)); helperUpdatePesos(); } } }
        public Double PesosDiezMil => BillDiezMil * 10000;

        public cajaConteoModel newCajaConteo { get; } = new cajaConteoModel();

        void helperUpdatePesos()
        {
            newCajaConteo.EfectivoApertura = PesosUno + PesosDos + PesosCinco + PesosDiez + PesosVeinte + PesosCincuenta + PesosCien + PesosDoscientos + PesosQuinientos + PesosMil + PesosDosMil + PesosCincoMil;
        }
        #endregion // Variables



        #region Helpers
        void helperSaltear()
        {
            //if(newCajaConteo.Abierto) { Navigator.CurrentViewModel = new LogInViewModel(); }
            //else {
            ContentWindow cWindow = new ContentWindow(); cWindow.Show(); thisWindow.Close();
            //}

        }

        void helperGuardar()
        {
            fechaModel _fechaActual = Shared.GlobalVars.returnFecha(); String _HoraActual = Shared.GlobalVars.strHora;

            if (isCajaCierre)
            {
                if (_cierreCajaConteo != null)
                {
                    _cierreCajaConteo.CajaCierre = new cajaModel();

                    _cierreCajaConteo.CajaCierre.CajaActual = context.globalCajaActual.CajaActual;
                    _cierreCajaConteo.CajaCierre.MercadoPago = context.globalCajaActual.MercadoPago;
                    _cierreCajaConteo.CajaCierre.Fecha = _fechaActual;
                    _cierreCajaConteo.CajaCierre.Hora = _HoraActual;

                    _cierreCajaConteo.FechaCierre = _fechaActual;
                    _cierreCajaConteo.HoraCierre = _HoraActual;
                    _cierreCajaConteo.EfectivoCierre = newCajaConteo.EfectivoApertura;
                    _cierreCajaConteo.MercadoPagoCierre = newCajaConteo.MercadoPagoApertura;
                }
            }
            else
            {
                newCajaConteo.FechaApertura = _fechaActual;
                newCajaConteo.HoraApertura = _HoraActual;
                newCajaConteo.Caja.Fecha = _fechaActual;
                newCajaConteo.Caja.Hora = _HoraActual;
                newCajaConteo.FechaApertura = _fechaActual;
                newCajaConteo.HoraApertura = _HoraActual;

                context.globalDb.cajaConteos.Local.Add(newCajaConteo);
            }

            _ = context.globalDb.SaveChanges();

            helperSaltear();
        }

        bool checkGuardar => BillCien >= 0 && BillCinco >= 0 && BillCincoMil >= 0 && BillCincuenta >= 0 && BillDiez >= 0 && BillDiezMil >= 0 && BillDos >= 0 && BillDosMil >= 0 && BillMil >= 0 && BillQuinientos >= 0 && BillUno >= 0 && BillVeinte >= 0;
        #endregion // Helpers



        #region Commands
        public Command buttonCommandSaltear => new Command((object parameter) => helperSaltear());

        public Command buttonCommandGuardar => new Command((object parameter) => helperGuardar(), (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
