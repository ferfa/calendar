using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace calendar
{
    public class MonthGrid
    {
        //public static List<Day> Days { get; } = new List<Day>();
        public static List<DayCell> DayCells { get; } = new List<DayCell>();
        public static List<Day> Days { get; } = new List<Day>();

        public static int Year { get; set; }
        public static int Month { get; set; }

        public static int FirstDay
        {
            get
            {
                DayOfWeek dayOfWeek = new DateTime(Year, Month, 1).DayOfWeek;
                return ((int)dayOfWeek + 6) % 7; //shift the DayOfWeek enum so that Monday is the first day of week
            }
        }

        public MonthGrid(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public void Init()
        {
            //...each DayCell adds itself to DayCells<>...

            Days.Add(null); //Day no. 0

            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                Day day = new Day(new DateTime(Year, Month, i + 1));
                DayCells[i + FirstDay].DayInThisCell = day;
                DayCells[i + FirstDay].Visibility = System.Windows.Visibility.Visible;
                Days.Add(day);
            }
        }

        public int FindCellID(int dayNumber)
        {
            int cellID = dayNumber + FirstDay - 1;
            return cellID;
        }
    }
}
