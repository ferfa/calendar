using System;
using System.Collections.Generic;

namespace calendar
{
    public static class DayManager
    {
        public static List<DayCell> DayCells { get; } = new List<DayCell>();
        public static List<Day> Days { get; } = new List<Day>();
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

            Days.Add(null); // Day no. 0 (invalid Day)

            // Add actual Days to DayCells and make the DayCells visible
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                Day day = new Day(new DateTime(Year, Month, i + 1));
                DayCells[i + FirstDay].DayInThisCell = day;
                DayCells[i + FirstDay].Visibility = System.Windows.Visibility.Visible;
                Days.Add(day);
            }
        }
    }
}