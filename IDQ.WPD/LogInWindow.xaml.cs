using IDQ.WPF.States.Navigators;
using System.Windows;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        #region Initialize
        public LogInWindow()
        {
            InitializeComponent(); (DataContext as LogInWindowViewModel).setWindow(this);
        }
        #endregion // Initialize
    }


    public class LogInWindowViewModel : Base.ViewModelBase
    {
        #region Initialize
        public INavigator Navigator { get; } = new Navigator();

        public LogInWindowViewModel()
        {
            Navigator.CurrentViewModel = new LogInViewModel(Navigator);
        }

        public void setWindow(Window sentWindow)
        {
            (Navigator.CurrentViewModel as LogInViewModel).thisWindow = sentWindow;
        }
        #endregion // Initialize
    }
}
