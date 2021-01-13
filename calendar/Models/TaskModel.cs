using calendar.ViewModels;
using calendar.ViewModels.Commands;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Input;

namespace calendar.Models
{
    public class TaskModel : CalendarEntry
    {
        private string _details;
        private DateTime _dateAndTime;

        public TaskModel()
        {
            Command_Edit = new ChangeViewModelCommand<EntryDetailsViewModel>(this);
            Command_Delete = new DeleteCalendarEntryCommand(this);

            Guid = Guid.NewGuid();
        }

        public override ICommand Command_Edit { get; protected set; }
        public override ICommand Command_Delete { get; protected set; }

        public Guid Guid { get; }

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
    }
}