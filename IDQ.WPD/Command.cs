﻿using System;
using System.Windows.Input;

namespace IDQ
{
    public class Command : ICommand
    {
        public delegate void ICommandOnExecute(object parameter); public delegate bool ICommandOnCanExecute(object parameter);

        private readonly ICommandOnExecute _execute; private readonly ICommandOnCanExecute _canExecute;

        public Command(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod = null) { _execute = onExecuteMethod; _canExecute = onCanExecuteMethod; }

        #region ICommand Members
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }
        public bool CanExecute(object parameter) { return _canExecute?.Invoke(parameter) ?? true; }
        public void Execute(object parameter = null) { _execute?.Invoke(parameter); }
        #endregion // ICommand Members
    }
}
