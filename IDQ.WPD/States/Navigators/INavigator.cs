using IDQ.WPF.Base;
using System.Windows.Input;

namespace IDQ.WPF.States.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        bool startAnimation { get; set; }

        bool isNavigatorEnabled { get; set; }

        void updateNavigator(Base.ViewModelBase sentViewModel);

        //ICommand UpdateCurrentViewModelCommand { get; }
    }
}
