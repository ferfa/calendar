using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Windows;

namespace calendar.ViewModels
{
    public class CalendarMonthViewModel : ViewModel
    {
        private readonly DateTime _yearAndMonth;

        public CalendarMonthViewModel(DateTime yearAndMonth)
        {
            _yearAndMonth = yearAndMonth;

            Command_CurrentMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(DateTime.Now);
            Command_PreviousMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(_yearAndMonth.AddMonths(-1));
            Command_NextMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(_yearAndMonth.AddMonths(1));

            // Makes Monday the first day of week and gets the day of week where the current month starts
            FirstDayOfWeek = ((int)(new DateTime(Year, Month, 1).DayOfWeek) + 6) % 7;

            DayCells = new();
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                DayCells.Add(new DayCellViewModel(new DateTime(Year, Month, i + 1)) { Visibility = Visibility.Visible });
            }
        }

        public override string Title => "Kalendář / měsíc";

        public ChangeViewModelCommand<TaskDetailsViewModel> Command_NewTaskDialog { get; } = new();
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_CurrentMonth { get; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_PreviousMonth { get; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_NextMonth { get; }

        public List<DayCellViewModel> DayCells { get; private set; }

        public int FirstDayOfWeek { get; }

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
    }
}
