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
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged();
                OnPropertyChanged("Tasks");
            }
        }

        public List<TaskModel> Tasks
        {
            get
            {
                if (Date != null)
                {
                    return TaskManager.GetTasksByDate(Date);
                }
                return null;
            }
        }

        private DateTime _date;
        private Visibility _visibility = Visibility.Hidden;
    }
}
