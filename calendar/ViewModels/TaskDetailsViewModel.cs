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
        /// For creating a new TaskModel
        /// </summary>
        public TaskDetailsViewModel()
        {
            Command_Submit = new CommandCombo(new TaskDetailsCommand(this), Command_Close);
        }

        /// <summary>
        /// For editing existing <paramref name="taskViewModel"/>
        /// </summary>
        /// <param name="taskViewModel"></param>
        public TaskDetailsViewModel(TaskViewModel taskViewModel)
        {
            _taskName = taskViewModel.Name;
            _taskDetails = taskViewModel.Details;
            _taskDate = taskViewModel.DateAndTime.Date;
            _taskTime = taskViewModel.DateAndTime.TimeOfDay;

            Command_Submit = new CommandCombo(new TaskDetailsCommand(this, taskViewModel), Command_Close);
        }

        public override string Title => "Podrobnosti události";

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
