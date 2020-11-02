using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class CommandCombo : ICommand
    {
        // TODO: add parameter support
        private readonly ICommand[] _commands;

        public CommandCombo(ICommand[] commands)
        {
            _commands = commands;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            foreach (var command in _commands)
            {
                if (command.CanExecute(parameter) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public void Execute(object parameter)
        {
            foreach (var command in _commands)
            {
                if (command.CanExecute(parameter))
                {
                    command.Execute(parameter);
                }
            }
        }
    }
}
