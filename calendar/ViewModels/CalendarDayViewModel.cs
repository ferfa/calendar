using calendar.Models;
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
            // Odstranění času z parametru date
            date = date.Date;

            // Vytvoření Commandů pro navigaci kalendářem po jednotlivých dnech
            Command_CurrentDay = new(DateTime.Now);
            Command_PreviousDay = new(date.AddDays(-1));
            Command_NextDay = new(date.AddDays(1));

            // Přiřazení jedné buňky k jednodennímu náhledu
            DayCell = new(date);
        }

        public override string Title => "Kalendář / den";

        public ChangeViewModelCommand<EntryDetailsViewModel> Command_NewTaskDialog { get; } = new();
        public ChangeViewModelCommand<CalendarDayViewModel> Command_CurrentDay { get; }
        public ChangeViewModelCommand<CalendarDayViewModel> Command_PreviousDay { get; }
        public ChangeViewModelCommand<CalendarDayViewModel> Command_NextDay { get; }

        public DayCellViewModel DayCell { get; }

        // User friendly text data tohoto dne (použito v Bindingu)
        public string DateString
        {
            get
            {
                var culture = new CultureInfo("cs");
                return DayCell.Day.Date.ToString(culture.DateTimeFormat.LongDatePattern, culture);
            }
        }
    }
}
