using calendar.ViewModels.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace calendar.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private static ViewModel _view;

        public MainWindowViewModel()
        {
            _view = new CalendarMonthViewModel(DateTime.Now);
        }

        public static event PropertyChangedEventHandler StaticPropertyChanged;

        public ChangeViewModelCommand<CalendarMonthViewModel> Command_ViewMonth { get; } = new(DateTime.Now);
        public ChangeViewModelCommand<CalendarWeekViewModel> Command_ViewWeek { get; } = new(DateTime.Now);

        public static ViewModel ViewModel
        {
            get => _view;
            set
            {
                _view = value;
                OnStaticPropertyChanged();
            }
        }

        // TODO: move StaticPropertyChanged to ObservableObject
        protected static void OnStaticPropertyChanged([CallerMemberName] string propertyName = "")
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}
