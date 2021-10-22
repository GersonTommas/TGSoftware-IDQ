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
        public ctrlClock() { InitializeComponent(); DataContext = this; initilizeClock(); }
        #endregion // Initialize



        #region Clock
        readonly System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        void initilizeClock() { Timer.Tick += new EventHandler(Timer_Click); Timer.Interval = new TimeSpan(0, 0, 1); Timer.Start(); }
        void Timer_Click(object sender, EventArgs e) { OnPropChanged(nameof(stringTime)); }

        public string stringTime => has24hours
                    ? hasSeconds ? DateTime.Now.ToString("HH:mm:ss") : DateTime.Now.ToString("HH:mm")
                    : hasSeconds ? DateTime.Now.ToString("hh:mm:ss:tt") : DateTime.Now.ToString("hh:mm:tt");
        #endregion // Clock



        #region Properties
        public bool hasSeconds { get => (bool)GetValue(hasSecondsProperty); set { SetValue(hasSecondsProperty, value); OnPropChanged(); } }
        public bool has24hours { get => (bool)GetValue(has24hoursProperty); set { SetValue(has24hoursProperty, value); OnPropChanged(); } }

        public static readonly DependencyProperty hasSecondsProperty = DependencyProperty.Register("hasSeconds", typeof(bool), typeof(ctrlClock), new PropertyMetadata(true));
        public static readonly DependencyProperty has24hoursProperty = DependencyProperty.Register("has24hours", typeof(bool), typeof(ctrlClock), new PropertyMetadata(true));
        #endregion // Properties



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // PropertyChanged
    }
}
