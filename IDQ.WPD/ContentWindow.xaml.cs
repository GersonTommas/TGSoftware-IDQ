using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : Window
    {
        #region Initialize
        static ContentWindow thisWindow;
        public ContentWindow()
        {
            InitializeComponent(); thisWindow = this;
        }
        #endregion // Initialize


        #region OnClosing
        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            base.OnClosing(e);
        }
        #endregion // OnClosing

        public static void updateUsuarioLogueado() { (thisWindow.DataContext as ContentViewModel).updateUsuarioActivo(); }
    }

    public class ContentViewModel : Base.ViewModelBase
    {
        #region Initialize
        public INavigator mainNavigator { get; } = new Navigator();
        public INavigator consumosNavigator { get; } = new Navigator();
        public INavigator logOutNavigator { get; } = new Navigator();
        public INavigator logInNavigator { get; } = new Navigator();
        public INavigator ContentTopNavigator => Shared.Navigators.ContentTopNavigator;

        public usuarioModel usuarioActivo { get => Shared.GlobalVars.usuarioLogueado; set { if (SetProperty(ref Shared.GlobalVars.usuarioLogueado, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(isLogged)); } } }
        public bool isLogged => Shared.GlobalVars.usuarioLogueado is not null;

        public string tabItemTitle => usuarioActivo is not null ? "Cerrar Sesion" : "Iniciar Sesion";

        public cajaModel cajaActual => context.globalCajaActual;

        public void updateUsuarioActivo()
        {
            OnPropertyChanged(nameof(usuarioActivo));
            OnPropertyChanged(nameof(tabItemTitle));
        }

        public ContentViewModel()
        {
            mainNavigator.CurrentViewModel = new MainViewModel();
            consumosNavigator.CurrentViewModel = new ConsumosViewModel();
            logInNavigator.CurrentViewModel = new LogCajaViewModel(logInNavigator);
        }
        #endregion // Initialize


        public string testString => Keyboard.FocusedElement?.ToString();



        #region Commands
        public Command buttonCommandCerrarSesion => new Command((object parameter) => logInNavigator.CurrentViewModel = new LogCajaViewModel(logInNavigator, true));
        #endregion // Commands
    }
}
