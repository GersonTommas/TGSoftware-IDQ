﻿using IDQ.WPF.Base;
using System.Windows.Input;

namespace IDQ.WPF.States.Navigators
{
    public enum ViewType
    {
        Blank,
        Productos,
        ProductosBasic,
        ProductosAdvanced,
        Ventas,
        Ingresos,
        Tags,
        Medidas
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModelCommand { get; }
    }
}