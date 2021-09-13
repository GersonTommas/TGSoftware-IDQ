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

        public static async void updateEditorSlider(Base.ViewModelBase sentObject)
        {
            bool tempBool = sentObject is not null;

            if (tempBool) { Shared.GlobalVars.upperNavigator.CurrentViewModel = sentObject; }
            (thisWindow.DataContext as ContentViewModel).testIsEnabled = tempBool;
            if (tempBool == false)
            {
                PutTaskDelay(sentObject);
            }
        }
        static async Task PutTaskDelay(Base.ViewModelBase sentObject)
        {
            await Task.Delay(2000);
            Shared.GlobalVars.upperNavigator.CurrentViewModel = sentObject;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class ContentViewModel : Base.ViewModelBase
    {
        #region Initialize
        bool _testIsEnabled;
        public bool testIsEnabled { get => _testIsEnabled; set { if (SetProperty(ref _testIsEnabled, value)) { OnPropertyChanged(); } } }

        public INavigator mainNavigator { get; } = new Navigator();
        public INavigator consumosNavigator { get; } = new Navigator();
        public INavigator upperNavigator => Shared.GlobalVars.upperNavigator;

        public ContentViewModel()
        {
            mainNavigator.CurrentViewModel = new MainViewModel();
            consumosNavigator.CurrentViewModel = new ConsumosViewModel();
        }
        #endregion // Initialize
    }
}
