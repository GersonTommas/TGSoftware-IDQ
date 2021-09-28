using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;
using static IDQ.WPF.App;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();
            Loaded += Splash_Loaded;
        }

        private async void Splash_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Current.InitializeApplication();
                _ = Current.Dispatcher.BeginInvoke((Action)(() =>
                  {
                      Close();
                  }));
            });
        }

        public void SetProgress(Double progress)
        {
            _ = Dispatcher.BeginInvoke((Action)(() => progBar.Value = progress));
        }
    }
}