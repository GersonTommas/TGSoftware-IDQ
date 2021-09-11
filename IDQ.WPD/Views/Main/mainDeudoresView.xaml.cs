﻿using IDQ.Domain.Models;
using IDQ.WPF.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace IDQ.WPF.Views.Main
{
    /// <summary>
    /// Interaction logic for mainDeudoresView.xaml
    /// </summary>
    public partial class mainDeudoresView : UserControl
    {
        mainDeudoresViewModel dt;

        public mainDeudoresView()
        {
            InitializeComponent();
            dt = DataContext as mainDeudoresViewModel;
        }

        void CollectionViewSourceListDeuda_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = (e.Item as ventaProductoModel).CantidadFaltante > 0;
        }
    }
}