using calendar.ViewModels;
using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace calendar.Models
{
    public class EntryModel : ObservableObject
    {
        private string _name;
        private string _description;
        private DateTime _dateAndTime;
        private Repeat _repeatRule = Repeat.Never;

        public EntryModel()
        {
            Command_Edit = new(this);
            Command_Delete = new(this);

            Trace.WriteLine($"Entry { Name } created.");
        }

        public ChangeViewModelCommand<EntryDetailsViewModel> Command_Edit { get; }
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

        public bool CheckDay(DateTime date)
        {
            if (RepeatRule == Repeat.Never && DateAndTime.Date == date.Date)
            {
                return true;
            }
            else if (DateAndTime.Date <= date.Date)
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
    }
}
