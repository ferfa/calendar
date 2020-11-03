using System;
using System.Windows.Input;
using calendar.Views;

namespace calendar.ViewModels.Commands
{
    public class ChangeViewCommand : ICommand
    {
        private readonly Type _viewModelType;

        public event EventHandler CanExecuteChanged;

        public ChangeViewCommand(Type viewModelType)
        {
            _viewModelType = viewModelType;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            MainWindowViewModel.ViewModel = (ViewModel)Activator.CreateInstance(_viewModelType);
        }
    }
}
