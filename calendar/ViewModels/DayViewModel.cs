using calendar.Models;
using calendar.Utilities;
using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Windows;

namespace calendar.ViewModels
{
    public class DayViewModel : ViewModel
    {
        private readonly DayModel _dayModel = new();
        private Visibility _visibility = Visibility.Hidden;
        
        public DayViewModel()
        {
            TaskManager.TasksModified += QueryTasks;
        }

        public ChangeViewModelCommand<TaskDetailsViewModel> Command_EditTaskDialog { get; set; }

        public Visibility Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get
            {
                return _dayModel.Date;
            }
            set
            {
                _dayModel.Date = value;
                QueryTasks();
                OnPropertyChanged();
                //OnPropertyChanged("Tasks");
            }
        }

        public List<TaskViewModel> Tasks
        {
            get
            {
                return _dayModel.Tasks;
            }
            set
            {
                _dayModel.Tasks = value;
                OnPropertyChanged();
            }
        }

        public void QueryTasks()
        {
            Tasks = TaskManager.GetTasksByDate(Date);
        }
    }
}
