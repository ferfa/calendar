using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace calendar
{
    public class MonthGrid
    {
        public static List<Day> Days { get; } = new List<Day>();

        public MonthGrid()
        {
            Days.Add(new Day(new DateTime()));

            for (int i = 1; i <= 30; i++)
            {
                Days.Add(new Day(new DateTime(2001, 11, i)));
            }
            /*for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                DayCells.Add(new DayCell(new DateTime(year, month, day)));
            }*/
        }
    }
}
