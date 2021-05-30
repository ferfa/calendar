using calendar.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class SaveAsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Uložení do JSON souboru
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "JSON|*.json";
            saveFileDialog.Title = "Uložit do souboru";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                FileManager.SaveFile(saveFileDialog.FileName);
            }
        }
    }
}
