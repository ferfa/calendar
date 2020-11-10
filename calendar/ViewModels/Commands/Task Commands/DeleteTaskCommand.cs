using calendar.Models;
using calendar.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace calendar.ViewModels.Commands.Task_Commands
{
    public class DeleteTaskCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            TaskManager.DeleteTask(parameter as TaskModel);
        }
    }
}
