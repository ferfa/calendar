using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace calendar.Models
{
    public class DayModel
    {
        public DateTime Date { get; set; }
        public List<TaskViewModel> Tasks { get; set; }
    }
}
