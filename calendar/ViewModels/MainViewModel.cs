using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Windows;

namespace calendar.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public List<DayViewModel> Days { get; set; } = new List<DayViewModel>();
        public int Month { get; set; }
        public int Year { get; set; }

        public string DisplayMonthAndYear
        {
            get
            {
                return $"{Month} {Year}";
            }
        }

        public int FirstDay
        {
            get
            {   // shift the DayOfWeek enum so that Monday is the first day of week
                DayOfWeek dayOfWeek = new DateTime(Year, Month, 1).DayOfWeek;
                return ((int)dayOfWeek + 6) % 7;
            }
        }

        public MainViewModel()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

            for (int i = 0; i < 42; i++)
            {
                Days.Add(new DayViewModel());
            }

            // Initialize cells
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                Days[i + FirstDay].Date = new DateTime(Year, Month, i + 1);
                Days[i + FirstDay].Visibility = Visibility.Visible;
            }
        }

    }
}
