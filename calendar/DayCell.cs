using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace calendar
{
    public class DayCell
    {
        public int Day { get; } = 0;
        public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

        public DayCell(DateTime DT)
        {
            Day = DT.Day;
        }
    }
}
