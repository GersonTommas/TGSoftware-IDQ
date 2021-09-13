using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for userControlInfoColors.xaml
    /// </summary>
    public partial class ctrlInfoColors : UserControl, INotifyPropertyChanged
    {
        #region Initialize
        public ctrlInfoColors() { InitializeComponent(); }
        #endregion // Initialize


        #region Properties
        public bool hasAgregado { get => (bool)GetValue(hasAgregadoProperty); set { SetValue(hasAgregadoProperty, value); OnPropChanged(); } }
        public bool hasMiddleColors { get => (bool)GetValue(hasMiddleColorsProperty); set { SetValue(hasMiddleColorsProperty, value); OnPropChanged(); } }
        public bool hasActivoInactivo { get => (bool)GetValue(hasActivoInactivoProperty); set { SetValue(hasActivoInactivoProperty, value); OnPropChanged(); } }
        public bool hasStock { get => (bool)GetValue(hasStockProperty); set { SetValue(hasStockProperty, value); OnPropChanged(); } }
        public bool isActivoFullLine { get => (bool)GetValue(isActivoFullLineProperty); set { SetValue(isActivoFullLineProperty, value); OnPropChanged(); } }
        public bool hasActiveAndStock { get => (bool)GetValue(hasActiveAndStockProperty); set { SetValue(hasActiveAndStockProperty, value); OnPropChanged(); } }


        public static readonly DependencyProperty hasAgregadoProperty = DependencyProperty.Register("hasAgregado", typeof(bool), typeof(ctrlInfoColors), new PropertyMetadata(false));
        public static readonly DependencyProperty hasMiddleColorsProperty = DependencyProperty.Register("hasMiddleColors", typeof(bool), typeof(ctrlInfoColors), new PropertyMetadata(false));
        public static readonly DependencyProperty hasActivoInactivoProperty = DependencyProperty.Register("hasActivoInactivo", typeof(bool), typeof(ctrlInfoColors), new PropertyMetadata(false));
        public static readonly DependencyProperty hasStockProperty = DependencyProperty.Register("hasStock", typeof(bool), typeof(ctrlInfoColors), new PropertyMetadata(true));
        public static readonly DependencyProperty isActivoFullLineProperty = DependencyProperty.Register("isActivoFullLine", typeof(bool), typeof(ctrlInfoColors), new PropertyMetadata(true));
        public static readonly DependencyProperty hasActiveAndStockProperty = DependencyProperty.Register("hasActiveAndStock", typeof(bool), typeof(ctrlInfoColors), new PropertyMetadata(false));
        #endregion // Properties


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // PropertyChanged
    }
}
