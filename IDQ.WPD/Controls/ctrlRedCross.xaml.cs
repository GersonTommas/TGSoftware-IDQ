using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

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
