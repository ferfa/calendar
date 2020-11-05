using calendar.Models;
using calendar.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class TaskDetailsCommand : ICommand
    {
        private readonly TaskDetailsViewModel _taskDetailsSource;
        private readonly TaskModel _task;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new task with details provided by <paramref name="taskDetailsSource"/>
        /// or edits an existing <paramref name="task"/> with details provided by <paramref name="taskDetailsSource"/>.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="taskDetailsSource"></param>
        public TaskDetailsCommand(TaskDetailsViewModel taskDetailsSource, TaskModel task = null)
        {
            _taskDetailsSource = taskDetailsSource;
            _task = task;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_task == null)
            {
                Trace.WriteLine($"task created ({ _taskDetailsSource.TaskName }, { _taskDetailsSource.TaskDetails }, { _taskDetailsSource.TaskDateAndTime })");
                TaskManager.Tasks.Add(new TaskModel()
                {
                    Name = _taskDetailsSource.TaskName,
                    Details = _taskDetailsSource.TaskDetails,
                    DateAndTime = _taskDetailsSource.TaskDateAndTime,
                });
            }
            else
            {
                Trace.WriteLine($"task modified ({ _taskDetailsSource.TaskName }, { _taskDetailsSource.TaskDetails }, { _taskDetailsSource.TaskDateAndTime })");
                _task.Name = _taskDetailsSource.TaskName;
                _task.Details = _taskDetailsSource.TaskDetails;
                _task.DateAndTime = _taskDetailsSource.TaskDateAndTime;
            }
        }
    }
}
