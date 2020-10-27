using System;
using System.Collections.Generic;
using System.Linq;
using calendar.Utilities;
using calendar.Models;
using System.Collections.ObjectModel;
using System.Net.WebSockets;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows;
using calendar.ViewModels.Commands;

namespace calendar.ViewModels
{
    public class DayViewModel : ObservableObject
    {
        ////public IEnumerable<TaskViewModel> Tasks { get; }
        ////public DateTime Date { get; }

        ////public DayViewModel(DateTime DT)
        ////{
        ////    Date = DT;

        ////    Tasks = from task in TaskManager.Tasks
        ////            where task.Date.Year == Date.Year
        ////            && task.Date.Month == Date.Month
        ////            && task.Date.Day == Date.Day
        ////            select task;
        ////}

        //public DayModel Day { get; }

        //public DateTime Date
        //{
        //    get
        //    {
        //        return Day.Date;
        //    }
        //}

        //public DayViewModel(DateTime date)
        //{
        //    Day = new DayModel()
        //    {
        //        Date = date
        //    };
        //}

        public NewTaskCommand NewTask { get; private set; } = new NewTaskCommand(TaskManager.AddTestTask);

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

        public DayViewModel()
        {
            _dayModel = new DayModel();
            TaskManager.TasksModified += Query;
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

        private DayModel _dayModel;
        private Visibility _visibility = Visibility.Hidden;
    }
}
