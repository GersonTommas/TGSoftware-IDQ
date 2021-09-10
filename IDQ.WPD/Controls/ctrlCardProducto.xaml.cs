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
    /// Interaction logic for ctrlCardProducto.xaml
    /// </summary>
    public partial class ctrlCardProducto : UserControl, INotifyPropertyChanged
    {
        public ctrlCardProducto()
        {
            InitializeComponent();
        }

        public string titleText { get => (string)GetValue(titleTextProperty); set { SetValue(titleTextProperty, value); OnPropChanged(); } }
        public string valueText { get => (string)GetValue(valueTextProperty); set { SetValue(valueTextProperty, value); OnPropChanged(); } }
        public bool isCurrency { get => (bool)GetValue(isCurrencyProperty); set { SetValue(isCurrencyProperty, value); OnPropChanged(); } }


        public static readonly DependencyProperty titleTextProperty = DependencyProperty.Register("titleText", typeof(string), typeof(ctrlCardProducto), new PropertyMetadata(""));
        public static readonly DependencyProperty valueTextProperty = DependencyProperty.Register("valueText", typeof(string), typeof(ctrlCardProducto), new PropertyMetadata(""));
        public static readonly DependencyProperty isCurrencyProperty = DependencyProperty.Register("isCurrency", typeof(bool), typeof(ctrlCardProducto), new PropertyMetadata(false));



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        #endregion // PropertyChanged
    }
}
