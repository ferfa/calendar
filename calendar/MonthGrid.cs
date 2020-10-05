using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace calendar
{
    class MonthGrid
    {
        private static DayOfWeek _firstDayOfMonth;
        private static List<DayCell> _dayCells = new List<DayCell>();

        public static void Init(int year, int month)
        {
            CultureInfo CC = CultureInfo.CurrentCulture;
            DateTime DT = new DateTime(year, month, 1);
            _firstDayOfMonth = DT.DayOfWeek;

            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                _dayCells.Add(new DayCell(new DateTime(year, month, day)));
            }

            System.Windows.MessageBox.Show($"První den měsíce { CC.DateTimeFormat.GetMonthName(month) } roku { year } je { CC.DateTimeFormat.GetDayName(_firstDayOfMonth) }.");
            System.Windows.MessageBox.Show($"25. 11. 2001 je { CC.DateTimeFormat.GetDayName((new DateTime(2001, 11, 25).DayOfWeek)) }.");
        }

    }
}
