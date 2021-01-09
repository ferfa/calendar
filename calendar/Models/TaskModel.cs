using System;
using System.Data;
using System.Diagnostics;

namespace calendar.Models
{
    public class TaskModel : ObservableObject
    {
        private Guid _guid;
        private string _name;
        private string _details;
        private DateTime _dateAndTime;

        public Guid Guid
        {
            get => _guid;
            set
            {
                if (_guid == Guid.Empty)
                {
                    _guid = value;
                    return;
                }
                else
                {
                    throw new ReadOnlyException("Task GUID can only be set once (at initialization)");
                }
            }
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

        public string Details
        {
            get => _details;
            set
            {
                _details = value;
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

        public Repeat Repeating { get; } = Repeat.None;

        public TaskModel()
        {
            Guid = Guid.NewGuid();
            Trace.WriteLine($"{ Name } created ({ Guid })");
        }
    }

    public enum Repeat
    {
        None,
        Daily,
        Weekly,
        Monthly
    }
}