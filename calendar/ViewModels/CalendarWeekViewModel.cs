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
    public class CalendarWeekViewModel : ViewModel
    {
        private readonly DateTime _date;

        public CalendarWeekViewModel(DateTime date)
        {
            _date = date;

            Command_CurrentWeek = new ChangeViewModelCommand<CalendarWeekViewModel>(DateTime.Now);
            Command_PreviousWeek = new ChangeViewModelCommand<CalendarWeekViewModel>(_date.AddDays(-7));
            Command_NextWeek = new ChangeViewModelCommand<CalendarWeekViewModel>(_date.AddDays(7));

            DayCells = new();
            for (int i = 0; i < 7; i++)
            {
                DayCells.Add(new DayCellViewModel(FirstDay.AddDays(i)));
            }
        }

        public override string Title => "Kalendář / týden";

        public ChangeViewModelCommand<EntryDetailsViewModel> Command_NewTaskDialog { get; } = new();
        public ChangeViewModelCommand<CalendarWeekViewModel> Command_CurrentWeek { get; }
        public ChangeViewModelCommand<CalendarWeekViewModel> Command_PreviousWeek { get; }
        public ChangeViewModelCommand<CalendarWeekViewModel> Command_NextWeek { get; }

        public List<DayCellViewModel> DayCells { get; }

        public DateTime FirstDay
        {
            get
            {
                return _date.AddDays(-((int)_date.DayOfWeek + 6) % 7).Date;
            }
        }

        public DateTime LastDay
        {
            get
            {
                return FirstDay.AddDays(6).Date;
            }
        }

        public string FirstDayString
        {
            get
            {
                CultureInfo culture = new CultureInfo("cs");
                return FirstDay.ToString(culture.DateTimeFormat.LongDatePattern, culture);
            }
        }

        public string LastDayString
        {
            get
            {
                CultureInfo culture = new CultureInfo("cs");
                return FirstDay.ToString(culture.DateTimeFormat.LongDatePattern, culture);
            }
        }
    }
}
