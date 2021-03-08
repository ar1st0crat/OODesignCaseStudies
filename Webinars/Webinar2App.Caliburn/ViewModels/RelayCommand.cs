﻿using System;
using System.Windows.Input;

namespace Webinar2App.Wpf.ViewModels
{
    class RelayCommand : ICommand
    {
        private readonly Action _action;
        private readonly Action<object> _actionParameterized;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public RelayCommand(Action<object> action)
        {
            _actionParameterized = action;
        }

        #region ICommand Members

        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action();
            }
            else
            {
                if (parameter != null)
                {
                    _actionParameterized(parameter);
                }
            }
        }

        #endregion
    }
}
