using calendar.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class PreviousViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            TaskManager.OnTasksModified();
            MainWindowViewModel.ViewModel = PreviousViewModel;
        }

        public static ViewModel PreviousViewModel { get; set; }
    }
}
