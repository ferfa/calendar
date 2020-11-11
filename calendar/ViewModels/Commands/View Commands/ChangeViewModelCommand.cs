﻿using System;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class ChangeViewModelCommand<T> : ICommand where T : ViewModel
    {
        private object[] _viewModelParams;

        public ChangeViewModelCommand(params object[] viewModelParams)
        {
            _viewModelParams = viewModelParams;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PreviousViewModelCommand.PreviousViewModel = MainWindowViewModel.ViewModel;
            if (parameter == null)
            {
                MainWindowViewModel.ViewModel = (T)Activator.CreateInstance(typeof(T), _viewModelParams);
            }
            else
            {
                MainWindowViewModel.ViewModel = (T)Activator.CreateInstance(typeof(T), parameter);
            }
        }
    }
}