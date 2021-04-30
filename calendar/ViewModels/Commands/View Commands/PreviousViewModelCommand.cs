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

        // Je uložen předchozí ViewModel a při vyvolání Execute() je tento ViewModel nastaven
        public void Execute(object parameter)
        {
            EntryManager.OnTasksModified();
            MainWindowViewModel.ViewModel = PreviousViewModel;
        }

        public static ViewModel PreviousViewModel { get; set; }
    }
}
