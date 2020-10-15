using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace calendar
{
    public class Day
    {
        public int DayNumber { get; }

        public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

        public Day(DateTime DT)
        {
            DayNumber = DT.Day;
        }
    }
}
