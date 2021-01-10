using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Windows;

namespace calendar.ViewModels
{
    public class CalendarMonthViewModel : ViewModel
    {
        private readonly DateTime _yearAndMonth;
        private readonly int _firstDayOfWeek;

        public CalendarMonthViewModel(DateTime yearAndMonth)
        {
            _yearAndMonth = yearAndMonth;

            Command_CurrentMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(DateTime.Now);
            Command_PreviousMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(_yearAndMonth.AddMonths(-1));
            Command_NextMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(_yearAndMonth.AddMonths(1));

            // Makes Monday the first day of week and gets the day of week where the current month starts
            _firstDayOfWeek = ((int)(new DateTime(Year, Month, 1).DayOfWeek) + 6) % 7;

            Days = new List<DayViewModel>();
            for (int i = 0; i < 42; i++)
            {
                Days.Add(new DayViewModel());
            }

            // Makes DayViews that correspond to actual days of month visible
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                Days[i + _firstDayOfWeek].Date = new DateTime(Year, Month, i + 1);
                Days[i + _firstDayOfWeek].Visibility = Visibility.Visible;
            }
        }

        public override string Title => "Kalendář / měsíc";

        public ChangeViewModelCommand<TaskDetailsViewModel> Command_NewTaskDialog { get; } = new();
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_CurrentMonth { get; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_PreviousMonth { get; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_NextMonth { get; }

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

        public string MonthString
        {
            get
            {
                var culture = new System.Globalization.CultureInfo("cs");
                return culture.DateTimeFormat.GetMonthName(Month);
            }
        }

        //public override void Update()
        //{
        //    foreach (var day in Days)
        //    {
        //        day.QueryTasks();
        //    }
        //}
    }
}
