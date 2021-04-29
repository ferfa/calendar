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
    public class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            SaveFileDialog saveFileDialog1 = new();
            saveFileDialog1.Filter = "JSON|*.json";
            saveFileDialog1.Title = "Uložit do souboru";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                if (saveFileDialog1.FilterIndex == 1)
                {
                    File.WriteAllText(saveFileDialog1.FileName, JsonSerializer.Serialize(EntryManager.Entries));
                }
            }
        }
    }
}
