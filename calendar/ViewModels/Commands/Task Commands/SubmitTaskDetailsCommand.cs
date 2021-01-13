using calendar.Models;
using calendar.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class SubmitTaskDetailsCommand : ICommand
    {
        private readonly EntryDetailsViewModel _entryDetailsSource;
        private readonly CalendarEntry _entry;

        /// <summary>
        /// Creates a new task with details provided by <paramref name="entryDetailsSource"/>.
        /// </summary>
        /// <param name="entryDetailsSource"></param>
        public SubmitTaskDetailsCommand(EntryDetailsViewModel entryDetailsSource)
        {
            _entryDetailsSource = entryDetailsSource;
        }

        /// <summary>
        /// Edits an existing <paramref name="entry"/> with details provided by <paramref name="entryDetailsSource"/>.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="entryDetailsSource"></param>
        public SubmitTaskDetailsCommand(EntryDetailsViewModel entryDetailsSource, CalendarEntry entry)
        {
            _entryDetailsSource = entryDetailsSource;
            _entry = entry;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_entry == null)
            {


                if (_entryDetailsSource.Entry_IsRepeating == false)
                {
                    EntryManager.AddEntry(new TaskModel()
                    {
                        Name = _entryDetailsSource.Entry_Name,
                        DateAndTime = _entryDetailsSource.Entry_DateAndTime,
                        Details = _entryDetailsSource.Task_Details
                    });
                }

                if (_entryDetailsSource.Entry_IsRepeating)
                {
                    EntryManager.AddEntry(new RepeatingTaskModel()
                    {
                        Name = _entryDetailsSource.Entry_Name,
                        RepeatingDayOfWeek = _entryDetailsSource.RepeatingTask_DayOfWeek
                    });
                }
            }
            else
            {
                _entry.Name = _entryDetailsSource.Entry_Name;

                if (_entry is TaskModel task)
                {
                    task.DateAndTime = _entryDetailsSource.Entry_DateAndTime;
                    task.Details = _entryDetailsSource.Task_Details;
                }
                if (_entry is RepeatingTaskModel repeatingTask)
                {
                    repeatingTask.RepeatingDayOfWeek = _entryDetailsSource.RepeatingTask_DayOfWeek;
                }
            }
        }
    }
}
