using calendar.Models;
using calendar.ViewModels.Commands;
using calendar.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace calendar.ViewModels
{
    public class CalendarMonthViewModel : ViewModel
    {
        private readonly DateTime _yearAndMonth;
        private readonly int _firstDay;

        public CalendarMonthViewModel(DateTime yearAndMonth)
        {
            _yearAndMonth = yearAndMonth;

            Command_NewTaskDialog = new ChangeViewModelCommand<NewTaskViewModel>();
            Command_CurrentMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(DateTime.Now);
            Command_PreviousMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(_yearAndMonth.AddMonths(-1));
            Command_NextMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(_yearAndMonth.AddMonths(1));

            // Makes Monday the first day of week and gets the day of week where the current month starts
            _firstDay = ((int)(new DateTime(Year, Month, 1).DayOfWeek) + 6) % 7;

            Days = new List<DayViewModel>();
            for (int i = 0; i < 42; i++)
            {
                Days.Add(new DayViewModel());
            }

            // Makes DayCellViews that correspond to actual days of month visible
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                Days[i + _firstDay].Date = new DateTime(Year, Month, i + 1);
                Days[i + _firstDay].Query();
                Days[i + _firstDay].Visibility = Visibility.Visible;
            }
        }

        public ChangeViewModelCommand<NewTaskViewModel> Command_NewTaskDialog { get; private set; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_CurrentMonth { get; private set; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_PreviousMonth { get; private set; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_NextMonth { get; private set; }

        public List<DayViewModel> Days { get; private set; }

        public int Year
        {
            get
            {
                return _yearAndMonth.Year;
            }
        }

        public int Month
        {
            get
            {
                return _yearAndMonth.Month;
            }
        }

        public override void Update()
        {
            foreach (var day in Days)
            {
                day.Query();
            }
        }
    }
}
