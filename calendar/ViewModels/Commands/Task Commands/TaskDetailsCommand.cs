using calendar.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class TaskDetailsCommand : ICommand
    {
        private readonly TaskDetailsViewModel _taskDetailsSource;
        private readonly TaskViewModel _task;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new task with details provided by <paramref name="taskDetailsSource"/>
        /// or edits an existing <paramref name="task"/> with details provided by <paramref name="taskDetailsSource"/>.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="taskDetailsSource"></param>
        public TaskDetailsCommand(TaskDetailsViewModel taskDetailsSource, TaskViewModel task = null)
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
                TaskViewModel task = new TaskViewModel()
                {
                    Name = _taskDetailsSource.TaskName,
                    Details = _taskDetailsSource.TaskDetails,
                    DateAndTime = _taskDetailsSource.TaskDate + _taskDetailsSource.TaskTime
                };
                Trace.WriteLine($"task created ({ task.Name }, { task.Details }, { task.DateAndTime.ToShortDateString() }, { task.DateAndTime.TimeOfDay}, GUID: { task.Guid })");
                TaskManager.AddTask(task);
            }
            else
            {
                _task.Name = _taskDetailsSource.TaskName;
                _task.Details = _taskDetailsSource.TaskDetails;
                _task.DateAndTime = _taskDetailsSource.TaskDate.Date + _taskDetailsSource.TaskTime;
                Trace.WriteLine($"task modified ({ _task.Name }, { _task.Details }, { _task.DateAndTime.ToShortDateString() }, { _task.DateAndTime.TimeOfDay }, GUID: { _task.Guid })");
            }
        }
    }
}
