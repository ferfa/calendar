using System;
using System.Collections.Generic;
using System.Linq;

namespace calendar
{
    public class Day
    {
        public int DayNumber { get; }
        public IEnumerable<Task> Tasks { get; }

        public Day(DateTime DT)
        {
            DayNumber = DT.Day;

            Tasks = from task in TaskManager.Tasks
                    where task.Date.Day == DayNumber
                    select task;
        }
    }
}
