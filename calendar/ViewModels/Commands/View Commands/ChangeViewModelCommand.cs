using System;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class ChangeViewModelCommand<T> : ICommand where T : ViewModel
    {
        private readonly object[] _viewModelParams;

        public ChangeViewModelCommand(params object[] viewModelParams)
        {
            _viewModelParams = viewModelParams;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Změní ViewModel hlavního okna na novou instanci typu T; pokud jsou specifikovány parametry, je ViewModel vytvořen s nimi
        public void Execute(object parameter)
        {
            PreviousViewModelCommand.PreviousViewModel = MainWindowViewModel.ViewModel;
            if (_viewModelParams.Length != 0)
            {
                MainWindowViewModel.ViewModel = (T)Activator.CreateInstance(typeof(T), _viewModelParams);
            }
            else
            {
                MainWindowViewModel.ViewModel = (T)Activator.CreateInstance(typeof(T));
            }
        }
    }
}
