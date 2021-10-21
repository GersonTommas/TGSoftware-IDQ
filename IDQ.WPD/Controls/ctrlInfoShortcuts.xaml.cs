﻿using System.ComponentModel;
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
        public bool enabledF1 { get => (bool)GetValue(enabledF1Property); set { SetValue(enabledF1Property, value); OnPropChanged(); } }
        public string textF2 { get => (string)GetValue(textF2Property); set { SetValue(textF2Property, value); OnPropChanged(); } }
        public bool enabledF2 { get => (bool)GetValue(enabledF2Property); set { SetValue(enabledF2Property, value); OnPropChanged(); } }
        public string textF3 { get => (string)GetValue(textF3Property); set { SetValue(textF3Property, value); OnPropChanged(); } }
        public bool enabledF3 { get => (bool)GetValue(enabledF3Property); set { SetValue(enabledF3Property, value); OnPropChanged(); } }
        public string textF4 { get => (string)GetValue(textF4Property); set { SetValue(textF4Property, value); OnPropChanged(); } }
        public bool enabledF4 { get => (bool)GetValue(enabledF4Property); set { SetValue(enabledF4Property, value); OnPropChanged(); } }
        public string textF5 { get => (string)GetValue(textF5Property); set { SetValue(textF5Property, value); OnPropChanged(); } }
        public bool enabledF5 { get => (bool)GetValue(enabledF5Property); set { SetValue(enabledF5Property, value); OnPropChanged(); } }
        public string textF6 { get => (string)GetValue(textF6Property); set { SetValue(textF6Property, value); OnPropChanged(); } }
        public bool enabledF6 { get => (bool)GetValue(enabledF6Property); set { SetValue(enabledF6Property, value); OnPropChanged(); } }
        public string textF7 { get => (string)GetValue(textF7Property); set { SetValue(textF7Property, value); OnPropChanged(); } }
        public bool enabledF7 { get => (bool)GetValue(enabledF7Property); set { SetValue(enabledF7Property, value); OnPropChanged(); } }
        public string textEnter { get => (string)GetValue(textEnterProperty); set { SetValue(textEnterProperty, value); OnPropChanged(); } }
        public bool enabledEnter { get => (bool)GetValue(enabledEnterProperty); set { SetValue(enabledEnterProperty, value); OnPropChanged(); } }
        public string textDelete { get => (string)GetValue(textDeleteProperty); set { SetValue(textDeleteProperty, value); OnPropChanged(); } }
        public bool enabledDelete { get => (bool)GetValue(enabledDeleteProperty); set { SetValue(enabledDeleteProperty, value); OnPropChanged(); } }
        public string textEsc { get => (string)GetValue(textEscProperty); set { SetValue(textEscProperty, value); OnPropChanged(); } }
        public bool enabledEsc { get => (bool)GetValue(enabledEscProperty); set { SetValue(enabledEscProperty, value); OnPropChanged(); } }



        public static readonly DependencyProperty textF1Property = DependencyProperty.Register("textF1", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledF1Property = DependencyProperty.Register("enabledF1", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textF2Property = DependencyProperty.Register("textF2", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledF2Property = DependencyProperty.Register("enabledF2", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textF3Property = DependencyProperty.Register("textF3", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledF3Property = DependencyProperty.Register("enabledF3", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textF4Property = DependencyProperty.Register("textF4", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledF4Property = DependencyProperty.Register("enabledF4", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textF5Property = DependencyProperty.Register("textF5", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledF5Property = DependencyProperty.Register("enabledF5", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textF6Property = DependencyProperty.Register("textF6", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledF6Property = DependencyProperty.Register("enabledF6", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textF7Property = DependencyProperty.Register("textF7", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledF7Property = DependencyProperty.Register("enabledF7", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textEnterProperty = DependencyProperty.Register("textEnter", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledEnterProperty = DependencyProperty.Register("enabledEnter", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textDeleteProperty = DependencyProperty.Register("textDelete", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledDeleteProperty = DependencyProperty.Register("enabledDelete", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        public static readonly DependencyProperty textEscProperty = DependencyProperty.Register("textEsc", typeof(string), typeof(ctrlInfoShortcuts), new PropertyMetadata(null));
        public static readonly DependencyProperty enabledEscProperty = DependencyProperty.Register("enabledEsc", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(true));
        #endregion // Properties


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion // PropertyChanged
    }
}
