using IDQ.WPF.ViewModels.Helpers;
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

namespace IDQ.WPF.Views.Helpers
{
    /// <summary>
    /// Interaction logic for pagarVentaView.xaml
    /// </summary>
    public partial class pagarVentaView : UserControl
    {
        static pagarVentaView thisWindow;

        public pagarVentaView() { InitializeComponent(); thisWindow = this; }

        //public static async void updateVentaDeudorSlider(Base.ViewModelBase sentViewModel) { (thisWindow.DataContext as pagarVentaViewModel).ContentTopNavigator.updateNavigator(sentViewModel); }// updateEditorSlider(sentViewModel); }
    }
}
