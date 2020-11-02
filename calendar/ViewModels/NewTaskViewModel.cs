using calendar.ViewModels.Commands;
using calendar.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace calendar.ViewModels
{
    public class NewTaskViewModel : ViewModel
    {
        public NewTaskViewModel()
        {
            NewTask_Submit = new NewTaskCommand();
            ChangeView_CalendarMonth = new ChangeViewCommand(typeof(CalendarMonthView));
        }

        public NewTaskCommand NewTask_Submit { get; private set; }
        public ChangeViewCommand ChangeView_CalendarMonth { get; private set; }
    }
}