using calendar.Models;
using calendar.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
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

            // Otevírání JSON souboru; pokud není obsah souboru ve správném formátu, zobrazí se chybové okno
            if (openFileDialog.FileName != "")
            {
                if (FileManager.CurrentFileModified == true)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Máte neuložené změny. Chcete je před změnou souboru uložit?", "Neuložené změny", MessageBoxButton.YesNoCancel);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        if (FileManager.CurrentFileName == null)
                        {
                            new SaveAsCommand().Execute(null);
                        }
                        else
                        {
                            FileManager.SaveFile(FileManager.CurrentFileName);
                        }
                    }
                    if (dialogResult == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                }

                try
                {
                    FileManager.LoadFile(openFileDialog.FileName);
                    MainWindowViewModel.ViewModel = new CalendarMonthViewModel(DateTime.Now);
                }
                catch (JsonException)
                {
                    MessageBox.Show("Neplatný soubor!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
