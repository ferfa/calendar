using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection;
using System.Windows.Documents;
using System.Windows.Input;
using calendar.Views;

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
            MainWindowViewModel.ViewModel = (T)Activator.CreateInstance(typeof(T), _viewModelParams);
        }
    }
}
