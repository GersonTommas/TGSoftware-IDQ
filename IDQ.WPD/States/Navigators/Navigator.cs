﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace IDQ.WPF.States.Navigators
{
    public class Navigator : Domain.Base.PropertyChangedBase, INavigator
    {
        Base.ViewModelBase _currentViewModel;
        public virtual Base.ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value; OnPropertyChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}