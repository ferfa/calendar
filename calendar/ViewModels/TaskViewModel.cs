using System;
using calendar.Models;

namespace calendar.ViewModels
{
    public class TaskViewModel
    {
        // TODO: private set (?) - also in other ViewModels
        public TaskModel Task { get; set; }

        public TaskViewModel(string name, string details, DateTime dateAndTime)
        {
            Task = new TaskModel()
            {
                Guid = Guid.NewGuid(),
                Name = name,
                Details = details,
                Date = dateAndTime.Date,
                Time = dateAndTime.TimeOfDay
            };
        }
    }
}
