using IDQ.WPF.ViewModels.Main;
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
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Productos:
                        _navigator.CurrentViewModel = new mainProductosViewModel();
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
        }
    }
}