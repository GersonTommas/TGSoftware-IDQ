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

namespace IDQ.WPF.Controls.Helpers
{
    /// <summary>
    /// Interaction logic for helperCtrlInfoShortcutsTextItem.xaml
    /// </summary>
    public partial class helperCtrlInfoShortcutsTextItem : UserControl, INotifyPropertyChanged
    {
        public helperCtrlInfoShortcutsTextItem()
        {
            InitializeComponent(); DataContext = this;
        }

        public string textLeft { get => (string)GetValue(textLeftProperty); set { SetValue(textLeftProperty, value); OnPropChanged(); } }
        public string textRight { get => (string)GetValue(textRightProperty); set { SetValue(textRightProperty, value); OnPropChanged(); } }
        public bool isThisEnabled { get => (bool)GetValue(isThisEnabledProperty); set { SetValue(isThisEnabledProperty, value); OnPropChanged(); } }


        public static readonly DependencyProperty textLeftProperty = DependencyProperty.Register("textLeft", typeof(string), typeof(helperCtrlInfoShortcutsTextItem), new PropertyMetadata(null));
        public static readonly DependencyProperty textRightProperty = DependencyProperty.Register("textRight", typeof(string), typeof(helperCtrlInfoShortcutsTextItem), new PropertyMetadata(null));
        public static readonly DependencyProperty isThisEnabledProperty = DependencyProperty.Register("isThisEnabled", typeof(bool), typeof(helperCtrlInfoShortcutsTextItem), new PropertyMetadata(true));





        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // PropertyChanged
    }
}
