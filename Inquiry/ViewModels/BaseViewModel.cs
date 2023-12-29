﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Inquiry.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue) == false)
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

                return (true);
            }

            return (false);
        }

        public class DelegateCommand : ICommand
        {
            private readonly Action<object> _executeAction;
            private readonly Func<object, bool> _canExecuteAction;

            public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
            {
                _executeAction = executeAction;
                _canExecuteAction = canExecuteAction;
            }

            public DelegateCommand(Action<object> executeAction)
            {
                _executeAction = executeAction;
            }

            public void Execute(object parameter) => _executeAction(parameter);

            public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;

            public event EventHandler CanExecuteChanged;

            public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public class AsyncDelegateCommand : ICommand
        {
            private readonly Func<object, Task> _executeAction;
            private bool _canExecute;

            public AsyncDelegateCommand(Func<object, Task> executeAction)
            {
                _executeAction = executeAction;
                _canExecute = true;
            }

            public async void Execute(object parameter) => await ExecuteAsync(parameter);

            public bool CanExecute(object parameter) => _canExecute == true;

            public event EventHandler CanExecuteChanged;

            public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            private async Task ExecuteAsync(object parameter)
            {
                _canExecute = false;

                if (_executeAction != null)
                {
                    await _executeAction(parameter);
                }

                _canExecute = true;
            }
        }
    }
}

