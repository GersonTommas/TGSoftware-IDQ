using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels;
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
using System.Windows.Shapes;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : Window
    {
        public ContentWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            base.OnClosing(e);
        }
    }

    public class ContentViewModel : Base.ViewModelBase
    {
        public INavigator mainNavigator { get; } = new Navigator();
        public INavigator consumosNavigator { get; } = new Navigator();

        public ContentViewModel()
        {
            mainNavigator.CurrentViewModel = new MainViewModel();
            consumosNavigator.CurrentViewModel = new ConsumosViewModel();
        }
    }
}
