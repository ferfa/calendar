using calendar.ViewModels;
using System;
using System.Collections.Generic;

namespace calendar.Models
{
    public class DayModel
    {
        public DateTime Date { get; set; }
        public List<TaskViewModel> Tasks { get; set; }
    }
}
