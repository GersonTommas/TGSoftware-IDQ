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
    /// Interaction logic for ctrlRedCross.xaml
    /// </summary>
    public partial class ctrlRedCross : UserControl, INotifyPropertyChanged
    {
        public ctrlRedCross()
        {
            InitializeComponent();
        }


        public Visibility hasCross { get => (Visibility)GetValue(hasCrossProperty); set { SetValue(hasCrossProperty, value); OnPropChanged(); } }
        public Visibility hasOk { get => (Visibility)GetValue(hasCrossProperty); set { SetValue(hasCrossProperty, value); OnPropChanged(); } }
        public Visibility hasMiddle { get => (Visibility)GetValue(hasCrossProperty); set { SetValue(hasCrossProperty, value); OnPropChanged(); } }



        public static readonly DependencyProperty hasCrossProperty = DependencyProperty.Register("hasCross", typeof(Visibility), typeof(ctrlInfoShortcuts), new PropertyMetadata(Visibility.Collapsed));
        public static readonly DependencyProperty hasOkProperty = DependencyProperty.Register("hasOk", typeof(Visibility), typeof(ctrlInfoShortcuts), new PropertyMetadata(Visibility.Collapsed));
        public static readonly DependencyProperty hasMiddleProperty = DependencyProperty.Register("hasMiddle", typeof(Visibility), typeof(ctrlInfoShortcuts), new PropertyMetadata(Visibility.Collapsed));


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // PropertyChanged
    }
}
