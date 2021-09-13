using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrlClock.xaml
    /// </summary>
    public partial class ctrlClock : UserControl, INotifyPropertyChanged
    {
        #region Initialize
        public ctrlClock() { InitializeComponent(); }
        #endregion // Initialize


        #region Properties
        public bool hasSeconds { get => (bool)GetValue(hasSecondsProperty); set { SetValue(hasSecondsProperty, value); OnPropChanged(); } }

        public static readonly DependencyProperty hasSecondsProperty = DependencyProperty.Register("hasSeconds", typeof(bool), typeof(ctrlClock), new PropertyMetadata(true));
        #endregion // Properties


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // PropertyChanged
    }


    class ClockViewModel : Base.ViewModelBase
    {
        #region Initialize
        public ClockViewModel() { initilizeClock(); }
        #endregion // Initialize


        #region Clock
        readonly System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        void initilizeClock() { Timer.Tick += new EventHandler(Timer_Click); Timer.Interval = new TimeSpan(0, 0, 1); Timer.Start(); }
        void Timer_Click(object sender, EventArgs e) { OnPropertyChanged(nameof(stringLongTime)); OnPropertyChanged(nameof(stringShortTime)); }

        public string stringLongTime => DateTime.Now.ToString("HH:mm:ss");
        public string stringShortTime => DateTime.Now.ToString("HH:mm");
        #endregion // Clock
    }
}
