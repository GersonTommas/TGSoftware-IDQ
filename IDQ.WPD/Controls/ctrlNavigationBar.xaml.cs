using IDQ.Domain.Models;
using IDQ.Domain.Services;
using IDQ.EntityFramework;
using IDQ.EntityFramework.Services;
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

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for navigationBar.xaml
    /// </summary>
    public partial class ctrlNavigationBar : UserControl
    {
        public ctrlNavigationBar()
        {
            InitializeComponent();
        }
    }

    class navigationBarViewModel : Base.ViewModelBase
    {
        public navigationBarViewModel()
        {
            initilizeClock();
        }

        public cajaModel cajaActual => context.globalCajaActual;

        #region Clock
        readonly System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        void initilizeClock() { Timer.Tick += new EventHandler(Timer_Click); Timer.Interval = new TimeSpan(0, 0, 1); Timer.Start(); }
        void Timer_Click(object sender, EventArgs e) { OnPropertyChanged(nameof(strClock)); }

        public string strClock => DateTime.Now.ToString(format: "HH:mm:ss");
        #endregion // Clock
    }
}