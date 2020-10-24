using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using calendar.UserControls;

namespace calendar
{
    public static class DayManager
    {
        public static List<DayCell> DayCells { get; } = new List<DayCell>();
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

            // ...each DayCell adds itself to DayCells<>...

            // Add actual Days to valid DayCells and make the DayCells visible
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                Day day = new Day(new DateTime(Year, Month, i + 1));
                DayCells[i + FirstDay].DayInThisCell = day;
                DayCells[i + FirstDay].Visibility = System.Windows.Visibility.Visible;
            }
        }

        // Sets the current view to desired year and month and takes care of all the DayCells
        public static void SetYearAndMonth(int year, int month)
        {
            Month = month;
            Year = year;

            foreach (DayCell dayCell in DayCells) {
                dayCell.Disable();
            }

            // Add actual Days to valid DayCells and make the DayCells visible
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                Day day = new Day(new DateTime(Year, Month, i + 1));
                DayCells[i + FirstDay].DayInThisCell = day;
                DayCells[i + FirstDay].Visibility = System.Windows.Visibility.Visible;
            }

            foreach (DayCell dayCell in DayCells)
            {
                dayCell.Rebind();
            }
        }
    }
}