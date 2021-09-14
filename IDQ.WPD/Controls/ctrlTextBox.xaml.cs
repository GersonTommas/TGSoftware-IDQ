using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace IDQ.WPF.Controls
{
    /// <summary>
    /// Interaction logic for ctrlTextBox.xaml
    /// </summary>
    public partial class ctrlTextBox : UserControl
    {
        #region Initialize
        public ctrlTextBox() { InitializeComponent(); }
        #endregion // Initialize


        #region Properties
        public string labelContent { get => (string)GetValue(labelContentProperty); set { SetValue(labelContentProperty, value); OnPropChanged(); } }
        public string text { get => (string)GetValue(textProperty); set { SetValue(textProperty, value); OnPropChanged(); } }
        public bool isHeaderTop { get => (bool)GetValue(isHeaderTopProperty); set { SetValue(isHeaderTopProperty, value); OnPropChanged(); } }
        public bool isCurrency { get => (bool)GetValue(isCurrencyProperty); set { SetValue(isCurrencyProperty, value); OnPropChanged(); } }
        public TextAlignment textAlignment { get => (TextAlignment)GetValue(textAlignmentProperty); set { SetValue(textAlignmentProperty, value); OnPropChanged(); } }
        public int inputType { get => (int)GetValue(inputTypeProperty); set { SetValue(inputTypeProperty, value); OnPropChanged(); } }
        public bool isMaster { get => (bool)GetValue(isMasterProperty); set { SetValue(isMasterProperty, value); OnPropChanged(); SetValue(FocusManager.FocusedElementProperty, textBox); } }
        public bool selectAll { get => (bool)GetValue(selectAllProperty); set { SetValue(selectAllProperty, value); OnPropChanged(); if (value) { textBox.SelectAll(); selectAll = false; } } }
        public bool isLabelOn { get => (bool)GetValue(isLabelOnProperty); set { SetValue(isLabelOnProperty, value); OnPropChanged(); } }
        public bool isReadOnly { get => (bool)GetValue(isReadOnlyProperty); set { SetValue(isReadOnlyProperty, value); OnPropChanged(); } }
        public Command enterCommand { get => (Command)GetValue(enterCommandProperty); set { SetValue(enterCommandProperty, value); OnPropChanged(); } }
        public int textWidth { get => (int)GetValue(textWithdProperty); set { SetValue(textWithdProperty, value); OnPropChanged(); } }


        public static readonly DependencyProperty labelContentProperty = DependencyProperty.Register("labelContent", typeof(string), typeof(ctrlTextBox), new PropertyMetadata(""));
        public static readonly DependencyProperty textProperty = DependencyProperty.Register("text", typeof(string), typeof(ctrlTextBox), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, null, false, UpdateSourceTrigger.PropertyChanged));
        public static readonly DependencyProperty isHeaderTopProperty = DependencyProperty.Register("isHeaderTop", typeof(bool), typeof(ctrlTextBox), new PropertyMetadata(false));
        public static readonly DependencyProperty isCurrencyProperty = DependencyProperty.Register("isCurrency", typeof(bool), typeof(ctrlTextBox), new PropertyMetadata(true));
        public static readonly DependencyProperty textAlignmentProperty = DependencyProperty.Register("textAlignment", typeof(TextAlignment), typeof(ctrlTextBox), new PropertyMetadata(TextAlignment.Right));
        public static readonly DependencyProperty inputTypeProperty = DependencyProperty.Register("inputType", typeof(int), typeof(ctrlTextBox), new PropertyMetadata(0));
        public static readonly DependencyProperty isMasterProperty = DependencyProperty.Register("isMaster", typeof(bool), typeof(ctrlTextBox), new PropertyMetadata(false));
        public static readonly DependencyProperty selectAllProperty = DependencyProperty.Register("selectAll", typeof(bool), typeof(ctrlTextBox), new PropertyMetadata(false));
        public static readonly DependencyProperty isLabelOnProperty = DependencyProperty.Register("isLabelOn", typeof(bool), typeof(ctrlTextBox), new PropertyMetadata(true));
        public static readonly DependencyProperty isReadOnlyProperty = DependencyProperty.Register("isReadOnly", typeof(bool), typeof(ctrlTextBox), new PropertyMetadata(false));
        public static readonly DependencyProperty enterCommandProperty = DependencyProperty.Register("enterCommand", typeof(Command), typeof(ctrlTextBox), new PropertyMetadata(null));
        public static readonly DependencyProperty textWithdProperty = DependencyProperty.Register("textWidth", typeof(int), typeof(ctrlTextBox), new PropertyMetadata(70));
        #endregion // Properties


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // Property Changed


        #region TextBox
        readonly System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        void initilizeClock() { Timer.Tick += new EventHandler(timer_Click); Timer.Interval = new TimeSpan(0, 0, 0, 0, 100); }
        void timer_Click(object sender, EventArgs e) { textBox.SelectAll(); Timer.Stop(); }


        void textBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender; tb.SelectAll();
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (inputType == 1)
            {
                Shared.RegexService.regexNumbers(sender, e);
            }
            else if (inputType == 2)
            {
                Shared.RegexService.regexDouble(sender, e);
            }
            else if (inputType == 3)
            {
                Shared.RegexService.regexNegativeNumbers(sender, e);
            }
        }

        void textBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (isMaster) { if (sender != null) { _ = (sender as TextBox).Focus(); (sender as TextBox).SelectAll(); initilizeClock(); Timer.Start(); } }
        }
        #endregion // TextBox
    }
}
