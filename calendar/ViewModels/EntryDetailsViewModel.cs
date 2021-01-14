using calendar.Models;
using calendar.ViewModels.Commands;
using System;

namespace calendar.ViewModels
{
    public class EntryDetailsViewModel : ViewModel
    {
        private string _entry_Name;
        private string _entry_Description;
        private DateTime _entry_Date = DateTime.Now.Date;
        private TimeSpan _entry_Time = new(0, (int)(Math.Round(DateTime.Now.TimeOfDay.TotalMinutes / 15) * 15), 0);
        private EntryModel.Repeat _entry_RepeatRule;

        /// <summary>
        /// Creates a new <typeparamref name="CalendarEntry"/>.
        /// </summary>
        public EntryDetailsViewModel()
        {
            Command_Submit = new CommandCombo(new SubmitTaskDetailsCommand(this), Command_Close);
        }

        /// <summary>
        /// Edits an existing <paramref name="entryModel"/>.
        /// </summary>
        /// <param name="entryModel"></param>
        public EntryDetailsViewModel(EntryModel entryModel)
        {
            Entry_Name = entryModel.Name;
            Entry_Description = entryModel.Description;
            Entry_Date = entryModel.DateAndTime.Date;
            Entry_Time = entryModel.DateAndTime.TimeOfDay;
            Entry_RepeatRule = entryModel.RepeatRule;

            Command_Submit = new CommandCombo(new SubmitTaskDetailsCommand(this, entryModel), Command_Close);
        }

        public override string Title => $"Podrobnosti události { Entry_Name }";

        public CommandCombo Command_Submit { get; private set; }
        public PreviousViewModelCommand Command_Close { get; private set; } = new();

        public string Entry_Name
        {
            get => _entry_Name;
            set
            {
                _entry_Name = value;
                OnPropertyChanged();
            }
        }

        public string Entry_Description
        {
            get => _entry_Description;
            set
            {
                _entry_Description = value;
                OnPropertyChanged();
            }
        }

        public DateTime Entry_Date
        {
            get => _entry_Date;
            set
            {
                _entry_Date = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Entry_Time
        {
            get => _entry_Time;
            set
            {
                _entry_Time = value;
                OnPropertyChanged();
            }
        }

        public EntryModel.Repeat Entry_RepeatRule
        {
            get => _entry_RepeatRule;
            set
            {
                _entry_RepeatRule = value;
                OnPropertyChanged();
            }
        }

        public EntryModel.Repeat[] Repeat
        {
            get
            {
                return (EntryModel.Repeat[])Enum.GetValues(typeof(EntryModel.Repeat));
            }
        }
    }
}
