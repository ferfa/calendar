using System;
using System.Windows.Input;
using calendar.Views;

namespace calendar.ViewModels.Commands
{
    public class ChangeViewCommand : ICommand
    {
        private readonly Type _viewType;

        public event EventHandler CanExecuteChanged;

        public ChangeViewCommand(Type viewType)
        {
            _viewType = viewType;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            MainWindowViewModel.View = (View)Activator.CreateInstance(_viewType);
        }
    }
}
