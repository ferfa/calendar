using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using calendar.ViewModels;

namespace calendar.Utilities
{
    public static class DayManager
    {
        public static List<DayViewModel> Days { get; } = new List<DayViewModel>();

        public static int Year { get; set; }
        public static int Month { get; set; }

        public static int FirstDay
        {
            get
            {   // shift the DayOfWeek enum so that Monday is the first day of week
                DayOfWeek dayOfWeek = new DateTime(Year, Month, 1).DayOfWeek;
                return ((int)dayOfWeek + 6) % 7;
            }
        }

        public static void Init(int year, int month)
        {
            Year = year;
            Month = month;

            for (int i = 0; i < 42; i++)
            {
                Days.Add(new DayViewModel());
            }

            // Make DayCellViews that correspond to actual days of month visible
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                Days[i + FirstDay].Date = new DateTime(year, month, i + 1);
                Days[i + FirstDay].Visibility = Visibility.Visible;
            }
        }

        // TODO navigate through months
        // Sets the current view to desired year and month and takes care of all the _days
        public static void SetYearAndMonth(int year, int month)
        {
        }
    }
}