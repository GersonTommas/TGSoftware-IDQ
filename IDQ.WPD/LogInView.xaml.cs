using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        #region Initialize
        public LogInView() { InitializeComponent(); }
        #endregion // Initialize
    }


    public class LogInViewModel : Base.ViewModelBase
    {
        #region Initialize
        readonly INavigator Navigator = new Navigator();

        public LogInViewModel() { }

        public LogInViewModel(INavigator sentNavigator)
        {
            Navigator = sentNavigator;
        }
        #endregion Initialize



        #region Variables
        public ObservableCollection<usuarioModel> collectionSourceUsuarios => context.globalAllUsuarios;

        usuarioModel _selectedUser;
        public usuarioModel selectedUser { get { return _selectedUser; } set { if (_selectedUser != value) { _selectedUser = value; OnPropertyChanged(); } } }

        string _enteredPassword;
        public string enteredPassword { get { return _enteredPassword; } set { if (_enteredPassword != value) { _enteredPassword = value; OnPropertyChanged(); } } }
        #endregion Private



        #region Helpers
        void logIn(object sender)
        {
            if (!string.IsNullOrWhiteSpace(((PasswordBox)sender).Password) && ((PasswordBox)sender).Password == selectedUser.Contraseña)
            {
                Shared.GlobalVars.usuarioLogueado = selectedUser;
                Navigator.CurrentViewModel = new LogInCajaViewModel(Navigator, thisWindow);
            }
            else { Shared.GlobalVars.messageError.LogIn(); if (sender != null) { ((PasswordBox)sender).SelectAll(); } }
        }
        bool checkFormulario => selectedUser != null;
        #endregion // Helpers



        #region Commands
        public Command buttonCommandLogIn => new Command(
              (object parameter) => logIn(parameter),
              (object parameter) => checkFormulario);
        #endregion // Commands



        public Command comTest => new Command((object parameter) => { xTestWindow tWin = new xTestWindow(); tWin.ShowDialog(); });
    }
}
