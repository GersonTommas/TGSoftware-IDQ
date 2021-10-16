using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IDQ.WPF.States.Navigators
{
    public class Navigator : Domain.Base.PropertyChangedBase, INavigator
    {
        Base.ViewModelBase _currentViewModel;

        bool _startAnimation;
        public bool startAnimation { get => _startAnimation; set { if (SetProperty(ref _startAnimation, value)) { OnPropertyChanged(); } } }

        bool _isNavigatorEnabled;
        public bool isNavigatorEnabled { get => _isNavigatorEnabled; set { if (SetProperty(ref _isNavigatorEnabled, value)) { OnPropertyChanged(); } } }

        System.Windows.IInputElement oldFocus;

        public virtual Base.ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value; OnPropertyChanged();
            }
        }

        bool _isAnimationLoading;

        public async void updateNavigator(Base.ViewModelBase sentViewModel)
        {
            if (_isAnimationLoading == false)
            {
                _isAnimationLoading = true;

                await PutTaskDelay(sentViewModel, sentViewModel is not null);
            }
        }

        async Task PutTaskDelay(Base.ViewModelBase sentViewModel, bool sentBool)
        {
            startAnimation = sentBool;

            if (!sentBool) { await Task.Delay(500); isNavigatorEnabled = sentBool;  }

            CurrentViewModel = sentViewModel;

            if (sentBool) { oldFocus = Keyboard.FocusedElement; isNavigatorEnabled = sentBool; await Task.Delay(500);  }

            _isAnimationLoading = false;

            if (!sentBool) { Keyboard.Focus(oldFocus); }
        }

        //public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
