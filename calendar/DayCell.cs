using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace calendar
{
    class DayCell
    {
        private int _dayOfMonth;

        public DayCell(DateTime DT)
        {
            _dayOfMonth = DT.Day;
        }
    }
}
