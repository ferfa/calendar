using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace calendar
{
    public class MonthGrid
    {
        public List<DayCell> DayCells { get; } = new List<DayCell>();

        public MonthGrid()
        {
            DayCells.Add(new DayCell(new DateTime(2001, 11, 6)));
            /*for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                DayCells.Add(new DayCell(new DateTime(year, month, day)));
            }*/
        }
    }
}
