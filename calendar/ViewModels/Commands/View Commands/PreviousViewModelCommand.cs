using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class PreviousViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PreviousViewModel.Update();
            MainWindowViewModel.ViewModel = PreviousViewModel;
        }

        public static ViewModel PreviousViewModel { get; set; }
    }
}
