using calendar.ViewModels;
using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calendar.Models
{
    public class RepeatingTaskModel : CalendarEntry
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private TimeSpan _time;

        public RepeatingTaskModel(DateTime startDate = new DateTime(), DateTime endDate = new DateTime())
        {
            _startDate = startDate;
            _endDate = endDate;

            Command_Delete = new DeleteCalendarEntryCommand(this);
            Command_Edit = new ChangeViewModelCommand<EntryDetailsViewModel>(this);
        }

        public override ICommand Command_Edit { get; protected set; }
        public override ICommand Command_Delete { get; protected set; }

        public DayOfWeek RepeatingDayOfWeek { get; set; }
        
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
        }

        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

    }
}
