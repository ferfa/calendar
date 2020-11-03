using calendar.ViewModels.Commands;
using calendar.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace calendar.ViewModels
{
    public class NewTaskViewModel : ViewModel
    {
        public NewTaskViewModel()
        {
            Command_Close = new ChangeViewCommand(typeof(CalendarMonthViewModel));

            Command_Submit = new CommandCombo(
                new ICommand[] {
                    new NewTaskCommand(this),
                    Command_Close
                });

            NewTaskDate = DateTime.Now;
        }

        public ChangeViewCommand Command_Close { get; private set; }
        public CommandCombo Command_Submit { get; private set; }

        public string NewTaskName { get; set; }
        public string NewTaskDetails { get; set; }
        public DateTime NewTaskDate { get; set; }
    }
}