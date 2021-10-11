using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrlInfoShortcuts.xaml
    /// </summary>
    public partial class ctrlInfoShortcuts : UserControl, INotifyPropertyChanged
    {
        #region Initialize
        public ctrlInfoShortcuts() { InitializeComponent(); this.DataContext = this; }
        #endregion // Initialize


        #region Properties
        public string textF1 { get => (string)GetValue(textF1Property); set { SetValue(textF1Property, value); OnPropChanged(); } }
        public string textF2 { get => (string)GetValue(textF2Property); set { SetValue(textF2Property, value); OnPropChanged(); } }
        public string textF3 { get => (string)GetValue(textF3Property); set { SetValue(textF3Property, value); OnPropChanged(); } }
        public string textF4 { get => (string)GetValue(textF4Property); set { SetValue(textF4Property, value); OnPropChanged(); } }
        public string textF5 { get => (string)GetValue(textF5Property); set { SetValue(textF5Property, value); OnPropChanged(); } }
        public string textF6 { get => (string)GetValue(textF6Property); set { SetValue(textF6Property, value); OnPropChanged(); } }
        public string textF7 { get => (string)GetValue(textF7Property); set { SetValue(textF7Property, value); OnPropChanged(); } }
        public string textEnter { get => (string)GetValue(textEnterProperty); set { SetValue(textEnterProperty, value); OnPropChanged(); } }
        public string textEsc { get => (string)GetValue(textEscProperty); set { SetValue(textEscProperty, value); OnPropChanged(); } }


        public static readonly DependencyProperty textF1Property = DependencyProperty.Register("textF1", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty textF2Property = DependencyProperty.Register("textF2", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty textF3Property = DependencyProperty.Register("textF3", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty textF4Property = DependencyProperty.Register("textF4", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty textF5Property = DependencyProperty.Register("textF5", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty textF6Property = DependencyProperty.Register("textF6", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty textF7Property = DependencyProperty.Register("textF7", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty textEnterProperty = DependencyProperty.Register("textEnter", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty textEscProperty = DependencyProperty.Register("textEsc", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        #endregion // Properties


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // PropertyChanged
    }
}
