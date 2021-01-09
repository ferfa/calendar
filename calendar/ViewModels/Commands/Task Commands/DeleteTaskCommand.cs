using calendar.Utilities;
using System;
using System.Windows.Input;

namespace calendar.ViewModels
{
    public class DeleteTaskCommand : ICommand
    {
        private TaskViewModel _taskViewModel;

        public DeleteTaskCommand(TaskViewModel taskViewModel)
        {
            _taskViewModel = taskViewModel;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            TaskManager.DeleteTask(_taskViewModel);
        }
    }
}
