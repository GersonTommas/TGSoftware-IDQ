using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrlCardProducto.xaml
    /// </summary>
    public partial class ctrlCardProducto : UserControl, INotifyPropertyChanged
    {
        #region Initialize
        public ctrlCardProducto() { InitializeComponent(); DataContext = this; }
        #endregion // Initialize


        #region Properties
        public string titleText { get => (string)GetValue(titleTextProperty); set { SetValue(titleTextProperty, value); OnPropChanged(); } }
        public string valueText { get => (string)GetValue(valueTextProperty); set { SetValue(valueTextProperty, value); OnPropChanged(); } }
        public bool isCurrency { get => (bool)GetValue(isCurrencyProperty); set { SetValue(isCurrencyProperty, value); OnPropChanged(); } }


        public static readonly DependencyProperty titleTextProperty = DependencyProperty.Register("titleText", typeof(string), typeof(ctrlCardProducto), new PropertyMetadata(""));
        public static readonly DependencyProperty valueTextProperty = DependencyProperty.Register("valueText", typeof(string), typeof(ctrlCardProducto), new PropertyMetadata(""));
        public static readonly DependencyProperty isCurrencyProperty = DependencyProperty.Register("isCurrency", typeof(bool), typeof(ctrlCardProducto), new PropertyMetadata(false));
        #endregion // Properties


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // PropertyChanged
    }
}