﻿using calendar.Models;
using calendar.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class LoadCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "JSON|*.json";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                using (StreamReader r = new(openFileDialog.FileName))
                {
                    string json = r.ReadToEnd();
                    EntryManager.Entries = JsonSerializer.Deserialize<List<EntryModel>>(json);
                    EntryManager.OnTasksModified();
                }
            }
        }
    }
}