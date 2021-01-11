using calendar.Models;
using calendar.Utilities;
using System;
using System.Windows.Input;

namespace calendar.ViewModels
{
    public class DeleteTaskCommand : ICommand
    {
        private readonly TaskModel _taskModel;

        public DeleteTaskCommand(TaskModel task)
        {
            _taskModel = task;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            TaskManager.DeleteTask(_taskModel);
        }
    }
}
