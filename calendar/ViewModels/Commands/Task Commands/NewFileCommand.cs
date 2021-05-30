using calendar.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class NewFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (FileManager.CurrentFileModified == true)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Máte neuložené změny. Chcete je uložit?", "Neuložené změny", MessageBoxButton.YesNoCancel);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    FileManager.SaveFile(FileManager.CurrentFileName);
                }
                else if (dialogResult == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            FileManager.CurrentFileName = null;
            FileManager.CurrentFileModified = false;
            EntryManager.Entries = new();
            EntryManager.OnTasksModified();
        }
    }
}
