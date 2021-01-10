using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace calendar.ViewModels
{
    public class CalendarDayViewModel : ViewModel
    {
        public CalendarDayViewModel(DateTime date)
        {
            Date = date;

            Command_CurrentDay = new ChangeViewModelCommand<CalendarDayViewModel>(DateTime.Now);
            Command_PreviousDay = new ChangeViewModelCommand<CalendarDayViewModel>(Date.AddDays(-1));
            Command_NextDay = new ChangeViewModelCommand<CalendarDayViewModel>(Date.AddDays(1));

            DayViewModel day = new();
            day.Date = Date;
            day.Visibility = Visibility.Visible;
            Day = day;
        }

        public override string Title => "Kalendář / den";

        public ChangeViewModelCommand<TaskDetailsViewModel> Command_NewTaskDialog { get; } = new();
        public ChangeViewModelCommand<CalendarDayViewModel> Command_CurrentDay { get; }
        public ChangeViewModelCommand<CalendarDayViewModel> Command_PreviousDay { get; }
        public ChangeViewModelCommand<CalendarDayViewModel> Command_NextDay { get; }

        public DayViewModel Day { get; private set; }

        public DateTime Date { get; private set; }

        public string DateString
        {
            get
            {
                var culture = new CultureInfo("cs");
                return Date.ToString(culture.DateTimeFormat.LongDatePattern, culture);
            }
        }
    }
}
