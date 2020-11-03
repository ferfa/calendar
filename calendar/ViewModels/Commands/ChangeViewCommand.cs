using System;
using System.Windows.Input;
using calendar.Views;

namespace calendar.ViewModels.Commands
{
    public class ChangeViewCommand<T> : ICommand where T : ViewModel
    {
        private DateTime _dateTimeParam;

        public event EventHandler CanExecuteChanged;

        public ChangeViewCommand(DateTime dateTimeParam = new DateTime()) 
        {
            _dateTimeParam = (DateTime)dateTimeParam;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (typeof(T) == typeof(CalendarMonthViewModel))
            {
                MainWindowViewModel.ViewModel = (T)Activator.CreateInstance(typeof(T), _dateTimeParam);
            }
            else
            {
                MainWindowViewModel.ViewModel = (T)Activator.CreateInstance(typeof(T));
            }
        }
    }
}
