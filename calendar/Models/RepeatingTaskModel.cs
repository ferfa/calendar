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

        public RepeatingTaskModel(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;

            Command_Delete = new DeleteCalendarEntryCommand(this);
            Command_Edit = new ChangeViewModelCommand<TaskDetailsViewModel>();
        }

        public override ICommand Command_Edit { get; protected set; }
        public override ICommand Command_Delete { get; protected set; }
        
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

    }
}
