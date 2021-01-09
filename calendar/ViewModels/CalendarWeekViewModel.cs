﻿using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace calendar.ViewModels
{
    public class CalendarWeekViewModel : ViewModel
    {
        private readonly DateTime _date;

        public CalendarWeekViewModel(DateTime date)
        {
            _date = date;

            Command_CurrentWeek = new ChangeViewModelCommand<CalendarWeekViewModel>(DateTime.Now);
            Command_PreviousWeek = new ChangeViewModelCommand<CalendarWeekViewModel>(_date.AddDays(-7));
            Command_NextWeek = new ChangeViewModelCommand<CalendarWeekViewModel>(_date.AddDays(7));

            Days = new();
            for (int i = 0; i < 7; i++)
            {
                DayViewModel day = new();
                day.Date = FirstDay.AddDays(i);
                day.QueryTasks();
                day.Visibility = Visibility.Visible;
                Days.Add(day);
            }
        }

        public override string Title => "Kalendář / týden";

        public ChangeViewModelCommand<TaskDetailsViewModel> Command_NewTaskDialog { get; } = new();
        public ChangeViewModelCommand<CalendarWeekViewModel> Command_CurrentWeek { get; }
        public ChangeViewModelCommand<CalendarWeekViewModel> Command_PreviousWeek { get; }
        public ChangeViewModelCommand<CalendarWeekViewModel> Command_NextWeek { get; }

        public List<DayViewModel> Days { get; private set; }

        public DateTime FirstDay
        {
            get
            {
                return _date.AddDays(-(int)_date.DayOfWeek + 1).Date;
            }
        }

        public DateTime LastDay
        {
            get
            {
                return FirstDay.AddDays(6).Date;
            }
        }
    }
}
