using calendar.Models;
using calendar.ViewModels.Commands;
using System;

namespace calendar.ViewModels
{
    public class EntryDetailsViewModel : ViewModel
    {
        private string _entry_Name;

        private DateTime _task_Date = DateTime.Now.Date;
        private TimeSpan _task_Time = new(0, (int)(Math.Round(DateTime.Now.TimeOfDay.TotalMinutes / 15) * 15), 0);
        private string _task_Details;

        private bool _entry_isRepeating;
        private DayOfWeek _repeatingTask_RepeatingDayOfWeek = DayOfWeek.Monday;

        /// <summary>
        /// Creates a new <typeparamref name="CalendarEntry"/>.
        /// </summary>
        public EntryDetailsViewModel()
        {
            Command_Submit = new CommandCombo(new SubmitTaskDetailsCommand(this), Command_Close);
        }

        /// <summary>
        /// Edits an existing <paramref name="calendarEntryModel"/>.
        /// </summary>
        /// <param name="calendarEntryModel"></param>
        public EntryDetailsViewModel(CalendarEntry calendarEntryModel)
        {
            _entry_Name = calendarEntryModel.Name;

            if (calendarEntryModel is TaskModel task) {
                _task_Date = task.DateAndTime.Date;
                _task_Time = task.DateAndTime.TimeOfDay;
                _task_Details = task.Details;
            }

            if (calendarEntryModel is RepeatingTaskModel repeatingTask) {
                Entry_IsRepeating = true;
                _task_Time = repeatingTask.Time;
                _repeatingTask_RepeatingDayOfWeek = repeatingTask.RepeatingDayOfWeek;
            }

            
            Command_Submit = new CommandCombo(new SubmitTaskDetailsCommand(this, calendarEntryModel), Command_Close);
        }

        public override string Title => $"Podrobnosti události { Entry_Name }";

        public CommandCombo Command_Submit { get; private set; }
        public PreviousViewModelCommand Command_Close { get; private set; } = new();

        public bool Entry_IsRepeating
        {
            get => _entry_isRepeating;
            set
            {
                _entry_isRepeating = value;
                OnPropertyChanged();
            }
        }

        public string Entry_Name
        {
            get => _entry_Name;
            set
            {
                _entry_Name = value;
                OnPropertyChanged();
            }
        }

        public DateTime Entry_Date
        {
            get => _task_Date;
            set
            {
                _task_Date = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Task_Time
        {
            get => _task_Time;
            set
            {
                _task_Time = value;
                OnPropertyChanged();
            }
        }

        public DateTime Task_DateAndTime
        {
            get => _task_Date + _task_Time;
        }

        public string Task_Details
        {
            get => _task_Details;
            set
            {
                _task_Details = value;
                OnPropertyChanged();
            }
        }

        public DayOfWeek RepeatingTask_DayOfWeek
        {
            get => _repeatingTask_RepeatingDayOfWeek;
            set
            {
                _repeatingTask_RepeatingDayOfWeek = value;
                OnPropertyChanged();
            }
        }

        public DayOfWeek[] DaysOfWeek
        {
            get
            {
                return (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek));
            }
        }
    }
}
