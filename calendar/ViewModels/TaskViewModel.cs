using calendar.Models;
using calendar.ViewModels.Commands;
using System;

namespace calendar.ViewModels
{
    public class TaskViewModel : ViewModel
    {
        private readonly TaskModel _task = new TaskModel();

        public TaskViewModel()
        {
            Command_EditTaskDialog = new ChangeViewModelCommand<TaskDetailsViewModel>(this);
            Command_DeleteTask = new DeleteTaskCommand(this);
        }

        public ChangeViewModelCommand<TaskDetailsViewModel> Command_EditTaskDialog { get; }
        public DeleteTaskCommand Command_DeleteTask { get; }

        public string Name
        {
            get => _task.Name;
            set
            {
                _task.Name = value;
                OnPropertyChanged();
            }
        }

        public string Details
        {
            get => _task.Details;
            set
            {
                _task.Details = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateAndTime
        {
            get => _task.DateAndTime;
            set
            {
                _task.DateAndTime = value;
                OnPropertyChanged();
            }
        }

        public Guid Guid => _task.Guid;
    }
}
