using calendar.Utilities;
using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace calendar.Models
{

    // Model dne, obsahuje pouze základní vlastnosti a logiku
    public class DayModel : ObservableObject
    {
        private DateTime _date;
        private List<EntryModel> _entries;

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

        public List<EntryModel> Entries
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

        // Tato metoda je zavolána vždy, kdy by se měl aktualizovat seznam úkolů
        public void QueryTasks()
        {
            Entries = EntryManager.GetEntriesByDate(Date);
        }
    }
}
