using calendar.Utilities;
using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace calendar.Models
{
    public class DayModel : ObservableObject
    {
        private DateTime _date;
        private List<TaskModel> _tasks;

        public DayModel(DateTime date)
        {
            Date = date;
            TaskManager.TasksModified += QueryTasks;
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                QueryTasks();
                OnPropertyChanged();
            }
        }

        public List<TaskModel> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        // TODO: replace with OnPropertyChanged()
        public void QueryTasks()
        {
            Tasks = TaskManager.GetTasksByDate(Date);
        }
    }
}
