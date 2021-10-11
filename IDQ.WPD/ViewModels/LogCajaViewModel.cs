using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace IDQ.WPF.ViewModels
{
    public class LogCajaViewModel : Base.ViewModelBase
    {
        #region Initialize
        readonly INavigator thisNavigator;

        public LogCajaViewModel() { }
        public LogCajaViewModel(INavigator sentNavigator, bool sentIsCierre = false)
        {
            thisNavigator = sentNavigator;

            isCierre = sentIsCierre;

            if (sentIsCierre)
            {

                //newCajaConteo.Usuario = Shared.GlobalVars.usuarioLogueado;

                isLoginIn = false;
            }
        }

        void isLoginInUpdate(bool value)
        {
            if (value)
            {
                _stopUpdate = true;
                BillCien = BillCinco = BillCincoMil = BillCincuenta = BillDiez = BillDiezMil = BillDos = BillDoscientos = BillDosMil = BillMil = BillQuinientos = BillUno = BillVeinte = 0;
                _stopUpdate = false;
                helperUpdatePesos();

                _cierreConteo = null;
                //_cierreCajaConteo = null;
                isCajaCierre = false;
            }
            else
            {
                conteoModel tempConteo = null;
                //cajaConteoModel tempCajaConteo = null;

                usuarioModel tempUsuario = isCierre ? Shared.GlobalVars.usuarioLogueado : selectedUser;

                try { tempConteo = context.globalDb.conteos.Local.Single(x => x.conteoAbierto && x.Usuario == tempUsuario); } catch { }
                //try { tempCajaConteo = context.globalDb.cajaConteos.Local.Single(x => x.conteoAbierto && x.Usuario == tempUsuario); } catch { }
                

                if (isCierre)
                {
                    if (tempConteo != null)
                    //if (tempCajaConteo != null)
                    {
                        _cierreConteo = tempConteo; isCajaCierre = true;
                        //_cierreCajaConteo = tempCajaConteo; isCajaCierre = true;
                    }
                    else
                    {
                        if (MessageBox.Show("No existe una Caja Abierta para el usuario " + Shared.GlobalVars.usuarioLogueado.Usuario + ". Desea crear una caja solo de cierre?", "Caja Cerrada", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            _cierreConteo = new conteoModel()
                            {
                                CajaEntrada = new pseudoCajaModel()
                                {
                                    CajaEfectivo = context.globalCajaActual.Efectivo,
                                    CajaMercadoPago = context.globalCajaActual.MercadoPago,
                                    AgregadoEfectivo = context.globalCajaActual.Efectivo,
                                    AgregadoMercadoPago = context.globalCajaActual.MercadoPago,
                                    Detalles = "AUTOMATICO - Se abre caja SOLO para realizar CIERRE."
                                }
                            };
                            /*
                            _cierreCajaConteo = new cajaConteoModel
                            {
                                Caja = new cajaModel
                                {
                                    Efectivo = context.globalCajaActual.Efectivo,
                                    Fecha = _fecha,
                                    Hora = _hora,
                                    MercadoPago = context.globalCajaActual.MercadoPago
                                },

                                Detalle = "AUTOMATICO - Se abre una caja SOLO para realizar CIERRE.",
                                FechaApertura = _fecha,
                                HoraApertura = _hora,
                                Usuario = Shared.GlobalVars.usuarioLogueado
                            };*/

                            isCajaCierre = true;
                        }
                        else { helperSaltear(); }
                    }
                }
                else
                {
                    if (tempConteo != null)
                    //if (tempCajaConteo != null)
                    {
                        if (MessageBox.Show("Hay una caja abierta para el usuario " + selectedUser.Usuario + ". Desea cerrarla y abrir una nueva?", "Caja Abierta", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            fechaModel _fecha = Shared.GlobalVars.returnFecha(); String _Hora = Shared.GlobalVars.strHora;

                            tempConteo.CajaSalida = new pseudoCajaModel()
                            {
                                Fecha = _fecha,
                                Hora = _Hora,
                                CajaEfectivo = context.globalCajaActual.Efectivo,
                                CajaMercadoPago = context.globalCajaActual.MercadoPago,
                                AgregadoEfectivo = context.globalCajaActual.Efectivo,
                                AgregadoMercadoPago = context.globalCajaActual.MercadoPago,
                                Detalles = "AUTOMATICO - Se cierra caja sin conteo."
                            };
                            _ = context.globalDb.SaveChanges();
                            /*
                            tempCajaConteo.CajaCierre = new cajaModel
                            {
                                Efectivo = context.globalCajaActual.Efectivo,
                                Fecha = _fecha,
                                Hora = _Hora,
                                MercadoPago = context.globalCajaActual.MercadoPago
                            };

                            tempCajaConteo.Detalle += "AUTOMATICO - Se cierra caja sin conteo.";
                            tempCajaConteo.FechaCierre = _fecha; tempCajaConteo.HoraCierre = _Hora;

                            _ = context.globalDb.SaveChanges();*/
                        }
                        else { helperSaltear(); }
                    }
                }
            }
        }
        #endregion Initialize



        #region Variables
        bool _isLoginIn = true;
        public bool isLoginIn { get => _isLoginIn; set { if (SetProperty(ref _isLoginIn, value)) { OnPropertyChanged(); isLoginInUpdate(value); } } }

        bool _isCierre;
        public bool isCierre { get => _isCierre; set { if (SetProperty(ref _isCierre, value)) { OnPropertyChanged(); } } }

        bool isCajaCierre;

        int _BillUno, _BillDos, _BillCinco, _BillDiez, _BillVeinte, _BillCincuenta, _BillCien, _BillDoscientos, _BillQuinientos, _BillMil, _BillDosMil, _BillCincoMil, _BillDiezMil;

        public int BillUno { get => _BillUno; set { if (SetProperty(ref _BillUno, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosUno)); helperUpdatePesos(); } } }
        public Decimal PesosUno => BillUno;
        public int BillDos { get => _BillDos; set { if (SetProperty(ref _BillDos, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDos)); helperUpdatePesos(); } } }
        public Decimal PesosDos => BillDos * 2;
        public int BillCinco { get => _BillCinco; set { if (SetProperty(ref _BillCinco, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosCinco)); helperUpdatePesos(); } } }
        public Decimal PesosCinco => BillCinco * 5;
        public int BillDiez { get => _BillDiez; set { if (SetProperty(ref _BillDiez, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDiez)); helperUpdatePesos(); } } }
        public Decimal PesosDiez => BillDiez * 10;
        public int BillVeinte { get => _BillVeinte; set { if (SetProperty(ref _BillVeinte, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosVeinte)); helperUpdatePesos(); } } }
        public Decimal PesosVeinte => BillVeinte * 20;
        public int BillCincuenta { get => _BillCincuenta; set { if (SetProperty(ref _BillCincuenta, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosCincuenta)); helperUpdatePesos(); } } }
        public Decimal PesosCincuenta => BillCincuenta * 50;
        public int BillCien { get => _BillCien; set { if (SetProperty(ref _BillCien, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosCien)); helperUpdatePesos(); } } }
        public Decimal PesosCien => BillCien * 100;
        public int BillDoscientos { get => _BillDoscientos; set { if (SetProperty(ref _BillDoscientos, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDoscientos)); helperUpdatePesos(); } } }
        public Decimal PesosDoscientos => BillDoscientos * 200;
        public int BillQuinientos { get => _BillQuinientos; set { if (SetProperty(ref _BillQuinientos, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosQuinientos)); helperUpdatePesos(); } } }
        public Decimal PesosQuinientos => BillQuinientos * 500;
        public int BillMil { get => _BillMil; set { if (SetProperty(ref _BillMil, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosMil)); helperUpdatePesos(); } } }
        public Decimal PesosMil => BillMil * 1000;
        public int BillDosMil { get => _BillDosMil; set { if (SetProperty(ref _BillDosMil, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDosMil)); helperUpdatePesos(); } } }
        public Decimal PesosDosMil => BillDosMil * 2000;
        public int BillCincoMil { get => _BillCincoMil; set { if (SetProperty(ref _BillCincoMil, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosCincoMil)); helperUpdatePesos(); } } }
        public Decimal PesosCincoMil => BillCincoMil * 5000;
        public int BillDiezMil { get => _BillDiezMil; set { if (SetProperty(ref _BillDiezMil, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(PesosDiezMil)); helperUpdatePesos(); } } }
        public Decimal PesosDiezMil => BillDiezMil * 10000;


        bool _stopUpdate;
        void helperUpdatePesos() { if (_stopUpdate == false) { pseudoCaja.Efectivo = PesosUno + PesosDos + PesosCinco + PesosDiez + PesosVeinte + PesosCincuenta + PesosCien + PesosDoscientos + PesosQuinientos + PesosMil + PesosDosMil + PesosCincoMil; } }


        public ObservableCollection<usuarioModel> collectionSourceUsuarios => context.globalAllUsuarios;


        usuarioModel _selectedUser;
        public usuarioModel selectedUser { get => _selectedUser; set { if (SetProperty(ref _selectedUser, value)) { OnPropertyChanged(); } } }

        //cajaConteoModel _cierreCajaConteo;
        conteoModel _cierreConteo;
        readonly pseudoCajaModel _pseudoCaja = new pseudoCajaModel() { CajaEfectivo = context.globalCajaActual.Efectivo, CajaMercadoPago = context.globalCajaActual.MercadoPago };
        public pseudoCajaModel pseudoCaja => _pseudoCaja;

        //cajaConteoModel _newCajaConteo = new cajaConteoModel() { Caja = new cajaModel() { Efectivo = context.globalCajaActual.Efectivo, MercadoPago = context.globalCajaActual.MercadoPago } };
        //public cajaConteoModel newCajaConteo { get => _newCajaConteo; set { if (SetProperty(ref _newCajaConteo, value)) { OnPropertyChanged(); } } }
        #endregion Private



        #region Helpers
        void logIn(object sender)
        {
            if (!string.IsNullOrWhiteSpace(((PasswordBox)sender).Password) && ((PasswordBox)sender).Password == selectedUser.Contraseña)
            {
                //newCajaConteo.Usuario = selectedUser;
                isLoginIn = false;
            }
            else { Shared.GlobalVars.messageError.LogIn(); if (sender != null) { ((PasswordBox)sender).SelectAll(); } }
        }

        void helperSaltear()
        {
            if (isCierre)
            {
                Shared.GlobalVars.updateUsuarioLogueado(null);

                isCierre = false;
                isLoginIn = true;

                //newCajaConteo.Usuario = null;
            }
            else
            {
                Shared.GlobalVars.updateUsuarioLogueado(selectedUser);
            }

            thisNavigator.CurrentViewModel = null;
        }

        void helperGuardar()
        {
            fechaModel _fechaActual = Shared.GlobalVars.returnFecha(); String _HoraActual = Shared.GlobalVars.strHora;

            if (isCajaCierre)
            {
                if (_cierreConteo != null)
                //if (_cierreCajaConteo != null)
                {
                    _cierreConteo.Usuario = selectedUser;
                    _cierreConteo.CajaSalida = pseudoCaja;
                    /*
                    _cierreCajaConteo.CajaCierre = new cajaModel
                    {
                        Efectivo = context.globalCajaActual.Efectivo,
                        MercadoPago = context.globalCajaActual.MercadoPago,
                        Fecha = _fechaActual,
                        Hora = _HoraActual
                    };

                    _cierreCajaConteo.FechaCierre = _fechaActual;
                    _cierreCajaConteo.HoraCierre = _HoraActual;
                    _cierreCajaConteo.EfectivoCierre = newCajaConteo.EfectivoApertura;
                    _cierreCajaConteo.MercadoPagoCierre = newCajaConteo.MercadoPagoApertura;
                    */
                }
            }
            else
            {
                pseudoCaja.Fecha = _fechaActual;
                pseudoCaja.Hora = _HoraActual;

                conteoModel newConteo = new conteoModel() { Fecha = _fechaActual, CajaEntrada = pseudoCaja, Usuario = selectedUser };
                
                //newCajaConteo.FechaApertura = _fechaActual;
                //newCajaConteo.HoraApertura = _HoraActual;
                //newCajaConteo.Caja.Fecha = _fechaActual;
                //newCajaConteo.Caja.Hora = _HoraActual;
                //newCajaConteo.FechaApertura = _fechaActual;
                //newCajaConteo.HoraApertura = _HoraActual;

                //context.globalDb.cajaConteos.Local.Add(newCajaConteo);
                context.globalDb.conteos.Local.Add(newConteo);
            }

            _ = context.globalDb.SaveChanges();

            helperSaltear();
        }

        bool checkLogIn => selectedUser != null;

        bool checkGuardar => pseudoCaja.Efectivo > 0;
        #endregion // Helpers



        #region Commands
        public Command buttonCommandLogIn => new Command(
              (object parameter) => logIn(parameter),
              (object parameter) => checkLogIn);

        public Command buttonCommandSaltear => new Command((object parameter) => helperSaltear());

        public Command buttonCommandGuardar => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar);

        public Command buttonCommandCancelar => new Command((object parameter) => isLoginIn = true);
        #endregion // Commands
    }
}
