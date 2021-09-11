﻿using System;
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
    /// Interaction logic for ctrlInfoShortcuts.xaml
    /// </summary>
    public partial class ctrlInfoShortcuts : UserControl, INotifyPropertyChanged
    {
        public ctrlInfoShortcuts()
        {
            InitializeComponent(); this.DataContext = this;
        }


        public bool hasGuardar { get => (bool)GetValue(hasGuardarProperty); set { SetValue(hasGuardarProperty, value); OnPropChanged(); } }
        public bool hasTag { get => (bool)GetValue(hasTagProperty); set { SetValue(hasTagProperty, value); OnPropChanged(); } }
        public bool hasMedidas { get => (bool)GetValue(hasMedidasProperty); set { SetValue(hasMedidasProperty, value); OnPropChanged(); } }
        public bool hasProductos { get => (bool)GetValue(hasProductosProperty); set { SetValue(hasProductosProperty, value); OnPropChanged(); } }
        public bool hasAgregar { get => (bool)GetValue(hasAgregarProperty); set { SetValue(hasAgregarProperty, value); OnPropChanged(); } }
        public bool hasAbrirProducto { get => (bool)GetValue(hasAbrirProductoProperty); set { SetValue(hasAbrirProductoProperty, value); OnPropChanged(); } }
        public bool hasCancelar { get => (bool)GetValue(hasCancelarProperty); set { SetValue(hasCancelarProperty, value); OnPropChanged(); } }

        public static readonly DependencyProperty hasGuardarProperty = DependencyProperty.Register("hasGuardar", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(false));
        public static readonly DependencyProperty hasTagProperty = DependencyProperty.Register("hasTag", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(false));
        public static readonly DependencyProperty hasMedidasProperty = DependencyProperty.Register("hasMedidas", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(false));
        public static readonly DependencyProperty hasProductosProperty = DependencyProperty.Register("hasProductos", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(false));
        public static readonly DependencyProperty hasAgregarProperty = DependencyProperty.Register("hasSeleccionar", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(false));
        public static readonly DependencyProperty hasAbrirProductoProperty = DependencyProperty.Register("hasAbrirProducto", typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(false));
        public static readonly DependencyProperty hasCancelarProperty = DependencyProperty.Register(("hasCancelar"), typeof(bool), typeof(ctrlInfoShortcuts), new PropertyMetadata(false));


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        #endregion // PropertyChanged
    }
}