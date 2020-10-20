using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;

namespace calendar
{
    public class Day
    {
        public int DayNumber { get; }

        public IEnumerable<Task> Tasks { get; private set; }

        public Day(DateTime DT)
        {
            DayNumber = DT.Day;

            Tasks = from task in TaskManager.Tasks
                    where task.Date.Day == DayNumber
                    select task;
        }
    }
}
