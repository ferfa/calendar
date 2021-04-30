using calendar.Models;
using calendar.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class SubmitTaskDetailsCommand : ICommand
    {
        private readonly EntryDetailsViewModel _entryDetailsSource;
        private EntryModel _entry;

        // Vytvoří nový úkol podle dat z entryDetailsSource
        public SubmitTaskDetailsCommand(EntryDetailsViewModel entryDetailsSource)
        {
            _entryDetailsSource = entryDetailsSource;
        }

        // Upraví úkol podle dat z entryDetailsSource
        public SubmitTaskDetailsCommand(EntryDetailsViewModel entryDetailsSource, EntryModel entry)
        {
            _entryDetailsSource = entryDetailsSource;
            _entry = entry;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Úprava existujícího úkolu; pokud neexistuje, je vytvořen úkol nový
        public void Execute(object parameter)
        {
            EntryModel entry = new()
            {
                Name = _entryDetailsSource.Entry_Name,
                Description = _entryDetailsSource.Entry_Description,
                DateAndTime = _entryDetailsSource.Entry_Date + _entryDetailsSource.Entry_Time,
                EndDate = _entryDetailsSource.Entry_EndDate,
                RepeatRule = _entryDetailsSource.Entry_RepeatRule
            };

            if (_entry == null)
            {
                EntryManager.AddEntry(entry);
            }
            else
            {
                _entry.Name = _entryDetailsSource.Entry_Name;
                _entry.Description = _entryDetailsSource.Entry_Description;
                _entry.DateAndTime = _entryDetailsSource.Entry_Date + _entryDetailsSource.Entry_Time;
                _entry.EndDate = _entryDetailsSource.Entry_EndDate;
                _entry.RepeatRule = _entryDetailsSource.Entry_RepeatRule;
            }
        }
    }
}
