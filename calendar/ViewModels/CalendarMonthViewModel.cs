using calendar.Models;
using calendar.ViewModels.Commands;
using calendar.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace calendar.ViewModels
{
    class CalendarMonthViewModel : ObservableObject
    {
        private readonly int _firstDay;

        public CalendarMonthViewModel()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

            // Makes Monday the first day of week and gets the day of week where the current month starts
            _firstDay = ((int)(new DateTime(Year, Month, 1).DayOfWeek) + 6) % 7;

            NewTaskViewCommand = new ChangeViewCommand(typeof(NewTaskView));

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

        public ChangeViewCommand NewTaskViewCommand { get; private set; }

        public List<DayViewModel> Days { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }
    }
}
