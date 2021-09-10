using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrlClock.xaml
    /// </summary>
    public partial class ctrlClock : UserControl, INotifyPropertyChanged
    {
        public ctrlClock()
        {
            InitializeComponent();
        }

        public bool hasSeconds { get => (bool)GetValue(hasSecondsProperty); set { SetValue(hasSecondsProperty, value); OnPropChanged(); } }

        public static readonly DependencyProperty hasSecondsProperty = DependencyProperty.Register("hasSeconds", typeof(bool), typeof(ctrlClock), new PropertyMetadata(true));


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        #endregion // PropertyChanged
    }

    class ClockViewModel : Base.ViewModelBase
    {
        public ClockViewModel()
        {
            initilizeClock();
        }



        #region Clock
        readonly System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        void initilizeClock() { Timer.Tick += new EventHandler(Timer_Click); Timer.Interval = new TimeSpan(0, 0, 1); Timer.Start(); }
        void Timer_Click(object sender, EventArgs e) { OnPropertyChanged(nameof(stringLongTime)); OnPropertyChanged(nameof(stringShortTime)); }

        public string stringLongTime => DateTime.Now.ToString("HH:mm:ss");
        public string stringShortTime => DateTime.Now.ToString("HH:mm");
        #endregion // Clock
    }
}
