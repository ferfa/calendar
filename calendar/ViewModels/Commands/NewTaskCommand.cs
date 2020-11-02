using calendar.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class NewTaskCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            TaskManager.AddTestTask();
        }
    }
}
