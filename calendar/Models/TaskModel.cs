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

        public TaskModel()
        {
            Command_Edit = new ChangeViewModelCommand<TaskDetailsViewModel>(this);
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
    }
}