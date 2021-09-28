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
    /// Interaction logic for ctrlTextBoxCaja.xaml
    /// </summary>
    public partial class ctrlTextBoxCaja : UserControl, INotifyPropertyChanged
    {
        #region Initialize
        public ctrlTextBoxCaja() { InitializeComponent(); }
        #endregion // Initialize


        #region Properties
        public string labelContent { get => (string)GetValue(labelContentProperty); set { SetValue(labelContentProperty, value); OnPropChanged(); } }
        public int text { get => (int)GetValue(textProperty); set { SetValue(textProperty, value); OnPropChanged(); } }
        public Decimal textPesos { get => (Decimal)GetValue(textPesosProperty); set { SetValue(textPesosProperty, value); OnPropChanged(); } }
        public int intCount { get => (int)GetValue(intCountProperty); set { SetValue(intCountProperty, value); OnPropChanged(); } }
        public int inputType { get => (int)GetValue(inputTypeProperty); set { SetValue(inputTypeProperty, value); OnPropChanged(); } }
        public bool isMaster { get => (bool)GetValue(isMasterProperty); set { SetValue(isMasterProperty, value); OnPropChanged(); } }
        public bool selectAll { get => (bool)GetValue(selectAllProperty); set { SetValue(selectAllProperty, value); OnPropChanged(); if (value) { textBox.SelectAll(); selectAll = false; } } }
        public Command enterCommand { get => (Command)GetValue(enterCommandProperty); set { SetValue(enterCommandProperty, value); OnPropChanged(); } }


        public static readonly DependencyProperty labelContentProperty = DependencyProperty.Register("labelContent", typeof(string), typeof(ctrlTextBoxCaja), new PropertyMetadata(""));
        public static readonly DependencyProperty textProperty = DependencyProperty.Register("text", typeof(int), typeof(ctrlTextBoxCaja), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, null, false, UpdateSourceTrigger.PropertyChanged));
        public static readonly DependencyProperty textPesosProperty = DependencyProperty.Register("textPesos", typeof(Decimal), typeof(ctrlTextBoxCaja), new PropertyMetadata(0.00m));
        public static readonly DependencyProperty intCountProperty = DependencyProperty.Register("intCount", typeof(int), typeof(ctrlTextBoxCaja), new PropertyMetadata(0));
        public static readonly DependencyProperty inputTypeProperty = DependencyProperty.Register("inputType", typeof(int), typeof(ctrlTextBoxCaja), new PropertyMetadata(0));
        public static readonly DependencyProperty isMasterProperty = DependencyProperty.Register("isMaster", typeof(bool), typeof(ctrlTextBoxCaja), new PropertyMetadata(false));
        public static readonly DependencyProperty selectAllProperty = DependencyProperty.Register("selectAll", typeof(bool), typeof(ctrlTextBoxCaja), new PropertyMetadata(false));
        public static readonly DependencyProperty enterCommandProperty = DependencyProperty.Register("enterCommand", typeof(Command), typeof(ctrlTextBoxCaja), new PropertyMetadata(null));
        #endregion // Initialize


        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // Property Changed


        #region TextBox
        readonly System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        void initilizeClock() { Timer.Tick += new EventHandler(Timer_Click); Timer.Interval = new TimeSpan(0, 0, 0, 0, 100); }
        void Timer_Click(object sender, EventArgs e) { textBox.SelectAll(); Timer.Stop(); }

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
            if (isMaster) { if (sender != null) { (sender as TextBox).Focus(); (sender as TextBox).SelectAll(); initilizeClock(); Timer.Start(); } }
        }
        #endregion // TextBox
    }
}
