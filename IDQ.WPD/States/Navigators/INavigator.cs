using IDQ.WPF.Base;
using System.Windows.Input;

namespace IDQ.WPF.States.Navigators
{
    public enum ViewType
    {
        Productos,
        Ventas,
        Ingresos
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
