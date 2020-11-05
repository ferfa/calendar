using calendar.Models;
using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Input;

namespace calendar.ViewModels
{
    public class TaskDetailsViewModel : ViewModel
    {
        private string _taskName;
        private string _taskDetails;
        private DateTime _taskDateAndTime = DateTime.Now;

        public TaskDetailsViewModel()
        {
            Command_Submit = new CommandCombo(new TaskDetailsCommand(this), Command_Close);
        }

        public TaskDetailsViewModel(TaskModel task)
        {
            _taskName = task.Name;
            _taskDetails = task.Details;
            _taskDateAndTime = task.DateAndTime;

            Command_Submit = new CommandCombo(new TaskDetailsCommand(this, task), Command_Close);
        }

        public CommandCombo Command_Submit { get; private set; }
        public PreviousViewModelCommand Command_Close { get; private set; } = new PreviousViewModelCommand();

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

        public DateTime TaskDateAndTime
        {
            get => _taskDateAndTime;
            set
            {
                _taskDateAndTime = value;
                OnPropertyChanged();
            }
        }

    }
}
