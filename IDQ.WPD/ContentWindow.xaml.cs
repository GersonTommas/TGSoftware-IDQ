using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
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
        public ContentWindow() { InitializeComponent(); thisWindow = this; }
        #endregion // Initialize


        #region OnClosing
        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            base.OnClosing(e);
        }
        #endregion // OnClosing

        public static async void updateEditorSlider(Base.ViewModelBase sentObject) { (thisWindow.DataContext as ContentViewModel).updateEditorSlider(sentObject); }

        public static void updateUsuarioLogueado() { (thisWindow.DataContext as ContentViewModel).updateUsuarioActivo(); }
    }

    public class ContentViewModel : Base.ViewModelBase
    {
        #region Initialize
        bool _isAnimationLoading;

        bool _startAnimation;
        public bool startAnimation { get => _startAnimation; set { if (SetProperty(ref _startAnimation, value)) { OnPropertyChanged(); } } }

        bool _isEditBarEnabled;
        public bool isEditBarEnabled { get => _isEditBarEnabled; set { if (SetProperty(ref _isEditBarEnabled, value)) { OnPropertyChanged(); } } }

        public INavigator mainNavigator { get; } = new Navigator();
        public INavigator consumosNavigator { get; } = new Navigator();
        public INavigator logOutNavigator { get; } = new Navigator();
        public INavigator logInNavigator { get; } = new Navigator();
        public INavigator ContentTopNavigator => Shared.Navigators.ContentTopNavigator;

        public usuarioModel usuarioActivo { get => Shared.GlobalVars.usuarioLogueado; set { if (SetProperty(ref Shared.GlobalVars.usuarioLogueado, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(isLogged)); } } }
        public bool isLogged => Shared.GlobalVars.usuarioLogueado != null;

        public string tabItemTitle => usuarioActivo != null ? "Cerrar Sesion" : "Iniciar Sesion";

        public cajaModel cajaActual => context.globalCajaActual;

        public async void updateEditorSlider(Base.ViewModelBase sentViewModel)
        {
            if (_isAnimationLoading == false)
            {
                _isAnimationLoading = true;

                await PutTaskDelay(sentViewModel, sentViewModel is not null);
            }
        }
        async Task PutTaskDelay(Base.ViewModelBase sentObject, bool sentBool)
        {
            startAnimation = sentBool;

            if (!sentBool) { await Task.Delay(900); isEditBarEnabled = sentBool; }

            Shared.Navigators.ContentTopNavigator.CurrentViewModel = sentObject;

            if (sentBool) { isEditBarEnabled = sentBool; await Task.Delay(900); }

            _isAnimationLoading = false;
        }

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


        #region Commands
        public Command buttonCommandCerrarSesion => new Command((object parameter) => logInNavigator.CurrentViewModel = new LogCajaViewModel(logInNavigator, true));
        #endregion // Commands
    }
}
