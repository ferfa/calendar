using calendar.Utilities;
using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace calendar.Models
{
    public class DayModel : ObservableObject
    {
        private DateTime _date;
        private List<CalendarEntry> _entries;

        public DayModel(DateTime date)
        {
            Date = date;
            EntryManager.TasksModified += QueryTasks;
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                QueryTasks();
                OnPropertyChanged();
            }
        }

        public List<CalendarEntry> Entries
        {
            get
            {
                return _entries;
            }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        // TODO: replace with OnPropertyChanged()
        public void QueryTasks()
        {
            Entries = EntryManager.GetEntriesByDate(typeof(TaskModel), Date);
        }
    }
}
