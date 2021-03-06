﻿using calendar.Models;
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

        // Pokud není stanoveno konkrétní datum, vymaže se úkol kompletně
        public void Execute(object parameter)
        {
            if (parameter == null)
            {
                EntryManager.DeleteAllEntries(_entry);
            }
            else
            {
                EntryManager.DeleteEntry(_entry, (DateTime)parameter);
            }
        }
    }
}
