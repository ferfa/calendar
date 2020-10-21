using System;
using System.ComponentModel;

namespace calendar
{
    public class Task
    {
        public Guid GetGuid { get; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public Task(string name, string details, DateTime dateAndTime)
        {
            GetGuid = Guid.NewGuid();
            Name = name;
            Details = details;
            Date = dateAndTime.Date;
            Time = dateAndTime.TimeOfDay;
        }
    }
}
