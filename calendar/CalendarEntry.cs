using calendar.ViewModels;
using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calendar
{
    public abstract class CalendarEntry : ObservableObject
    {
        private string _name;
        private DateTime _dateAndTime;

        public CalendarEntry()
        {
            Trace.WriteLine($"{ GetType() } : CalendarEntry { Name } created.");
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateAndTime
        {
            get => _dateAndTime;
            set
            {
                _dateAndTime = value;
                OnPropertyChanged();
            }
        }

        public abstract ICommand Command_Edit { get; protected set; }
        public abstract ICommand Command_Delete { get; protected set; }
    }
}
