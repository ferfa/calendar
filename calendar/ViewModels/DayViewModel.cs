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
        private readonly DayModel _dayModel;
        private Visibility _visibility = Visibility.Hidden;
        
        public DayViewModel()
        {
            _dayModel = new DayModel();
            TaskManager.TasksModified += Query;
        }

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
                OnPropertyChanged();
                OnPropertyChanged("Tasks");
            }
        }

        public List<TaskModel> Tasks
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

        public void Query()
        {
            if (Date != null)
            {
                Tasks = TaskManager.GetTasksByDate(Date);
            }
            else
            {
                Tasks = null;
            }
        }
    }
}
