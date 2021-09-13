using IDQ.WPF.Enumerators;
using IDQ.WPF.ViewModels.Helpers;
using IDQ.WPF.ViewModels.Main;
using IDQ.WPF.ViewModels.Main.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDQ.WPF.States.Navigators
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Blank:
                        _navigator.CurrentViewModel = new ViewModels.xBlankNavigatorViewModel();
                        break;
                    case ViewType.Tags:
                        _navigator.CurrentViewModel = new tagNewEditViewModel();
                        break;
                    case ViewType.Medidas:
                        _navigator.CurrentViewModel = new medidaNewEditViewModel();
                        break;
                    case ViewType.Productos:
                        _navigator.CurrentViewModel = new mainProductosViewModel();
                        break;
                    case ViewType.ProductosBasic:
                        _navigator.CurrentViewModel = new productosBasicViewModel();
                        break;
                    case ViewType.ProductosAdvanced:
                        _navigator.CurrentViewModel = new productosAdvancedViewModel();
                        break;
                    case ViewType.Ventas:
                        _navigator.CurrentViewModel = new mainVentasViewModel();
                        break;
                    case ViewType.Ingresos:
                        _navigator.CurrentViewModel = new mainIngresosViewModel();
                        break;
                    default:
                        break;
                }
            }
            else if (parameter is ProductosEnum productoType)
            {

                switch (productoType)
                {
                    case ProductosEnum.New:
                        _navigator.CurrentViewModel = new productoNewEditViewModel();
                        break;
                    case ProductosEnum.Edit:
                        _navigator.CurrentViewModel = new productoNewEditViewModel();
                        break;
                    case ProductosEnum.Stock:
                        _navigator.CurrentViewModel = new stockEditViewModel();
                        break;
                    case ProductosEnum.Open:
                        break;
                }
            }*/
        }
    }
}