using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    class OpenWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
