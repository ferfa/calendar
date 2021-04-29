using calendar.ViewModels;
using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Data;

namespace calendar.Models
{
    [Serializable()]
    public class EntryModel : ObservableObject
    {
        private string _name;
        private string _description;
        private DateTime _dateAndTime;
        private DateTime _endDate;
        private Repeat _repeatRule = Repeat.Never;
        private ObservableCollection<DateTime> _completed = new();
        private ObservableCollection<DateTime> _deleted = new();

        public EntryModel()
        {
            Command_Edit = new(this);
            Command_Delete = new(this);

            Trace.WriteLine($"Entry { Name } created.");
        }
        
        [JsonIgnore]
        public ChangeViewModelCommand<EntryDetailsViewModel> Command_Edit { get; }
        [JsonIgnore]
        public DeleteEntryCommand Command_Delete { get; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
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

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        public Repeat RepeatRule
        {
            get => _repeatRule;
            set
            {
                _repeatRule = value;
                OnPropertyChanged();
            }
        }

        public enum Repeat
        {
            Never,
            Daily,
            Weekly,
            Monthly
        }

        public ObservableCollection<DateTime> Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DateTime> Deleted
        {
            get => _deleted;
            set
            {
                _deleted = value;
                OnPropertyChanged();
            }
        }

        public bool CheckDay(DateTime date)
        {
            if (Deleted.Contains(date))
            {
                return false;
            }

            if (RepeatRule == Repeat.Never && DateAndTime.Date == date.Date)
            {
                return true;
            }
            else if (DateAndTime.Date <= date.Date && EndDate.Date >= date.Date)
            {
                switch (RepeatRule)
                {
                    case Repeat.Daily:
                        return true;
                    case Repeat.Weekly:
                        return (DateAndTime.DayOfWeek == date.DayOfWeek);
                    case Repeat.Monthly:
                        return (DateAndTime.Day == date.Day);
                }
            }

            return false;
        }

        [JsonIgnore]
        public int Count
        {
            get
            {
                switch (RepeatRule)
                {
                    case Repeat.Never:
                        return 1;
                    case Repeat.Daily:
                        return (EndDate - DateAndTime.Date).Days - Deleted.Count + 1;
                    case Repeat.Weekly:
                        return (EndDate - DateAndTime.Date).Days / 7 - Deleted.Count + 1;
                }
                return 0;
            }
        }

        public bool IsCompleted(DateTime date)
        {
            if (Completed.Contains(date))
            {
                return true;
            }
            return false;
        }

        public void Complete(DateTime date)
        {
            Completed.Add(date);
        }

        public void Uncomplete(DateTime date)
        {
            Completed.Remove(date);
        }
    }
}
