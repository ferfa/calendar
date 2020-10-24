using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace calendar
{
    public class Day
    {
        public IEnumerable<Task> Tasks { get; }
        public DateTime Date { get; }
        
        public Day(DateTime DT)
        {
            Date = DT;

            Tasks = from task in TaskManager.Tasks
                    where task.Date.Year == Date.Year
                    && task.Date.Month == Date.Month
                    && task.Date.Day == Date.Day
                    select task;
        }
    }
}
