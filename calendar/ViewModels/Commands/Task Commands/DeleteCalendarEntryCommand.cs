using calendar.Models;
using calendar.Utilities;
using System;
using System.Windows.Input;

namespace calendar.ViewModels
{
    public class DeleteCalendarEntryCommand : ICommand
    {
        private readonly CalendarEntry _taskModel;

        public DeleteCalendarEntryCommand(CalendarEntry task)
        {
            _taskModel = task;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            EntryManager.DeleteEntry(_taskModel);
        }
    }
}
