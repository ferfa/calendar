using calendar.Models;
using calendar.Utilities;
using System;
using System.Windows.Input;

namespace calendar.ViewModels
{
    public class DeleteEntryCommand : ICommand
    {
        private readonly EntryModel _entry;

        public DeleteEntryCommand(EntryModel entry)
        {
            _entry = entry;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            EntryManager.DeleteEntry(_entry);
        }
    }
}
