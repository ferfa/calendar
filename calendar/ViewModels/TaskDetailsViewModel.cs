using calendar.Models;
using calendar.ViewModels.Commands;
using System;

namespace calendar.ViewModels
{
    public class TaskDetailsViewModel : ViewModel
    {
        private string _taskName;
        private string _taskDetails;
        private DateTime _taskDate = DateTime.Now.Date;
        private TimeSpan _taskTime = new(0, (int)(Math.Round(DateTime.Now.TimeOfDay.TotalMinutes / 15) * 15), 0);

        /// <summary>
        /// Creates a new <typeparamref name="TaskModel"/>.
        /// </summary>
        public TaskDetailsViewModel()
        {
            Command_Submit = new CommandCombo(new TaskDetailsCommand(this), Command_Close);
        }

        /// <summary>
        /// Edits an existing <paramref name="taskModel"/>.
        /// </summary>
        /// <param name="taskModel"></param>
        public TaskDetailsViewModel(TaskModel taskModel)
        {
            _taskName = taskModel.Name;
            _taskDetails = taskModel.Details;
            _taskDate = taskModel.DateAndTime.Date;
            _taskTime = taskModel.DateAndTime.TimeOfDay;

            Command_Submit = new CommandCombo(new TaskDetailsCommand(this, taskModel), Command_Close);
        }

        public override string Title => $"Podrobnosti události { TaskName }";

        public CommandCombo Command_Submit { get; private set; }
        public PreviousViewModelCommand Command_Close { get; private set; } = new();

        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                OnPropertyChanged();
            }
        }

        public string TaskDetails
        {
            get => _taskDetails;
            set
            {
                _taskDetails = value;
                OnPropertyChanged();
            }
        }

        public DateTime TaskDate
        {
            get => _taskDate;
            set
            {
                _taskDate = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan TaskTime
        {
            get => _taskTime;
            set
            {
                _taskTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime TaskDateAndTime
        {
            get => _taskDate + _taskTime;
        }
    }
}
