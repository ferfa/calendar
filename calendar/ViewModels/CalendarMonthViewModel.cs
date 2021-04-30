using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Windows;

namespace calendar.ViewModels
{
    public class CalendarMonthViewModel : ViewModel
    {
        private readonly DateTime _yearAndMonth;

        public CalendarMonthViewModel(DateTime yearAndMonth)
        {
            _yearAndMonth = yearAndMonth;

            // Vytvoření Commandů pro navigaci kalendářem po měsících
            Command_CurrentMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(DateTime.Now);
            Command_PreviousMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(_yearAndMonth.AddMonths(-1));
            Command_NextMonth = new ChangeViewModelCommand<CalendarMonthViewModel>(_yearAndMonth.AddMonths(1));

            // Získá den týdne (po-ne) prvního dne měsíce (a stanoví pondělí jako první den týdne)
            FirstDayOfWeek = ((int)(new DateTime(Year, Month, 1).DayOfWeek) + 6) % 7;

            // Do Listu s buňkami přidá tolik buněk, kolik má měsíc dnů, a zviditelní je
            DayCells = new();
            for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
            {
                DayCells.Add(new DayCellViewModel(new DateTime(Year, Month, i + 1)) { Visibility = Visibility.Visible });
            }
        }

        public override string Title => "Kalendář / měsíc";

        public ChangeViewModelCommand<EntryDetailsViewModel> Command_NewTaskDialog { get; } = new();
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_CurrentMonth { get; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_PreviousMonth { get; }
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_NextMonth { get; }

        public List<DayCellViewModel> DayCells { get; private set; }

        public int FirstDayOfWeek { get; }

        public int Year
        {
            get
            {
                return _yearAndMonth.Year;
            }
        }

        public int Month
        {
            get
            {
                return _yearAndMonth.Month;
            }
        }

        // User friendly text měsíce (použito v Bindingu)
        public string MonthString
        {
            get
            {
                var culture = new System.Globalization.CultureInfo("cs");
                return culture.DateTimeFormat.GetMonthName(Month);
            }
        }
    }
}
